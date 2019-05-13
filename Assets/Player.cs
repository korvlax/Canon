using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	Camera cam;
	float speed = 500f;
	float friction = 150;
	float jumpPower = 40f;

	// Use this for initialization111
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 moveVector = new Vector3(0,0,0);
		if (Input.GetKey("d")){
			moveVector += cam.transform.right;
        }
		if (Input.GetKey("a")){
			moveVector += -cam.transform.right;
        }
		if (Input.GetKey("w")){
			moveVector += cam.transform.forward;
        }	
		if (Input.GetKey("s")){
			moveVector += -cam.transform.forward;
        }

		Rigidbody rb = GetComponent<Rigidbody>();
		if (Input.GetKeyDown("space") && Mathf.Abs(rb.velocity.y) < 0.05f){
			moveVector += jumpPower*cam.transform.up;
		}

		rb.AddForce(speed * moveVector);

		Vector3 frictionForce = -friction * Vector3.Normalize(rb.velocity);
		frictionForce.y += -300f;
		rb.AddForce(frictionForce);
		
	}
}
