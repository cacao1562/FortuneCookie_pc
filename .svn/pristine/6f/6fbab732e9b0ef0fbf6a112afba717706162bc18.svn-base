using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransFork : MonoBehaviour {

	private float animTime = 1.5f;
	private float start = 1f;
	private float end = 0f;
	private float time = 0f;

	private Vector3 v3;
	private bool move = true;
	public Transform cookieTR;
	private Rigidbody2D rb2D;
	private Image image;


	void Awake()
	{
		v3 = transform.localPosition;
		
	}
	void Start () {

		image = GetComponent<Image>();
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

		if (move) {

			transform.Translate(Vector3.up * Time.deltaTime * 5);
		}
		
	}


	
	void OnTriggerEnter2D(Collider2D other)
	{
		if ( other.gameObject.tag == "cookie") {

			move = false;
			transform.SetParent(cookieTR);
			Destroy( rb2D );
			
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
			gameObject.AddComponent<Rigidbody2D>();
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			rb2D = GetComponent<Rigidbody2D>();
		// 	// GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		// 	// GetComponent<Rigidbody2D>().gravityScale = 0f;

		// }

	}

	void OnDisable()
	{
		Destroy(GetComponent<Rigidbody2D>());
	}

	public void showFadeOut() {
		StartCoroutine ( fadeOut() );
	}


	IEnumerator fadeOut() {

		Color color = image.color;
		time = 0f;
		color.a = Mathf.Lerp(start, end, time);

		while ( color.a > 0f ) {
			
			time += Time.deltaTime / animTime;
			color.a = Mathf.Lerp(start, end, time);
			image.color = color;

			yield return null;
		}
		
	}
}
