using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlate : MonoBehaviour {

	public GameObject[] cookieArr;
	public Transform forkTr;
	public GameObject[] forkArr;
	public Manager manager;
	// public SocketManager socketManager;
	private int rotateNum = 0;
	// public int sendcheck = 0;
	private int[] randArr;
	private Sprite[] spArr;
	public Image[] brokenImg;

	void Awake()
	{
		string dishNum = PlayerPrefs.GetString("dish", "1");
		GetComponent<Image>().sprite = Resources.Load<Sprite>("dish/" + dishNum );
		spArr = Resources.LoadAll<Sprite>( dishNum );

		for(int i=0; i < 5; i++ ){

			brokenImg[i].sprite = spArr[i];
		}

	}
	
	
	// Update is called once per frame
	void Update () {
		
		if(rotateNum == 0) {
			
			Vector3 v3 = new Vector3(0f,0f,-1f);
			Vector3 vv = v3 * Time.deltaTime * 100; 
			transform.Rotate( vv );

		}
		

	}

	/** 중복 없는 난수 생성 */
	private int[] getRandomInt(int length, int min, int max) {

		int[] randArray = new int[length];
		bool isSame;

		for (int i=0; i<length; ++i) {

			while(true) {

				randArray[i] = Random.Range(min, max);
				isSame = false;

				for (int j=0; j<i; ++j) {

					if (randArray[j] == randArray[i]) {
						isSame = true;
						break;
					}
				}

				if (!isSame) break;
			}
		}

		return randArray;
	}

	
	void OnEnable()
	{

		// sendcheck = 0;
		randArr = getRandomInt(5, 0, 15);  // 0 ~ 14 에서 랜덤 5개
		
		for(int i=0; i<randArr.Length; i++) {
		
			cookieArr[randArr[i]].SetActive(true);
		
		}

	}

	
	void OnDisable()
	{

		MoveCookie[] mc = transform.GetComponentsInChildren<MoveCookie>();
		

		for(int i=0; i<mc.Length; i++) {

			mc[i].gameObject.SetActive(false);
		}
		// for(int i=0; i < transform.childCount; i++){
			
		// 	transform.GetChild(i).gameObject.SetActive(false);
		// }	
	}


	public void resetFork() {

		MoveFork[] mf = transform.GetComponentsInChildren<MoveFork>();

		for(int i=0; i<mf.Length; i++) {

			mf[i].transform.SetParent(forkTr);
			mf[i].resetPos();
			mf[i].gameObject.SetActive(false);
			
		}

		manager.showBroken();

	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "gold") {

			Debug.Log("plate trigger gold fork");
			manager.lastFork = true;

		}
	}

	
	public void shakePlate() {

		StartCoroutine( Shake(10.0f, 0.8f) );

	}
	public IEnumerator Shake(float _amount,float _duration)	
	{
    	float timer=0;
    	while(timer <= _duration)
    	{	
        	transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + transform.localPosition;
 
 	       timer += Time.deltaTime;
    	    yield return null;
    	}
    	transform.localPosition = transform.localPosition;
 
	}

	
	

}
