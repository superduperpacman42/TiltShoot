using UnityEngine;
using System.Collections;

public class chase_Player : MonoBehaviour {

	// Use this for initialization
	private Transform target; 
	public float speed;
	private bool move = true;
	void Start () {
		speed = speed *Random.Range(75f, 125f)/100f;
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (move) {
			transform.LookAt (target, Vector3.up);
			GetComponent<Rigidbody> ().velocity = transform.forward * speed ;
		}
	}

	void OnCollisionEnter(Collision collision) {
	{
		//	print (collision.gameObject.tag);
			if (collision.gameObject.CompareTag("Laser"))
		{
				move = false;
				//print ("got");
			}
		
	}

}
}
