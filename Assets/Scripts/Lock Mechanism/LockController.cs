using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LockController : MonoBehaviour {

	public KeyCode Left = KeyCode.A;
	public KeyCode Right = KeyCode.D;
	public KeyCode Up = KeyCode.W;
	public KeyCode Down = KeyCode.S;
	public Button checkButton;
	public string password; // password to unlock key
	public float timeBetweenFlicks = 0.5f;
	public static int activeKey = 0; // which key position is active
	string action; // whether to rotate key upwards or downwards
	float timer;
	KeysController[] keysControllers; // array of KeysControllers

	// Use this for initialization
	void Start () {
		keysControllers = GetComponentsInChildren<KeysController> ();
		int pos = activeKey;
		foreach (KeysController kc in keysControllers) {
			kc.setPos (pos);
			if (pos == keysControllers.Length - 1)
				pos = 0;
			else
				pos++;
		}
		checkButton.onClick.AddListener (checkAnswer);
		action = "default";
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeBetweenFlicks && Time.timeScale != 0) {
			if (action.Equals("up")) {
				keysControllers[activeKey].moveUp ();
				timer = 0f;
				action = "default";
			} else if (action.Equals("down")) {
				keysControllers[activeKey].moveDown ();
				timer = 0f;
				action = "default";
			}
		}
	}

	string getKeyCombination() {
		string combination = "";
		foreach (KeysController kcs in keysControllers) {
			combination += kcs.getKeyValue();
		}
		return combination;
	}

	void checkAnswer() {
		if (getKeyCombination ().Equals (password)) {
			Debug.Log ("Answer "+ getKeyCombination()+ " is Correct");
		} else {
			Debug.Log ("Answer "+ getKeyCombination()+ " is Wrong");
		}
	}

	public void setActiveKey(int newVal) {
		activeKey = newVal;
	}

	public void setAction(string act) {
		action = act;
	}
}
