using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumpadController : MonoBehaviour {

	public DoorController doorController;
	public string password; // password to unlock key
	string answer; // string to concatenate answer
	Vector3 newPos; // new position for RPB upon position change 
	Text[] keys; // array of text containing each key value
	PadController[] padControllers; // array of PadController
	int activeKey = 0; // which pad button is active
	int position = 0; // the position in array padControllers
	bool doInput = false;

	// Use this for initialization
	void Start () {
		keys = GetComponentsInChildren<Text> ();
		padControllers = GetComponentsInChildren<PadController> ();
		int pos = 0;
		foreach (PadController pc in padControllers) {
			pc.setPos (pos);
			pos++;
		}
	}

	// Update is called once per frame
	void Update () {
		if (doInput) {
			if (padControllers [position].getKeyValue ().Equals ("erase") && activeKey > 0) {
				activeKey--;
				keys [activeKey].text = "";
			} else if (padControllers [position].getKeyValue ().Equals ("cancel")) {
				foreach (Text key in keys) {
					key.text = "";
				}
				activeKey = 0;
			} else if (padControllers [position].getKeyValue ().Equals ("check")) {
				foreach (Text key in keys) {
					answer += key.text;
				}
				if (answer.Equals (password)) {
					Debug.Log ("Answer " + answer + " is Correct");
					doorController.unlockDoor ();
				} else {
					Debug.Log ("Answer " + answer + " is Wrong");
				}
				answer = "";
			} else if (activeKey < keys.Length) {
				keys [activeKey].text = padControllers [position].getKeyValue ();
				activeKey++;
			}
			doInput = false;
		}
	}

	//on button click input
	public void inputAnswer(int pos) {
		position = pos;
		doInput = true;
	}
}
