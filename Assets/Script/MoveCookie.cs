using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCookie : MonoBehaviour {

	public GameObject plate;
	public Manager manager;
	// public Transform forkParent;
	private int forkCount = 0;
	public bool check = true;

	
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(forkCount == 2 && check) {

			manager.showText();
			check = false;

		}
		
		// if(transform.childCount == 2) {

		// 	// Debug.Log("count = " + transform.childCount );

		
		// 	for(int i=0; i<2; i++) {
		// 		transform.GetChild(0).transform.SetParent(forkParent.transform);
		// 	}
			
		// 	// plate.SetActive(false);
		// 	manager.showText();
			
		// 	// gameObject.SetActive(false);
		// 	Debug.Log("Booooooooob");
		// }

	}



	void OnEnable()
	{
		forkCount = 0;
		check = true;

		// for(int i=0; i < transform.childCount; i++){
		// 	transform.SetParent(forkParent);
		// 	transform.GetChild(i).gameObject.SetActive(false);
		// }

	}
	void OnDisable()
	{
		forkCount = 0;
		// Debug.Log("MMMMMMMMMMMM");	
		// for(int i=0; i < transform.childCount; i++) {
		// 		transform.GetChild(0).transform.SetParent(forkParent.transform);
		// }
		
	}


	// void OnCollisionEnter2D(Collision2D other)
	// {

	// 	if(other.collider.tag == "fork") {

	// 		forkCount += 1;

	// 	}else if(other.collider.tag == "gold") {

	// 		forkCount = 2;
	// 	}

	// }


	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "fork") {

			forkCount += 1;

		}else if(other.gameObject.tag == "gold") {
			
			// manager.lastFork = false;
			forkCount = 2;
		}
	}

}
