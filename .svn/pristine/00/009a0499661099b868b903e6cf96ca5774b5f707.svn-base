using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBroken : MonoBehaviour {

	private Vector3 v3;
	void Start () {
		
		v3 = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
		// transform.Rotate(new Vector3(-0.1f,0f,0f) );
		transform.Rotate(new Vector3(0f,-1.8f,0f) );
		transform.Translate(Vector3.down * Time.deltaTime * 2.5f);

		if( transform.localPosition.y < -550 ) {

			transform.localPosition = v3;
			gameObject.SetActive(false);
		}
		
	}


}
