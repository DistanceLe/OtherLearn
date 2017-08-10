using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BGMove : MonoBehaviour {


	public float speed = 1;

	void Start () {
		
	}

	void Update () {

		if (!GameManager.bgMove) {
			return;
		}

		float xOffset = speed * Time.deltaTime;
		this.transform.position += new Vector3 (-xOffset, 0, 0);
	}

}
