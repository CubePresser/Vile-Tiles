using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	public Text final_score;
	public Text final_level;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.None;
		final_score.text = "FINAL SCORE: " + ValueClass.final_score;
		final_level.text = "LEVEL REACHED: " + ValueClass.final_level;
	}

	public void Restart()
	{
		SceneManager.LoadScene("Levels");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
