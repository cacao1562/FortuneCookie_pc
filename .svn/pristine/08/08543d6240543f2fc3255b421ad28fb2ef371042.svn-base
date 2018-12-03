using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFork : MonoBehaviour {

	private bool move = true;
	public GameObject forkParent;
	public GameObject plate;
	private Vector3 v3;
	public MovePlate movePlate;
	public Manager manager;
	public int forkNumber;
	
	void Awake()
	{
		v3 = transform.localPosition;
	}
	// void Start () {
	// 	v3 = transform.localPosition;
	// }
	
	// Update is called once per frame
	void Update () {
		
		// if(transform.localPosition.y > 880) {
		// 	transform.localPosition = v3;
		// 	gameObject.SetActive(false);
		// }
	}

	
	void FixedUpdate()
	{
		if(move) {
			
			transform.Translate(Vector3.up * Time.deltaTime * 5);

		}
	}

	
	// void OnCollisionEnter2D(Collision2D other)
	// {
	// 	if ( other.collider.tag == "cookie") {
	// 		Debug.Log("Cookie");
	// 		manager.cookieHit();
	// 		move = false;
	// 		transform.SetParent(plate.transform);
	// 		Destroy(GetComponent<Rigidbody2D>() );
			
	// 	}else if ( other.collider.tag == "plate") {
	// 		Debug.Log("Plate");
	// 		move = false;
	// 		transform.position = v3;
	// 		gameObject.SetActive(false);
	// 		movePlate.resetFork();
	// 		manager.showBroken();
			
	// 		// transform.SetParent(other.gameObject.transform);
	// 		// Destroy(GetComponent<Rigidbody2D>() );
			
	// 	}
	// }

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if ( other.gameObject.tag == "cookie") {

			Debug.Log("hit Cookie");
			manager.hitCookie(forkNumber); //파티클 보여줌
			// manager.cookieHit();
			move = false;
			transform.SetParent(plate.transform);
			Destroy( GetComponent<Rigidbody2D>() );
			
		}else if ( other.gameObject.tag == "plate") {

			Debug.Log("hit Plate");
			manager.hitPlate(forkNumber); //파티클 보여줌
			move = false;
			movePlate.resetFork();
			// manager.showBroken();
			gameObject.SetActive(false);
			// transform.SetParent(other.gameObject.transform);
			// Destroy(GetComponent<Rigidbody2D>() );
			
		}else if( other.gameObject.tag == "prevent") {
			
			Debug.Log("hit Prevent");
			move = false;
			resetPos();
			gameObject.SetActive(false);
		}

	}


	void OnEnable()
	{
		transform.localPosition = v3;
		// transform.rotation = Quaternion.identity;
		transform.localRotation = Quaternion.identity;
		// GetComponent<RectTransform>().rotation = Quaternion.identity;
		move = true;

		// if(GetComponent<Rigidbody2D>()){
		// 	Debug.Log("already Rigidbody2D");
		// }else{
		// 	gameObject.AddComponent<Rigidbody2D>();
		// 	GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		// 	// GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		// 	// GetComponent<Rigidbody2D>().gravityScale = 0f;

		// }
		
		
	}

	public void resetPos(){

		transform.localPosition = v3;
		transform.localRotation = Quaternion.identity;
	}



}
