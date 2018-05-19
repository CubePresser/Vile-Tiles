using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

	public float frequency; //Seconds between tile switching
	public int score;
	public Text score_text;
	public Text timer_text;
	private List<TileScript> tiles;
	private TileScript tile;
	private int tiles_remaining;
	private float start_frequency;
	private float elapsedTime;

	//Removes a tile from the tiles array
	public void remove_tile (TileScript tile_to_remove) {
		tiles.Remove(tile_to_remove);
		tiles_remaining--;
	}

	private void get_tiles()
	{
		GameObject[] tile_objects = GameObject.FindGameObjectsWithTag("Tile"); //Gets an array of tile game objects
		tiles_remaining = tile_objects.Length;
		tiles = new List<TileScript>();
		for(int i = 0; i < tiles_remaining; i++)
		{
			tiles.Add(tile_objects[i].GetComponent<TileScript>());
		}
	}

	void Start () {
		get_tiles();
		start_frequency = frequency;
		tile = null;
		score = 0;
		elapsedTime = 0;
	}
	
	void Update () {
		float seconds = Time.deltaTime; //Used so that we only call Time.deltaTime once
		elapsedTime += seconds;
		frequency -= seconds;

		timer_text.text = "Time: "  + elapsedTime.ToString("0.00");
		score_text.text = "Score: " + score; //Update score

		if(frequency < 0 && tiles_remaining > 0)
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
