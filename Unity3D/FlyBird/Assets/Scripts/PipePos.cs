using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePos : MonoBehaviour {


	void Start () {

		resetPosY ();
	}

	public void resetPosY(){
		float posY = 0f;
		posY = Random.Range (-0.16f, 0.2f);

		Vector3 originPos = this.transform.localPosition;
		originPos.y = posY;
		this.transform.localPosition = originPos;
	}


	private float offsetX = 1;
	private bool hasPass = false;


	void Update(){

		offsetX = transform.position.x;
		if (offsetX < -1 && !hasPass) {
			hasPass = true;
			GameManager.pointAdd = true;
			GameManager.point++;

			print (GameManager.point);
		}

		if (!GameManager.bgMove && GameManager.restatr) {
			if (offsetX > -5 && offsetX < 3) {
				gameObject.SetActive (false);
			}
			GameManager.isNormal = false;
		}
	}

}
