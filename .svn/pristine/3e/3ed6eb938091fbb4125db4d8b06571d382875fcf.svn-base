using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFadeIn : MonoBehaviour {

	
	private float animTime = 1.5f;
	private float start = 0f;
	private float end = 1f;
	private float time = 0f;
	
	SpriteRenderer sr;
	void Awake()
	{
		
		sr = GetComponent<SpriteRenderer>();

	}
	void Start () {
		
		StartCoroutine( fadeIn() );
	}

	IEnumerator fadeIn() {

		Color color = sr.color;
		time = 0f;
		color.a = Mathf.Lerp(start, end, time);

		while ( color.a < 1f ) {
			
			time += Time.deltaTime / animTime;
			color.a = Mathf.Lerp(start, end, time);
			sr.color = color;

			yield return null;
		}
		
	}

	void OnEnable()
	{
		StartCoroutine( fadeIn() );
	}
	
}
