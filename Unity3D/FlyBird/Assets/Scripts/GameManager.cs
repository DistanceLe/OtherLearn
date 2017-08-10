using System;
using UnityEngine;

public static class GameManager{

	public static bool isCollide = false;
	public static bool pointAdd = false;
	public static bool gameOver = false;
	public static bool bgMove = false;
	public static bool restatr = false;
	public static bool isNormal = true;
	public static bool hasNewBg = false;
	public static int  point = 0;

	public static GameObject newBG;

	public static Vector3 birdOriginPosition = new Vector3(-1, 0.69f, -5.87f);
	public static Vector3 endImageOriginPosition = new Vector3(22, 18, 0);
	public static Vector3 endImageHidePosition = new Vector3(1000, -20, 0);

}


