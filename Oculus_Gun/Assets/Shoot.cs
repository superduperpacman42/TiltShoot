using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	// Use this for initialization
	public float fireRate;
	private bool toggle = true;
	private bool doFire = true;
	public GameObject laser;
	private float curTime, lastTime;
	private bool firePressed;
	void Start () {
		lastTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Comms.fire == 0 || Input.GetButton("Fire1")){
			firePressed = true;
		}
		else{
			firePressed = false;
		}


		curTime = Time.time;

		doFire = true;

		if (!toggle && !firePressed) {
			toggle = true;
		}
		if (toggle && firePressed) {
			toggle = false;
			Instantiate (laser, transform.position, transform.rotation);
			doFire = false;
			lastTime = curTime;

		}

		if (firePressed && curTime - lastTime >= fireRate && doFire) {
			Instantiate (laser, transform.position, transform.rotation);
			lastTime = curTime;
		}
			
	}

}
