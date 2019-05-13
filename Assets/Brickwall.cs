using UnityEngine;
using System.Collections;
public class Brickwall : MonoBehaviour {
	// Use this for initialization
	Texture2D mainTex;
	void Start () {
		//createCube();
		mainTex = Resources.Load("woodTexture") as Texture2D;
		//Debug.Log(mainTex);

		/*
		System.Random rnd = new System.Random(100);
		for(int i = 0 ; i < 2 ; i++){
			for(int j = 0 ; j < 5 ; j++){
				//createPyramideAt(new Vector3(20*j, 0, 20*i));
				//createCubeAt(new Vector3(20*j, 0, 20*i + 10));
				float x = rnd.Next(50);
				float z = rnd.Next(50);
				createPyramideAt(new Vector3(x, 0, z));

				x = rnd.Next(50);
				z = rnd.Next(50);
				createCubeAt(new Vector3(x, 0, z + 10));
			}
		}
			
		
		int[] dirs = new int[4];
		for(int i = 0; i < 4 ; i++){
			dirs[i] = 90*i;
		}


		Vector3 prevPos = new Vector3(0,0,0);
		System.Random rnd = new System.Random();
		for(int i = 0 ; i < 100 ; i++){
			int index = rnd.Next(4);
			createCubeAt(prevPos + new Vector3(10,0,0), dirs[index]);
			prevPos = prevPos + new Vector3(10,0,0);
		}
		*/

		//createCubeAt(new Vector3(0,0,0), 0);
		//createCubeAt(new Vector3(0,0,40), 90f);

		createPyramideAt(new Vector3(0,0,0));



	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void createPyramideAt(Vector3 pos){
		float scale = 5f;
		Vector3 scaleVector = new Vector3(scale, scale, scale);

		float xbricks = 10;
		float zbricks = 1;

		ArrayList bricks = new ArrayList();
		
		for(int i = 0 ; i < xbricks ; i++){
			for(int j = -i ; j <= i ; j++){
				for(int k = 0 ; k < zbricks ; k++){
					GameObject brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
					brick.AddComponent<Rigidbody>();
					brick.GetComponent<Rigidbody>().mass = 5f;
					brick.transform.localScale = scaleVector;
					float gap = (xbricks-i)*scale/xbricks;
					float step = scale;

					//float x = (step+gap)*j;
					float x = step*j;
					float y = step*(i - Mathf.Abs(j)) + (scale)/2f;
					float z = step*k;
					brick.transform.position = pos + new Vector3(x,y,z);

					Renderer rend = brick.GetComponent<Renderer>();
					
					//rend.material.SetTexture("_MainTex", tex);
					rend.material.mainTexture = mainTex;
					//Debug.Log(rend.material);

					bricks.Add(brick);
				}
			}
		}
	}
	
/*
2   o   x	o

1	x	o	x

0	o	x   o

	0	1	2
*/
	void createCubeAt(Vector3 pos, float direction){
		float step = 1.0f;
		float xbricks = 10;
		float ybricks = 1;
		float zbricks = 1;

		GameObject parentObj = new GameObject();
		
		Vector3 scale = step * Vector3.one;
		for(int i = 0 ; i < xbricks ; i++){
			for(int j = 0 ; j < ybricks ; j++){
				for(int k = 0 ; k < zbricks ; k++){
					GameObject brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
					//brick.AddComponent<Rigidbody>();
					brick.transform.localScale = scale;
					float x = i * step;
					float y = j * step + step/2f;//move it so its on the platform, not inside it...
					float z = k * step;
					brick.transform.position = pos + new Vector3(x,y,z);

					brick.transform.parent = parentObj.transform;

				}
			}
		}
		parentObj.transform.Rotate(0,direction,0);

		
	}



}
