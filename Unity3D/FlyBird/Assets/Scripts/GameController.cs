using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Image endImage;

	public Text currentPoint;
	public Text bestPoint;

	public GameObject bird;

	void Start () {
//		if (endImage!= null) {
//			endImage.rectTransform.anchoredPosition3D = GameManager.endImageHidePosition;
//		}
		GameManager.isCollide = true;
		restart ();
	}

	void Update () {

		if (GameManager.gameOver) {
			endImage.rectTransform.anchoredPosition3D = GameManager.endImageOriginPosition;
			currentPoint.text = GameManager.point + "";
			bestPoint.text = PlayerPrefs.GetFloat ("bestPoint", 0) + "";
			GameManager.gameOver = false;
		}

		if (!GameManager.restatr && !GameManager.isNormal && GameManager.hasNewBg) {
			GameManager.isNormal = true;
			GameManager.hasNewBg = false;
//			StartCoroutine (setNormal ());
			setNormal ();
		}

	}
		
	public void restart(){

		if (GameManager.isCollide) {
			print ("重新开始");
			GameManager.restatr = true;
			GameManager.isCollide = false;
			GameManager.point = 0;
			GameManager.pointAdd = true;
			GameManager.bgMove = false;

			RigidbodyConstraints originConstraint = bird.GetComponent<Rigidbody> ().constraints;

			bird.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
			bird.transform.position = GameManager.birdOriginPosition;
			bird.transform.rotation = new Quaternion (0, 0, 0, 0);
			bird.GetComponent<Rigidbody> ().useGravity = false;

			bird.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			bird.GetComponent<Rigidbody> ().constraints = originConstraint;

			endImage.rectTransform.anchoredPosition3D = GameManager.endImageHidePosition;
		}
	}

	//IEnumerator
	void setNormal(){

//		yield return new WaitForSeconds(0.01f);
		foreach (Transform subBg in GameManager.newBG.transform) {
			foreach (Transform subPipe in subBg) {
				if (subPipe.name == "pipe0" || subPipe.name == "pipe1") {
					subPipe.gameObject.SetActive (true);
				}
			}
		}

	}
}
