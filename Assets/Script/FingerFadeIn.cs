using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class FingerFadeIn : MonoBehaviour {

	private float animTime = 1.5f;
	private float start = 0f;
	private float end = 1f;
	private float time = 0f;
	SpriteMeshInstance si;
	void Awake()
	{
		
		si = GetComponent<SpriteMeshInstance>();

	}
	void Start () {
		
		StartCoroutine( fadeIn() );
	}

	IEnumerator fadeIn() {

		Color color = si.color;
		time = 0f;
		color.a = Mathf.Lerp(start, end, time);

		while ( color.a < 1f ) {
			
			time += Time.deltaTime / animTime;
			color.a = Mathf.Lerp(start, end, time);
			si.color = color;

			yield return null;
		}
		
	}

	void OnEnable()
	{
		StartCoroutine( fadeIn() );
	}

}
