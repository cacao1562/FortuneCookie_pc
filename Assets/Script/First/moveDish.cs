using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class moveDish : MonoBehaviour {

	// Use this for initialization
	public GameObject circle_particle;
	private Animator mAnimator;
	private Animator circleAnimator;
	public int rNum;
	private AsyncOperation ao;
	public GameObject canvas1;
	public Canvas canvas2;
	void Awake()
	{
		rNum = Random.Range(1,5);
		PlayerPrefs.SetString("dish", rNum.ToString() );
		PlayerPrefs.Save();
		GetComponent<Image>().sprite = Resources.Load<Sprite>("dish/"+rNum.ToString() );
		
	}
	void Start () {
		
		// Animation ani = GetComponent<Animation>(false);
		mAnimator = GetComponent<Animator>();
		circleAnimator = circle_particle.GetComponent<Animator>();
		// Debug.Log("aaaaaaaa = " + animator.name );
		// animator.enabled = true;
		// ani.Play();
		
		// AnimatorStateInfo a = aa.GetCurrentAnimatorStateInfo(0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(new Vector3(0f,0f,-1f) );
	}

	public void receiveConnect() {

		StartCoroutine( nextScene() );
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


	private IEnumerator startLoadingScene(string sceneName){
		

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
		async.allowSceneActivation = false;
		while(async.isDone == false){

			if(async.progress >= 0.9f ){

				async.allowSceneActivation = true;
				// ao = async;
				// break;
			
			}

			// Debug.Log("doing loading" + async.progress * 100f );

		}

		Debug.Log("end loading");

        yield return null;

	}

}
