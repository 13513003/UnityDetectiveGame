using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMoon1 : MonoBehaviour {
	private GameObject innerPattern;
	private GameObject middlePattern;
	private GameObject outerPattern;
	private GameObject mirrorCase;
	private const int p1 = 11;
	private const int p2 = 4;
	private const int p3 = 7;

	// Use this for initialization
	void Start () {
		innerPattern = this.transform.Find("Inner").gameObject;
		middlePattern = this.transform.Find("Middle").gameObject;
		outerPattern = this.transform.Find("Outer").gameObject;
		mirrorCase = this.transform.Find("Case").gameObject;
	}

	public void checkAnswer() {
		if (innerPattern.transform.GetComponent<RotatePattern>().getValue() == p1)
			if (middlePattern.transform.GetComponent<RotatePattern>().getValue() == p2)
				if (outerPattern.transform.GetComponent<RotatePattern>().getValue() == p3){
					mirrorCase.transform.GetComponent<Collider>().attachedRigidbody.useGravity = true;
				}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
