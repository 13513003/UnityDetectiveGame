using UnityEngine;
using System.Collections;

public class PadController : MonoBehaviour {

	public string keyValue;
	NumpadController numPadController;
	int position;

	// Use this for initialization
	void Start () {
		numPadController = GetComponentInParent<NumpadController> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public string getKeyValue() {
		return keyValue;
	}

	public void setPos(int newPos) {
		position = newPos;
	}

	public void onClick() { // use this for VR interaction
		numPadController.inputAnswer (position);
	}
}
