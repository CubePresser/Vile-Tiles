using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotationScript : MonoBehaviour {

	public static float x_speed = 0;
	public static float y_speed = 0;

	public void set_speed(float xSpeed, float ySpeed)
	{
		x_speed = xSpeed;
		y_speed = ySpeed;
	}

	// Update is called once per frame
	void Start () {
		if(x_speed == 0 && y_speed == 0)
			enabled = false;
		Debug.Log("x_speed: " + x_speed + " y_speed: " + y_speed);
	}
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * y_speed, Space.World); //Rotate at speed degrees per second
		transform.Rotate(Vector3.right * Time.deltaTime * x_speed);
	}
}
