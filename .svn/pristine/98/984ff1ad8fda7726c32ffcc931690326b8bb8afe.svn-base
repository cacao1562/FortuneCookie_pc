using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	/** 운세 리스트 48개? */
	public List<string> stList = new List<string>();
	/** 오늘의 운세 텍스트 ui*/
	public Text goodText;
	public GameObject plateObj;
	public MovePlate movePlate;
	/** 깨진 접시 이미지 5개 */
	public GameObject[] BrokenArr;
	/** 포크남은 개수 보여주는 이미지 5개 */
	public GameObject[] NumberArr;
	public CombinSocketManager socketManager;
	/** 랜덤으로 뽑은 운세 텍스트 저장해놓고 쿠키맞추면 앱으로 보내줌 */
	private string resultText;
	/** 랜덤 텍스트 넘버 0 ~ 48 */
	private int rNum;
	/** 쿠키 쪼갤때 나타나는 파티클 */ 
	public GameObject particle_cookie;
	/** 쿠키 맞췄을때 파란 파티클 */
	public GameObject[] particle_blue;
	/** 접시 맞첬을때 노란 파티클 */
	public GameObject[] particle_yellow;
	/** 처음 시작할때 화살표 방향 애니메이션 */
	public GameObject particle_arrow;
	/** 뒤에 그냥 검은 배경 */
	public GameObject blackImg;
	/** 텍스트 나오는 팝업 */
	public GameObject ResultPopup;
	public GameObject gameOverPopup;
	/** 손 애니메이션 */
	public GameObject HandObject; 
	public GameObject numberObj;
	public int forkCount;
	/** 쿠키 맞추면 true */
	private bool showCheck = false;
	/** 마지막 포크로 접시 맞추면 true */
	public bool lastFork = false; 
	/** 한번만 보내려고 */
	private bool stopSend = false;
	public GameObject powerSlider;
	

	void Start () {
		
		TextAsset ta = Resources.Load("good3") as TextAsset;
		StringReader sr = new StringReader(ta.text);
		
		while(true) {

			string st = sr.ReadLine();
			
			if(st == null) {
				break;
			}
			stList.Add(st);
			// Debug.Log(st);
		}
		
		rNum = Random.Range(0,stList.Count);
		resultText = stList[rNum];
		goodText.text = stList[rNum];
		
		// StartCoroutine( restartScene() );
	}


	void Update()
	{
		if(showCheck ) {

			gameOverPopup.SetActive(false);

		}else{

			if(stopSend == false) {

				if(forkCount == 0 && (showCheck == false && lastFork) ){
					//GameOver 됨
					
					StartCoroutine( restartGame() );
					stopSend = true;

				}

			}
		
		}
		
	}

	/** 쿠키를 맞춤 */
	public void showText() {  

		// socketManager.gameObject.SetActive(false);
		showCheck = true;
		StartCoroutine( showHand() );

	}
	
	/** 손 애니메이션 파티클 보여주고 텍스트 보여주고 9초후 씬 처음부터 시작 */
	IEnumerator showHand() {

		socketManager.sendResult(resultText); // result 앱에 운세 보내줌
		
		powerSlider.SetActive(false);
		numberObj.SetActive(false);
		plateObj.SetActive(false);
		blackImg.SetActive(true);
		HandObject.SetActive(true);
		
		yield return new WaitForSeconds(1.1f);
		particle_cookie.SetActive(true);
		yield return new WaitForSeconds(2.0f);
		particle_cookie.SetActive(false);
		yield return new WaitForSeconds(1.3f);
		HandObject.SetActive(false);
	
		ResultPopup.SetActive(true);
		yield return new WaitForSeconds(12.0f);
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
		// Destroy( GameObject.Find("FirstSocketManager") );
		// SceneManager.LoadScene("Scene/first");
		// socketManager.sendGameStart();
		// StartCoroutine( restartGame() );
		
	}

	/** 쿠키 못맞추고 게임 오버팝업 보여주고 6초후 씬 처음부터 시작 */
	IEnumerator restartGame() {
		
		yield return new WaitForSeconds(1.0f);
		socketManager.sendGameOver();
		gameOverPopup.SetActive(true);
		yield return new WaitForSeconds(6.0f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
		// Destroy( GameObject.Find("FirstSocketManager") );
		// SceneManager.LoadScene("Scene/first");
		// socketManager.sendGameStart();
		// socketManager.resetGame();

	}

	
	/** pause 소켓 보내주고 깨진 접시 보여줌 */
	public void showBroken() {
		
		socketManager.sendPause();
		// StartCoroutine( showCircleRed() );
		StartCoroutine( fallingPlate() );

	}

	IEnumerator fallingPlate() {

		// movePlate.shakePlate();
		// yield return new WaitForSeconds(1.0f);
		movePlate.gameObject.SetActive(false);
		

		for(int i=0; i < BrokenArr.Length; i++) {

			BrokenArr[i].SetActive(true);

		}

		yield return new WaitForSeconds(1.3f);

		movePlate.gameObject.SetActive(true);
		// socketManager.sendContinue();
	}


	public void hitCookie(int i) {

		StartCoroutine( showCircleBlue(i) );
	}

	public void hitPlate(int i) {

		StartCoroutine( showCircleYellow(i) );
	}


	IEnumerator showCircleBlue(int i) {

		movePlate.shakePlate();
		particle_blue[i].SetActive(true);
		yield return new WaitForSeconds(1.0f);
		particle_blue[i].SetActive(false);

	}

	IEnumerator showCircleYellow(int i) {

		particle_yellow[i].SetActive(true);
		yield return new WaitForSeconds(0.5f);
		particle_yellow[i].SetActive(false);

	}


	public void showArrowParicle(bool b) {

		particle_arrow.SetActive(b);

	}
	
	/** 숫자 이미지 하나씩 숨김 */
	public void hideNumber(int i) {

		NumberArr[i].SetActive(false);
	}
	
	
	
}



// /** 사용 안함 */
// 	public void reset() {

// 		lastFork = false;
// 		showCheck = false;
// 		stopSend = false;
// 		blackImg.SetActive(false);
// 		ResultPopup.SetActive(false);
		
// 		movePlate.resetFork();
// 		movePlate.gameObject.SetActive(false);
// 		movePlate.gameObject.SetActive(true);
// 		showArrowParicle(true);
// 		int r = Random.Range(0,stList.Count);

// 		if(r == rNum) {

// 			int rr = Random.Range(0,stList.Count);
// 			resultText = stList[rr];
// 			goodText.text = stList[rr];
// 			rNum = rr;
// 			return;
// 		}

// 		rNum = r;
// 		resultText = stList[r];
// 		goodText.text = stList[r];
		
		
// 	}