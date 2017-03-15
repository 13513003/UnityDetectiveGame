using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LockController : MonoBehaviour {

	public KeyCode Left = KeyCode.A;
	public KeyCode Right = KeyCode.D;
	public KeyCode Up = KeyCode.W;
	public KeyCode Down = KeyCode.S;
	public GameObject Arrow;
	public Button checkButton;
	public string password; // password to unlock key
	public float timeBetweenFlicks = 0.5f;
	public static int activeKey = 0; // which key position is active
	string action; // whether to rotate key upwards or downwards
	float timer;
	Vector3 newPos; // new position for Arrow upon activeKey change
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
			/*if (Input.GetKey (Left)) {
				if (activeKey > 0) {
					activeKey -= 1;
					newPos = new Vector3( keysControllers [activeKey].gameObject.transform.position.x, Arrow.transform.position.y );
					Arrow.transform.position = newPos;
				}
				Debug.Log (activeKey);
				timer = 0f;
			}
			if (Input.GetKey (Right)) {
				if (activeKey < keysControllers.Length-1) {
					activeKey += 1;
					newPos = new Vector3( keysControllers [activeKey].gameObject.transform.position.x, Arrow.transform.position.y );
					Arrow.transform.position = newPos;
				}
				Debug.Log (activeKey);
				timer = 0f;
			}
			if (Input.GetKey (Up)) {
				keysControllers[activeKey].moveUp ();
				timer = 0f;
				action = "default";
			}
			if (Input.GetKey (Down)) {
				keysControllers[activeKey].moveDown ();
				timer = 0f;
				action = "default";
			}*/

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

	public void setArrowPosition(float newX) {
		newPos = new Vector3( newX, Arrow.transform.position.y );
		Arrow.transform.position = newPos;
	}
}
