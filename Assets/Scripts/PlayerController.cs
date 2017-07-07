using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {
	

	public float speed=10.0f;
	private CharacterController controller;
	private float verticalVelocity;
	private float gravity = 14.0f;
	public float jumpForce = 10.0f;
	private string menu="Menu";
	void Start ()
	{
		
		controller = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;


	}

	void Update ()
	{
		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}
		if (controller.isGrounded) {
			verticalVelocity = -gravity * Time.deltaTime;
			if (Input.GetKeyDown (KeyCode.Space)) {
				verticalVelocity = jumpForce;
			}
		} else {
			verticalVelocity -= gravity * Time.deltaTime;
		}
		Vector3 moveVector = Vector3.zero;
		moveVector.x = Input.GetAxis ("Horizontal") * speed;
		moveVector.y = verticalVelocity;
		moveVector.z = Input.GetAxis ("Vertical") * speed;
		moveVector = transform.rotation * moveVector;
		controller.Move (moveVector * Time.deltaTime);


		//if you climb on top you win
		if (gameObject.transform.position.y >= GameObject.Find ("Maze").GetComponent<CreateMaze> ().size * (GameObject.Find ("Maze").GetComponent<CreateMaze> ().L-1) && Input.GetKeyDown(KeyCode.E)) {
			Cursor.lockState = CursorLockMode.None;
			SceneManager.LoadScene(menu);
			Debug.Log("END");
		}
	}
}