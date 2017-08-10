using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdFly : MonoBehaviour {

	public Sprite[] birdFrame = new Sprite[3] ;
	public float speed = 1.0f;
	public AudioClip dieAudio;
	public AudioClip hitAudio;
	public AudioClip wingAudio;
	public AudioClip pointAudio;
	public AudioClip swooshingAudio;

	public Text pointText;

	private float secondTime = 0f;
	private int indexFrame = 0;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.isCollide) {
			return;
		}

		if (GameManager.pointAdd) {
			GameManager.pointAdd = false;
			pointText.text = "分数: " + GameManager.point;
			if (GameManager.point > 0) {
				GetComponent <AudioSource>().PlayOneShot (pointAudio);
			}
		}

		secondTime += Time.deltaTime;

		if(secondTime >= 1/speed){
			secondTime = 0;
			indexFrame++;

			GetComponent <SpriteRenderer> ().sprite = birdFrame [indexFrame % 3];
		}    

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)) {
			if (!GetComponent<Rigidbody> ().useGravity) {
				GetComponent<Rigidbody> ().useGravity = true;
				GameManager.bgMove = true;
				GameManager.restatr = false;
				GetComponent <AudioSource>().PlayOneShot (swooshingAudio);
				return;
			}

			GetComponent<Rigidbody>().velocity = new Vector3(0, 4, 0);
			GetComponent <AudioSource>().PlayOneShot (wingAudio);
		} 
	}

	void OnCollisionEnter(Collision collision){
		print ("...碰到了。。。");
		if (GameManager.isCollide) {
			return;
		}
		GameManager.bgMove = false;
		GameManager.isCollide = true;
		GameManager.gameOver = true;

		float bestPoint = PlayerPrefs.GetFloat ("bestPoint", 0);
		bestPoint = GameManager.point > bestPoint ? GameManager.point : bestPoint;
		PlayerPrefs.SetFloat ("bestPoint", bestPoint);

		StartCoroutine (playAudio ());

		GetComponent<Rigidbody>().velocity = new Vector3(3, 0, 0);

	}

	IEnumerator playAudio(){

		GetComponent <AudioSource>().PlayOneShot (hitAudio);
		yield return new WaitForSeconds(0.4f);
		GetComponent <AudioSource>().PlayOneShot (dieAudio);

	}



}
