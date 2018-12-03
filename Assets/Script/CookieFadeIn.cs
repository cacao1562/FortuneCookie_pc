using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieFadeIn : MonoBehaviour {

	
	private float animTime = 2.0f;
	private float start = 0f;
	private float end = 1f;
	private float time = 0f;
	// private Color cookieColor;
	private Image img;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		img = GetComponent<Image>();
	}
	



	IEnumerator fadeIn() {

		Color color = img.color;
		time = 0f;
		color.a = Mathf.Lerp(start, end, time);

		while ( color.a < 1f ) {
			
			time += Time.deltaTime / animTime;
			color.a = Mathf.Lerp(start, end, time);
			img.color = color;

			yield return null;
		}
		
	}

	IEnumerator fadeOut() {

		Color color = img.color;
		time = 0f;
		color.a = Mathf.Lerp(1f, 0f, time);

		while ( color.a > 0f ) {
			
			time += Time.deltaTime / animTime;
			color.a = Mathf.Lerp(1f, 0f, time);
			img.color = color;

			yield return null;
		}
		// gameObject.SetActive(false);
	}


	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		StartCoroutine( fadeIn() );
	}



}
