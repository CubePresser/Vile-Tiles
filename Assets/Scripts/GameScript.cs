using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {

	private static float frequency = 2.0f; //Seconds between tile switching
	private static float time_limit = 30.0f;
	private static int level = 1;
	private static bool game_restart = false;
	public Text score_text;
	public Text timer_text;
	public Text level_text;
	public LevelRotationScript lrs;
	private static int score = 0;
	private List<TileScript> tiles;
	private TileScript tile;
	private int tiles_remaining;
	private float start_frequency;
	private float current_time_limit;

	public void Add_Score(int value)
	{
		score += value;
		if(value > 0)
			frequency = 0;
	}

	//Removes a tile from the tiles array
	public void Remove_Tile (TileScript tile_to_remove) {
		tiles.Remove(tile_to_remove);
		tiles_remaining--;
	}

	private void Get_Tiles()
	{
		GameObject[] tile_objects = GameObject.FindGameObjectsWithTag("Tile"); //Gets an array of tile game objects
		tiles_remaining = tile_objects.Length;
		tiles = new List<TileScript>();
		for(int i = 0; i < tiles_remaining; i++)
		{
			tiles.Add(tile_objects[i].GetComponent<TileScript>());
		}
	}

	private void set_new_rotation()
	{
		//Randomizes the rotation speeds on the x and y axis by a random value between 0 and the current level
		lrs.set_speed(Random.Range(0, level + 1), Random.Range(0, level + 1));
	}

	private void Next_Level()
	{
		set_new_rotation();
		frequency = start_frequency - 0.05f;
		time_limit = current_time_limit - 0.05f;
		level++;
		SceneManager.LoadScene("Levels");
		return;
	}

	private void Game_Over()
	{
		ValueClass.final_level = level;
		ValueClass.final_score = score;

		game_restart = true;

		SceneManager.LoadScene("GameOver");
		return;
	}

	void Start () {
		lrs = GameObject.FindGameObjectWithTag("Tile-Field").GetComponent<LevelRotationScript>();	
		if(game_restart)
		{
			frequency  = 2.0f;
			time_limit = 30.0f;
			score = 0;
			game_restart = false;
			lrs.set_speed(0, 0);
		}

		Get_Tiles();
		
		start_frequency = frequency;
		tile = null;
		current_time_limit = time_limit;
		level_text.text = "Level: " + level;
	}
	
	void Update () {
		float seconds = Time.deltaTime; //Used so that we only call Time.deltaTime once
		time_limit -= seconds;
		frequency -= seconds;

		//Temporary escape key
		if(Input.GetKey("escape"))
		{
			Application.Quit();
		}

		timer_text.text = "Time: "  + time_limit.ToString("0.00");
		score_text.text = "Score: " + score; //Update score

		if(tiles_remaining == 0) //Proceed to next level
		{
			Next_Level();
		}

		if(time_limit < 0)
		{
			Game_Over();
		}

		if(frequency < 0)
		{
			frequency = start_frequency; // Reset frequency
			if(tile != null && tile.status == -5) //Set the previous tile to the default material if it is not the first tile
			{
				tile.UpdateMaterial(0); //Reset the tile to default material (Deselection)
			}
			tile = tiles[Random.Range(0, tiles_remaining)]; //Get a random tile in the list of remaining tiles to set
			tile.UpdateMaterial(-5); //Update the tile to selected material
		}
	}
}
