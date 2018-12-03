using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class firstSocket : MonoBehaviour
{
	private SocketIOComponent socket;
	private string roomNumber = "cookie";  //방 번호
	private JSONObject mobj;
	private bool check = false;
	public moveDish md;
	public GameObject warning;
	public int connectNum = 0;
	private bool firstUser = true;
	public string uuid = "";
	private AsyncOperation ao;

	void Awake()
	{
		// DontDestroyOnLoad(gameObject);
	}
	public void Start() 
	{
		
        Debug.Log("roomNum = "+roomNumber);
	
		socket = GameObject.Find ("SocketIO").GetComponent<SocketIOComponent> ();
		socket.On ("open", OnOpen);
		socket.On ("drawing", OnGetValue);
		socket.On ("error", OnError);
		socket.On ("close", OnClose);
		
	
	}

	public void sendConnect() {

		JsonModel jm = new JsonModel();
		jm.sendStr = "connect";
		jm.result = uuid;
		JSONObject jo = new JSONObject(JsonUtility.ToJson(jm) );
		socket.Emit("send", jo );
	}

	public void sendSuccess() {

		JsonModel jm = new JsonModel();
		jm.sendStr = "success";
		jm.result = md.rNum.ToString();
		JSONObject jo = new JSONObject(JsonUtility.ToJson(jm) );
		socket.Emit("send", jo );
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
			Debug.Log("first user = " + firstUser );
			if ( jm.sendStr == "connect" ){ //모바일에서 접속하면 씬 넘김
				connectNum += 1;
				if (firstUser) {

					Debug.Log("접속 함 " + jm.result);
					uuid = jm.result;
					
					sendConnect();
					check = false;
					firstUser = false;
				}else {
					check = false;
				}
				

			}else if (jm.sendStr == "success") {

				sendSuccess();
				// GetComponent<firstSocket>().enabled = false;
				md.receiveConnect();
				check = false;

			}else if (jm.sendStr == "state") {
			
				StartCoroutine( leaveApp() );
				check = false;

			}
			else{

			}
		}


	}

	IEnumerator leaveApp() {

		warning.SetActive(true);
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
		
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


	private IEnumerator startLoadingScene(string sceneName){
		

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
		async.allowSceneActivation = false;
		while(async.isDone == false){

			if(async.progress >= 0.9f ){

				ao = async;
				break;
			
			}

			// Debug.Log("doing loading" + async.progress * 100f );

		}

		Debug.Log("end loading");

        yield return async;

	}


}


