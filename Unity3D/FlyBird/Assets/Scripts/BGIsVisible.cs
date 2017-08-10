using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGIsVisible : MonoBehaviour {

	public GameObject nextBG;
	private bool haveClone = false;


	void OnBecameInvisible(){
		
		Destroy (transform.parent.gameObject);
	}

	void OnBecameVisible(){

		if (!haveClone) {
			haveClone = true;
			GameObject tempBG = Instantiate (nextBG) as GameObject;
			tempBG.transform.position = transform.parent.position + new Vector3 (6.65f *2f, 0, 0);

			if (!GameManager.isNormal) {
				GameManager.hasNewBg = true;
				GameManager.newBG = tempBG;
			}
		}
	}
}
