using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

	public Material default_material, hit_material, missed_material, selected_material;
	public GameScript game_script;
	public int status; // 0 default, 1 hit, -1 missed, -5 = selected
	private Renderer t_renderer;
	private bool inTrigger;

	public void UpdateMaterial (int value) {
		switch(value) {
			case 0:
				t_renderer.material = default_material;
				break;
			case 1:
				t_renderer.material = hit_material;
				game_script.remove_tile(this);
				game_script.score++;
				break;
			case -1:
				t_renderer.material = missed_material;
				if(status == 0)
				{
					game_script.remove_tile(this);
				}
				game_script.score--;
				break;
			case -5:
				t_renderer.material = selected_material;
				break;
		}
		status = value;
	}

	// Use this for initialization
	void Start () {
		t_renderer = GetComponent<Renderer>();
		status = 0; //Default status 
	}
	private void OnTriggerEnter() {
		inTrigger = true;
	}
	private void OnTriggerExit () {
		inTrigger = false;
	}
	private void Update () {
		if(Input.GetButtonDown("Select") && inTrigger)
		{
			if(status == -5)
			{
				UpdateMaterial(1);
			} 
			else
			{
				UpdateMaterial(-1);
			}
		}
	}
}
