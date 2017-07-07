using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DestroyCubes : MonoBehaviour
{
	public AudioClip aclip;
	public AudioClip aclip2;
	public Text Hammers;
	public Text HammerLife;
	int hits=0;
	int hammerpoints=100;
	public GameObject destroyed;
	public GameObject Hammer;


	void Start(){
		Hammers.text = "Hammers=" + GameObject.Find ("Maze").GetComponent<CreateMaze> ().K;
		HammerLife.text = "HammerLife=" + hammerpoints;

	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("The cube can be destroyed");
		if (other.gameObject.name.Equals ("hammerInstance(Clone)")) {
			Debug.Log (other.gameObject.name);

			GameObject.Find("Maze").GetComponent<CreateMaze>().K++;

			Hammers.text = "Hammers=" + GameObject.Find ("Maze").GetComponent<CreateMaze> ().K;

			gameObject.transform.GetChild (1).gameObject.SetActive(true);
			Debug.Log (gameObject.transform.GetChild (1).gameObject.name);
			Destroy(other.gameObject);
		}
    }
	void OnTriggerStay(Collider other) {

		if(Input.GetMouseButtonDown(0) && gameObject.transform.GetChild (1).gameObject.activeSelf )
		{
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = aclip;
			audio.PlayOneShot (aclip);
			hits++;
			hammerpoints = hammerpoints - 10;
			HammerLife.text = "HammerLife=" + hammerpoints;

			if(hammerpoints==0)
			{
				if (GameObject.Find("Maze").GetComponent<CreateMaze>().K != 0) {
					GameObject.Find("Maze").GetComponent<CreateMaze>().K--;

					Hammers.text = "Hammers=" + GameObject.Find ("Maze").GetComponent<CreateMaze> ().K;

					if (GameObject.Find ("Maze").GetComponent<CreateMaze> ().K == 0) {
						gameObject.transform.GetChild (1).gameObject.SetActive (false);
						hammerpoints = 0;
						HammerLife.text = "HammerLife=" + hammerpoints;
					} else {
						hammerpoints = 100;
						HammerLife.text = "HammerLife=" + hammerpoints;
					}
				}
			}

			if(hits==3)
			{
				hits = 0;
				GameObject cube = other.gameObject.transform.parent.gameObject;
				audio.clip = aclip2;
				audio.Play();

				Destroy(other.gameObject.transform.parent.gameObject);//katastrofh kubou



				Vector3 vec=cube.transform.position;
				vec.y -= 2.5f;
				//propability of spawning a hammer
				float pith = Random.Range(0.0f, 100.0f);
				if (pith >= 50) {
					GameObject hamobj = Instantiate (Hammer, vec, Quaternion.identity);
					Debug.Log (hamobj.name);
				}

				GameObject obj = Instantiate (destroyed, vec, Quaternion.identity);
				Destroy (obj, 5.0f);
			}
			Debug.Log (hits);
		}

	}
	void OnTriggerExit(Collider other) {
		hits = 0;
	}

}