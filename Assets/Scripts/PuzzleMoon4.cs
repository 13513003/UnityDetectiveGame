using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMoon4 : MonoBehaviour {
	private int[][] puzzle;
	private GameObject[] number;
	private Vector3 toUp = new Vector3(0,0.5f,0);
	private Vector3 toDown = new Vector3(0,-0.5f,0);
	private Vector3 toLeft = new Vector3(0,0,0.5f);
	private Vector3 toRight = new Vector3(0,0,-0.5f);
	private Vector3 target;
	private float step;
	private int currentMove = -1;
	private bool isSliding = false;

	// Use this for initialization
	void Start () {
		puzzle = new int[3][];
		puzzle[0] = new int[5];
		puzzle[1] = new int[5];
		puzzle[2] = new int[5];
		puzzle[0][0] = 7; puzzle[0][1] = 0; puzzle[0][2] = -2; puzzle[0][3] = -2; puzzle[0][4] = -2;
		puzzle[1][0] = 8; puzzle[1][1] = 4; puzzle[1][2] = 2; puzzle[1][3] = 6; puzzle[1][4] = 1;
		puzzle[2][0] = -2; puzzle[2][1] = 3; puzzle[2][2] = 5; puzzle[2][3] = 9; puzzle[2][4] = -1;
		number = new GameObject[10];
		number[0] = this.transform.Find("Pattern").transform.Find("0").gameObject;
		number[1] = this.transform.Find("Pattern").transform.Find("1").gameObject;
		number[2] = this.transform.Find("Pattern").transform.Find("2").gameObject;
		number[3] = this.transform.Find("Pattern").transform.Find("3").gameObject;
		number[4] = this.transform.Find("Pattern").transform.Find("4").gameObject;
		number[5] = this.transform.Find("Pattern").transform.Find("5").gameObject;
		number[6] = this.transform.Find("Pattern").transform.Find("6").gameObject;
		number[7] = this.transform.Find("Pattern").transform.Find("7").gameObject;
		number[8] = this.transform.Find("Pattern").transform.Find("8").gameObject;
		number[9] = this.transform.Find("Pattern").transform.Find("9").gameObject;
		number[0].GetComponent<SlideNumber>().SetPosition(0,1);
		number[1].GetComponent<SlideNumber>().SetPosition(1,4);
		number[2].GetComponent<SlideNumber>().SetPosition(1,2);
		number[3].GetComponent<SlideNumber>().SetPosition(2,1);
		number[4].GetComponent<SlideNumber>().SetPosition(1,1);
		number[5].GetComponent<SlideNumber>().SetPosition(2,2);
		number[6].GetComponent<SlideNumber>().SetPosition(1,3);
		number[7].GetComponent<SlideNumber>().SetPosition(0,0);
		number[8].GetComponent<SlideNumber>().SetPosition(1,0);
		number[9].GetComponent<SlideNumber>().SetPosition(2,3);
		step = 5 * Time.deltaTime;
		print();
	}

	void print() {
		for (int i = 0; i < 3; i++){
			for (int j = 0; j < 5; j++){
				Debug.Log(puzzle[i][j]);
			}
		}
	}

	public void slideNumber(int numberPuzzle){
		if (!isSliding){
			int[] position = new int[2];
			position[0] = number[numberPuzzle].GetComponent<SlideNumber>().GetPosition()[0];
			position[1] = number[numberPuzzle].GetComponent<SlideNumber>().GetPosition()[1];
			int[] available = isCanSlide(position);


			if (available[0] != -1){
				Vector3 translation = new Vector3 (0, (position[0]-available[0]) * 0.5f, (position[1]-available[1]) * 0.5f);
				Debug.Log(position[0]-available[0]);
				Debug.Log(position[1]-available[1]);
				target = number[numberPuzzle].transform.position + translation;
				number[numberPuzzle].GetComponent<SlideNumber>().SetPosition(available[0],available[1]);

				puzzle[available[0]][available[1]] = numberPuzzle;
				puzzle[position[0]][position[1]] = -1;

				currentMove = numberPuzzle;
				isSliding = true;
				StartCoroutine(Wait());
			}
		}
	}

	IEnumerator Wait() {
        yield return new WaitForSeconds(0.5f);
        currentMove = -1;
        isSliding = false;
    }

	int[] isCanSlide(int[] position){
		int[] available = new int[2];
		available[0] = position[0];
		available[1] = position[1];

		if (available[0] > 0){
			if (puzzle[available[0]-1][available[1]] == -1){
				available[0]--;
				Debug.Log("atas");
				return available;
			}
		}
		if (available[0] < 2){
			if (puzzle[available[0]+1][available[1]] == -1){
				available[0]++;
				Debug.Log("bawah");
				return available;
			}
		}
		if (available[1] > 0){
			if (puzzle[available[0]][available[1]-1] == -1){
				available[1]--;
				Debug.Log("kiri");
				return available;
			}
		}
		if (available[1] < 4){
			if (puzzle[available[0]][available[1]+1] == -1){
				available[1]++;
				Debug.Log("kanan");
				return available;
			}
		}
		available[0] = -1; available[1] = -1;
		return available;
	}

	void CheckAnswer() {
		if (puzzle[1][0] == 6 && puzzle[1][1] == 3 && puzzle[1][2] == 7 && puzzle[1][3] == 2 && puzzle[1][4] == 9){
			Debug.Log ("true");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isSliding && (currentMove != -1)){
			number[currentMove].transform.position = Vector3.MoveTowards(number[currentMove].transform.position, target, step);
		}
	}
}
