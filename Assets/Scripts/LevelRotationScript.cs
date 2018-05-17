using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotationScript : MonoBehaviour {

	public float x_speed;
	public float y_speed;
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * y_speed, Space.World); //Rotate at speed degrees per second
		transform.Rotate(Vector3.right * Time.deltaTime * x_speed);
	}
}
