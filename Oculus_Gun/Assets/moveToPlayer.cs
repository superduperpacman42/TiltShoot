using UnityEngine;
using System.Collections;

public class moveToPlayer : MonoBehaviour {

	Transform target; 
	public float speed;

	// Use this for initialization
	void Start () {
		target = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target, Vector3.up);
		transform.position += transform.forward * speed * Time.deltaTime;
	}
}
