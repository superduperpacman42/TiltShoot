using UnityEngine;
using System.Collections;

public class MatchT : MonoBehaviour {
	
	public Transform loc;

	void Update () {
		transform.localEulerAngles = new Vector3 (-loc.localEulerAngles.x,-loc.localEulerAngles.y, -loc.localEulerAngles.z);
		//transform.localEulerAngles = new Vector3(0,0,0);
	}
}
