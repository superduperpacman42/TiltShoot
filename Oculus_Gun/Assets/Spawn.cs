using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject block1; 

	public int worldWidth  = 10;
	public int worldHeight  = 10;

	private float xrand;
	private float yrand;
	private float zrand;

	public float spawnRate;
	private float curTime;
	private float lastTime = 0;


	void  Update () {
		curTime = Time.time;
		if (curTime - lastTime >= spawnRate) {


			xrand = Random.Range (-50f, 50f) / 10f;
			yrand = Random.Range (-50f, 50f) / 10f;
			zrand = Random.Range (-50f, 50f) / 10f;

			GameObject block = Instantiate (block1, new Vector3 (transform.position.x + xrand, transform.position.y + yrand, transform.position.z + zrand), transform.rotation) as GameObject;



			lastTime = curTime;
		}

		//
//
////		for (int y = 0; y < worldWidth; y++) {
//			for (int x = 0; x < worldWidth; x++) {
//
//				for (int z = 0; z < worldHeight; z++) {                
//
//					GameObject block = Instantiate (block1, new Vector3 (transform.position.x + x * .5f, transform.position.y + y * .5f, transform.position.z + z * .5f), transform.rotation) as GameObject;
//				}
//			}
//		}

	}
}
