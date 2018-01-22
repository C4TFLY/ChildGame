using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Pos
{
    TOP,
    UPPERMIDDLE,
    LOWERMIDDLE,
    BOTTOM
}

public enum State
{
    MOVING,
    DEAD
}

public class Movement : MonoBehaviour {

    List<Pos> positions;
    Pos position = Pos.LOWERMIDDLE;
    Pos[] possibleMoves = new Pos[2];
    int positionIndex;

	// Use this for initialization
	void Start ()
    {
        positions = new List<Pos>();
		foreach(Pos pos in System.Enum.GetValues(typeof(Pos)))
        {
            positions.Add(pos);
            print(pos);
        }
        positionIndex = positions.FindIndex(x => x == position);

        UpdateMoves();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            position = possibleMoves[1];
            positionIndex = positions.FindIndex(x => x == position);

            UpdateMoves();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            position = possibleMoves[0];
            positionIndex = positions.FindIndex(x => x == position);

            UpdateMoves();
        }
        print(position);
	}

    void UpdateMoves()
    {
        possibleMoves[0] = (positionIndex == positions.Count - 1) ? positions[positionIndex] : positions[positionIndex + 1];
        possibleMoves[1] = (positionIndex == 0) ? positions[positionIndex] : positions[positionIndex - 1];

        //print("PossibleMoves[0]: " + possibleMoves[0]);
        //print("PossibleMoves[1]: " + possibleMoves[1]);
    }
}
