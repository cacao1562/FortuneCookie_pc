using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventError : MonoBehaviour {

	public Manager manager;
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "gold") {
			Debug.Log("prevent trigger gold fork");
			manager.lastFork = true;
		}
	}

}
