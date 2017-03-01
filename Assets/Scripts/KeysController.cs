using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class KeysController : MonoBehaviour {

	public string keysValuesString;
	public Transform topSpawnPoint;
	public Transform bottomSpawnPoint;
	public Button buttonUp;
	public Button buttonDown;
	public GameObject keyPrefab; // prefab for new keys
	int newPosition; // position for new summoned key
	int position; // position of KeysController from the left
	GameObject newKey; // new generated key
	string[] keysValuesArr; // array of key values
	KeyController[] keyControllers; // array of KeyController
	List<KeyController> keyList; // list of KeyController

	// Use this for initialization
	void Start () {
		keyControllers = GetComponentsInChildren<KeyController> ();
		keyList = keyControllers.ToList();
		keysValuesArr = keysValuesString.Split (',');
		buttonUp.onClick.AddListener (upButtonClick);
		buttonDown.onClick.AddListener (downButtonClick);
		string firstValue = keyControllers[0].GetComponentInChildren<Text>().text;
		int i = 0;
		int pos = 0;
		while (i < keysValuesArr.Length) {
			if (keysValuesArr[i].Equals(firstValue)) {
				pos = i;
				break;
			}
			i++;
		}

		foreach (KeyController kc in keyControllers) {
			kc.setPos (pos);
			if (pos == keysValuesArr.Length - 1)
				pos = 0;
			else
				pos++;
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public string getKeyValue() {
		return keyList [2].getValue();
	}

	public void setPos(int pos) {
		position = pos;
	}

	public void moveUp() {
		newPosition = keyList[0].GetComponentInChildren<KeyController>().getPos();
		if (newPosition == 0)
			newPosition = keysValuesArr.Length - 1;
		else
			newPosition--;
		spawnKey (bottomSpawnPoint.position, bottomSpawnPoint.rotation, newPosition, "up");
		DestroyObject (keyList[keyList.Count - 1].gameObject, 0.1f);
		keyList.Remove (keyList [keyList.Count - 1]);
		foreach (KeyController kc in keyList) {
			kc.moveUp ();
		}
	}

	public void moveDown() {
		newPosition = keyList[keyList.Count - 1].GetComponentInChildren<KeyController>().getPos();
		if (newPosition == keysValuesArr.Length - 1)
			newPosition = 0;
		else
			newPosition++;
		spawnKey (topSpawnPoint.position, topSpawnPoint.rotation, newPosition, "down");
		DestroyObject (keyList[0].gameObject, 0.1f);
		keyList.Remove (keyList[0]);
		foreach (KeyController kc in keyList) {
			kc.moveDown ();
		}
	}

	public void spawnKey(Vector3 position, Quaternion rotation, int pos, string moveDirection) {
		GameObject newKey = Instantiate (keyPrefab, position , rotation) as GameObject;
		newKey.transform.SetParent(this.gameObject.transform);
		KeyController kc = newKey.GetComponent<KeyController> ();
		kc.setPos (pos);
		kc.setVal (keysValuesArr [pos]);
		newKey.GetComponentInChildren<Text> ().text = keysValuesArr[pos];
		if (moveDirection.Equals ("up")) {
			keyList.Insert (0, kc);
			kc.moveUp ();
		} else if (moveDirection.Equals ("down")) {
			keyList.Add (kc);
			kc.moveDown ();
		}
	}

	void upButtonClick() { // use this for VR interaction
		this.GetComponentInParent<LockController>().setActiveKey (position);
		this.GetComponentInParent<LockController>().setAction ("up");
		this.GetComponentInParent<LockController>().setArrowPosition (this.transform.position.x);
	}

	void downButtonClick() { // use this for VR interaction
		this.GetComponentInParent<LockController>().setActiveKey (position);
		this.GetComponentInParent<LockController>().setAction ("down");
		this.GetComponentInParent<LockController>().setArrowPosition (this.transform.position.x);
	}
}
