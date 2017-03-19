using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideNumber : MonoBehaviour {
	public int value;
	private int[] position = new int[2];

	// Use this for initialization
	void Start () {
		
	}

	public void SetPosition(int x, int y){
		position[0] = x;
		position[1] = y;
	}

	public int[] GetPosition() {
		return position;
	}

	void OnMouseDown() {
		this.transform.parent.parent.GetComponent<PuzzleMoon4>().slideNumber(value);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
