 using UnityEngine;
 using System.Collections;
 
 public class CamMove : MonoBehaviour {
	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity=5.0f;
	public float smoothing = 2.0f;

	GameObject character;
	void Start()
	{
		character = this.transform.parent.gameObject;
	}

	void Update()
	{
		var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));
		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1f / smoothing);



		smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1f / smoothing);

		mouseLook += smoothV;
		if(mouseLook.y>-40 && mouseLook.y<60)
					transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		//Character follows the direction of camera(The character is an invisible sphere)
		character.GetComponent<CharacterController>().transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);
	}

    
 }