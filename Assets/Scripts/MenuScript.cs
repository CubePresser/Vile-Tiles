using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void Start_Game()
	{
		SceneManager.LoadScene("Levels");
	}

	public void Leaderboard()
	{
		return;
	}

	public void Exit_Game()
	{
		Application.Quit();
	}
}
