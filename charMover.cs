using UnityEngine;
using System.Collections;

public class charMover : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//get normalized forward vector on movement axes only
		Vector3 xzForward = new Vector3 (transform.GetChild(0).forward.x, 0, transform.GetChild(0).forward.z);
		xzForward.Normalize ();
		Vector3 xzRight = new Vector3 (transform.GetChild(0).right.x, 0, transform.GetChild(0).right.z);
		xzRight.Normalize ();

		Debug.DrawRay (transform.position, xzForward);
		Debug.DrawRay (transform.position, xzRight);

		//move on axes from prior modified forward vector
		transform.position += (xzRight * Input.GetAxis("Horizontal") * Time.deltaTime * speed) + (xzForward * Input.GetAxis("Vertical") * Time.deltaTime * speed);
	}
}
