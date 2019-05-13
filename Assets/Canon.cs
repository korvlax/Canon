using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour {
	float canonMass = 10000f;
	float canonSpeed = 50000000f;
	float canonScale = 0.2f;
	// Use this for initialization
	void Start () {
	}	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		if(Input.GetMouseButtonDown(0)){
			GameObject cannonBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			cannonBall.transform.localScale = new Vector3(canonScale, canonScale, canonScale);
			Transform cross = GameObject.Find("Cross").transform;
			cannonBall.transform.position = cross.position;
			cannonBall.AddComponent<Rigidbody>();

			Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
			rb.mass = canonMass;

			

			Camera c = Camera.main;

			Vector3 dir = Vector3.Normalize(cross.position - c.transform.position);
			
			rb.AddForce(dir * canonSpeed);
		}

	}
}
