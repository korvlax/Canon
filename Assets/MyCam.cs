using UnityEngine;
using System.Collections;
public class MyCam : MonoBehaviour {
	GameObject player;
	float xSensitivity = 12;
	float ySensitivity = 12;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Mouse X")*12;
		float y = -Input.GetAxis("Mouse Y")*12;

		float angle = transform.eulerAngles.x + y;
		transform.rotation = Quaternion.Euler(angle, transform.eulerAngles.y + x, transform.eulerAngles.z);

		transform.position = player.transform.position;
	}
}
