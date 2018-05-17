using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

	public GameObject[] tiles;
	public float frequency; //Seconds between tile switching
	public int tiles_remaining;
	public int score;
	public Text score_text;
	public Text timer_text;
	private float start_frequency;
	private int num_tiles;
	private TileScript tile;
	private float elapsedTime;
	// Use this for initialization
	void Start () {
		tiles = GameObject.FindGameObjectsWithTag("Tile"); //Gets a list of tiles
		tiles_remaining = num_tiles = tiles.Length;
		start_frequency = frequency;
		tile = null;
		score = 0;
		elapsedTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		timer_text.text = "Time: "  + elapsedTime.ToString("0.00");
		score_text.text = "Score: " + score; //Update score
		frequency -= Time.deltaTime;
		if(frequency < 0 && tiles_remaining > 0)
		{
			if(tile != null && tile.status == -5)
			{
				tile.UpdateMaterial(0);
			}
			frequency = start_frequency; // Reset frequency

			int rand = Random.Range(0, num_tiles);
			while((tile = tiles[rand].GetComponent<TileScript>()).status != 0 && tiles_remaining > 0) //Performance heavy, need to change
			{
				rand = Random.Range(0, num_tiles); //Gets a tile with default status
			}
			tile.UpdateMaterial(-5);
		}
	}
}
