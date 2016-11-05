using UnityEngine;
using System.Collections;

public class WorldSpawn : MonoBehaviour {
	
	public GameObject block1; 

	public int worldWidth  = 10;
	public int worldHeight  = 10;
	public float size = .25f;

	void  Start () {
		for (int y = 0; y < worldWidth; y++) {
			for (int x = 0; x < worldWidth; x++) {

				for (int z = 0; z < worldHeight; z++) {                

					GameObject block = Instantiate (block1, new Vector3 (transform.position.x + x * size, transform.position.y + y * size, transform.position.z + z * size), transform.rotation) as GameObject;
								}
			}
		}

	}
	 }
