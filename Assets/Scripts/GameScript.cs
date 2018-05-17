using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	public GameObject[] tiles;
	public float frequency; //Seconds between tile switching
	private float start_frequency;
	public int tiles_remaining;
	private int num_tiles;
	private TileScript tile;
	// Use this for initialization
	void Start () {
		tiles = GameObject.FindGameObjectsWithTag("Tile"); //Gets a list of tiles
		tiles_remaining = num_tiles = tiles.Length;
		start_frequency = frequency;
		tile = null;
	}
	
	// Update is called once per frame
	void Update () {
		frequency -= Time.deltaTime;
		if(frequency < 0 && tiles_remaining > 0)
		{
			if(tile != null && tile.status == -5)
			{
				tile.UpdateMaterial(0);
			}
			frequency = start_frequency;
			int depth = 100;
			int rand = Random.Range(0, num_tiles);
			while((tile = tiles[rand].GetComponent<TileScript>()).status != 0 && tiles_remaining > 0) //Performance heavy, need to change
			{
				if(depth == 0)
				{
					tiles_remaining = 0;
					break;
				}
				rand = Random.Range(0, num_tiles); //Gets a tile with default status
				depth--;
			}
			tile.UpdateMaterial(-5);
		}
	}
}
