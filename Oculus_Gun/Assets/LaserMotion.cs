using UnityEngine;
using System.Collections;

public class LaserMotion : MonoBehaviour {

	// Use this for initialization
	public float MovSpeed;
	void Start () {
		Destroy (gameObject, 20f);
		//rigidbody.velocity = new Vector3
		//GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + new Vector3(0f,0f,-MovSpeed);
		GetComponent<Rigidbody>().velocity += transform.up * -MovSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
