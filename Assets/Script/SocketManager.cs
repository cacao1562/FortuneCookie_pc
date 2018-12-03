using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SocketManager : MonoBehaviour
{
	private SocketIOComponent socket;
	private string roomNumber = "cookie";  //방 번호
	private JSONObject mobj;
	/** 소켓 데이터 들어왔을때 true */
	private bool check = false;
	/** shoot 소켓들어왔을때 +1 */
	private int receiveNum = 0;
	private int forkNum = 5;
	/** 여기서 포크 이미지 켜줌 */
	public CloneFork cloneFork;
	public Manager manager;
	/** warning 팝업 */
	public GameObject warningPopup;


	public void Start() 
	{
		
        Debug.Log("roomNum = "+roomNumber);
	
		socket = GameObject.Find ("SocketIO").GetComponent<SocketIOComponent> ();
		socket.On ("open", OnOpen);
		socket.On ("drawing", OnGetValue);
		socket.On ("error", OnError);
		socket.On ("close", OnClose);
		
	}

	/** 접시가 깨졌을때 모바일 포크버튼 못누르도록 disable */
	public void sendPause() {

		JsonModel jm = new JsonModel();
		jm.sendStr = "pause";
		JSONObject jo = new JSONObject(JsonUtility.ToJson(jm) );
		socket.Emit("send", jo );
	}

	/** 접시가 깨지고 다시 나타났을때 모바일 포크버튼 enable */
	public void sendContinue() {

		JsonModel jm = new JsonModel();
		jm.sendStr = "continue";
		JSONObject jo = new JSONObject(JsonUtility.ToJson(jm) );
		socket.Emit("send", jo );
	}
	
	/** 쿠키를 맞췄을때 모바일에도 텍스트 보여주는 씬으로 넘어감 */
	public void sendResult(string result) {

		JsonModel jm = new JsonModel();
		jm.sendStr = "result";
		jm.result = result;
		JSONObject jo = new JSONObject(JsonUtility.ToJson(jm) );
		socket.Emit("send", jo );
	}

	/** 쿠키를 하나도 못 맞췄을때 모바일에 팝업이 나타남 */
	public void sendGameOver() {

		JsonModel jm = new JsonModel();
		jm.sendStr = "gameOver";
		JSONObject jo = new JSONObject(JsonUtility.ToJson(jm) );
		socket.Emit("send", jo);
		
	}

	/** 쿠키를 맞추거나 게임오버 되고 다시 게임 시작할때 모바일도 씬 재시작 */
	public void sendGameStart() {

		JsonModel jm = new JsonModel();
		jm.sendStr = "gameStart";
		JSONObject jo = new JSONObject(JsonUtility.ToJson(jm) );
		socket.Emit("send", jo);
		
	}

	

	void Update()
	{

		if(!socket.IsConnected){
			Debug.Log("소켓 연결 안됨");
			return;
		}
		if(mobj == null){
			return;
		}

		if(mobj.Count <= 0){
			return;
		}

		if (check) {

			JsonModel jm = JsonUtility.FromJson<JsonModel>(mobj.ToString());

			if ( jm.sendStr == "shoot" ){

				if(receiveNum > 4) {

					Debug.Log("shoot end");
					return;
				}

				manager.hideNumber(forkNum); //왼쪽 아래 숫자 이미지 하나씩 숨김
				cloneFork.shootFork(receiveNum); // 0번부터 포크 하나씩 켜줌
				receiveNum += 1;
				forkNum -= 1;

				if (forkNum == 4 ) {

					manager.showArrowParicle(false); // 한 발 날리면 화살표 숨김

				}

				if(forkNum == 0) {
				
					manager.forkCount = 0;
				}

				check = false;

			}else if (jm.sendStr == "state") { //앱에서 홈키,메뉴,화면 종료했을때 

				StartCoroutine( leaveApp() );
				check = false; 
			} 
  
		}else{

		}


	}

	/** 게임중간에 홈키, 메뉴, 화면 껐을때 씬 처음부터 다시 시작 */
	IEnumerator leaveApp() {

		warningPopup.SetActive(true);
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene("Scene/first");

	}

	public void OnOpen(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open(): " + e.data);
	
		socket.Emit("joinRoom", JSONObject.StringObject(roomNumber)); //방번호
			
	}
	
	public void OnGetValue(SocketIOEvent e)
	{
		Debug.Log("get_Value: " + e.data);
		
		if (e.data == null) { return; }
		mobj = e.data; 
		check = true;
		//mTextListManager.AddItem (e.data.GetField ("UserText").str);
		
	}
	
	public void OnError(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Error(): " + e.data);
	}
	
	public void OnClose(SocketIOEvent e)
	{	
		Debug.Log("[SocketIO] Close(): " + e.data);
	}


}


