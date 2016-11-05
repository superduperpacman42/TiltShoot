using UnityEngine;
using System.Collections;
using System.IO.Ports;


public class Comms : MonoBehaviour {
	
	public Transform loc;

	public static int fire;
	public ArduinoConnector ard;// = new ArduinoConnector();
	public Vector3 gunAngle;
	private string input;

	void Awake()
	{
		ard.Open ();


	}

	void Update(){

		input = ard.ReadFromArduino (200);

		if (input == null)
			return;

		string[] output = input.Split (new string[] {","}, System.StringSplitOptions.None);

		//print (output[0] +", "+ output[1] +", "+ output[2] +", "+ output[3]);


		gunAngle = new Vector3(GetFloat(output[0],0f),GetFloat(output[1],0f),GetFloat(output[2],0f));

		transform.localEulerAngles = new Vector3 ( -gunAngle.x - loc.localEulerAngles.x, -gunAngle.z,+ loc.localEulerAngles.z);

		print (gunAngle);


		fire = Mathf.FloorToInt( GetFloat (output [3], 0f));

		print (fire);
	}

	private float GetFloat(string stringValue, float defaultValue)
	{
		float result = defaultValue;
		float.TryParse(stringValue, out result);
		return result;
	}
}
		