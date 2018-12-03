using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScene : MonoBehaviour {

	public GameObject circle_particle;
	private Animator mAnimator;
	private Animator circleAnimator;
	public int rNum;
	public GameObject canvas1;
	public Canvas canvas2;
	public GameObject[] forkImgArr;
	public Transform forkTR;
	private bool connect = false;
	private Coroutine myCo;

	void Awake()
	{
		rNum = Random.Range(1,5);
		PlayerPrefs.SetString("dish", rNum.ToString() );
		PlayerPrefs.Save();
		// GetComponent<Image>().sprite = Resources.Load<Sprite>("dish/"+rNum.ToString() );
		
	}
	void Start () {
		
		// Animation ani = GetComponent<Animation>(false);
		mAnimator = GetComponent<Animator>();
		circleAnimator = circle_particle.GetComponent<Animator>();
		// Debug.Log("aaaaaaaa = " + animator.name );
		// animator.enabled = true;
		// ani.Play();
		myCo = StartCoroutine ( shotFork() );
		// AnimatorStateInfo a = aa.GetCurrentAnimatorStateInfo(0);
		
	}

	IEnumerator shotFork() {

		while(true) {
			
			yield return new WaitForSeconds(1.0f);
			for(int i=0; i<5; i++) {
				forkImgArr[i].SetActive(true);
				yield return new WaitForSeconds(1.0f);
			}
			yield return new WaitForSeconds(2.0f);
			for(int i=0; i<5; i++) {
				forkImgArr[i].AddComponent<Rigidbody2D>();
				yield return new WaitForSeconds(0.8f);
				forkImgArr[i].transform.SetParent(forkTR);
				forkImgArr[i].SetActive(false);
			}
	
			yield return new WaitForSeconds(1.0f);

			if(connect) break;
		}
		

		

	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(new Vector3(0f,0f,-1f) );
		
	}
	
	public void receiveConnect() {
		connect = true;
		StopCoroutine ( myCo ); 
		fadeOutFork();
		StartCoroutine( nextScene() );
	}

	 void fadeOutFork() {

		for(int i=0; i<5; i++) {

				if (forkImgArr[i].activeSelf == true) {
					
					forkImgArr[i].GetComponent<TransFork>().showFadeOut();
				}
				
			}
	}

	IEnumerator nextScene() {

		circleAnimator.enabled = true;
		yield return new WaitForSeconds(2.5f);
		mAnimator.enabled = true;
		yield return new WaitForSeconds(4.0f);
		// StartCoroutine( startLoadingScene("Scene/main1") );
		canvas2.gameObject.SetActive(true);
		canvas1.SetActive(false);
		canvas2.sortingOrder = 0;
		// SceneManager.LoadScene("Scene/main1");
		
	}



}
