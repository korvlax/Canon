using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {
	GameObject player;
	//GameObject enemies;
	ArrayList enemies;

	Texture2D mainTex;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		enemies = new ArrayList();
		mainTex = Resources.Load("woodTexture") as Texture2D;
		for(int i = 0; i < 100; i++){
			//spawn sphere
			GameObject brick = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			brick.AddComponent<Rigidbody>();
			brick.GetComponent<Rigidbody>().mass = 40f;

			float scale = 0.02f + i*0.05f;
			Vector3 scaleVector = new Vector3(scale, scale, scale);
			brick.transform.localScale = scaleVector;
			brick.transform.position = new Vector3(0,0,i*scale);

			Renderer rend = brick.GetComponent<Renderer>();
			
			//rend.material.SetTexture("_MainTex", tex);
			rend.material.mainTexture = mainTex;
			
			enemies.Add(brick);
		}
		Debug.Log("Hej");
		Debug.Log(enemies[0]);
		
	
	}
	
	// Update is called once per frame
	void Update () {

		//follow player
		//Console.WriteLine(enemies[0]);
		
		//Rigidbody rb = enemies[0].GetComponent<Rigidbody>();
		for(int i = 0; i < 100; i++){
			GameObject enemy = (GameObject)enemies[i];
			Rigidbody rb = enemy.GetComponent<Rigidbody>();	
			rb.AddForce(200f*Vector3.Normalize(player.transform.position - enemy.transform.position));

			enemy.transform.localScale = new Vector3(enemy.transform.localScale[0],(float)Math.Sin(i),enemy.transform.localScale[2]);
		}
		
	
	}
}
