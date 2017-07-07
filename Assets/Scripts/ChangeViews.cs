using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeViews : MonoBehaviour {

	public GameObject othercam;

	public GameObject Player;


	//Changing the view from fps to topview(different camera).On Top view we can change to sideview and see the maze.
	void Update () {
		if (Input.GetKeyDown(KeyCode.R) && !gameObject.name.Equals ("Player")) 
		{
			//change camera on non fps view
			othercam.SetActive (true);
			gameObject.SetActive (false);

		}
		if (Input.GetKeyDown (KeyCode.V) && gameObject.name.Equals ("Player")) {

			othercam.SetActive (true);
			gameObject.SetActive (false);

		} else if (Input.GetKeyDown (KeyCode.V)) 
		{
			Player.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}
