using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneFork : MonoBehaviour {

	// public List<GameObject> forkList = new List<GameObject>();
	public GameObject[] forkArr = new GameObject[5];
	void Start () {
		
	}

	/** 0 번부터 4번까지 해당 포크 날림 */
	public void shootFork(int i) {

		forkArr[i].gameObject.SetActive(true);

	}
	

}
