using UnityEngine;
using System.Collections;

public class GameBoardGenerator : MonoBehaviour {

	public GameObject block;
	public GameObject wall;

	static public int boardWidth = 10;
	public int boardHeight = 10;

	// Use this for initialization
	void Start () {
		GameObject ceiling = Instantiate(wall) as GameObject;
		GameObject floor = Instantiate(wall) as GameObject;
		GameObject leftWall = Instantiate(wall) as GameObject;
		GameObject rightWall = Instantiate(wall) as GameObject;

		rightWall.GetComponent<Rigidbody> ();
		leftWall.GetComponent<Rigidbody> ();

		//Make the 4 walls children of the game board object
		rightWall.transform.parent = this.transform;
		leftWall.transform.parent = this.transform;
		ceiling.transform.parent = this.transform;
		floor.transform.parent = this.transform;

		//set floor position
		floor.transform.localPosition = new Vector3(boardWidth / 2f, -4f, 0f);
		floor.transform.localScale = new Vector3(boardWidth + 3f, 1f, 1f);
		floor.AddComponent<DeathZone>();

		//set ceiling position
		ceiling.transform.localPosition = new Vector3(boardWidth / 2f, (boardHeight + 2f), 0f);
		ceiling.transform.localScale = new Vector3(boardWidth + 3f, 1f, 1f);

		//set right wall position
		rightWall.transform.localPosition = new Vector3(-2f, (boardHeight / 2f) - 1f, 0f);
		rightWall.transform.localScale = new Vector3(1f, boardHeight + 7f, 1f);

		//set left wall position
		leftWall.transform.localPosition = new Vector3(boardWidth + 2f, (boardHeight / 2f) - 1f, 0f);
		leftWall.transform.localScale = new Vector3(1f, boardHeight + 7f, 1f);

		for(int i = 0; i <= boardWidth; i++)
		{
			for(int j = 0; j <= boardHeight; j++)
			{
				//create blocks
				GameObject newBlock = Instantiate(block) as GameObject;
				newBlock.transform.parent = this.transform;
				newBlock.transform.localPosition = new Vector3((float)i, (float)j, 0f);
			}
		}
	}
}
