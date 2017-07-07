using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

	CharacterController cont;
	public AudioClip steps;
	// Use this for initialization
	void Start () {
		cont = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(cont.isGrounded==true &&  cont.velocity.magnitude>2.0f && GetComponent<AudioSource>().isPlaying==false)
		{
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = steps;
			audio.volume = Random.Range (0.8f,1);
			audio.volume = Random.Range (0.8f,1);
			audio.Play ();

		}
	}
}
