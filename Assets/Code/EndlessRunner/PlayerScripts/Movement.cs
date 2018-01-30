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

    List<Pos> positions;  //List containing all positions
    Pos position = Pos.LOWERMIDDLE; //Initial starting position
    Pos[] possibleMoves = new Pos[2]; //Array containing the moves the player can make
    int positionIndex; //The index of the current position in the 'positions' list
    State state = State.MOVING;

	// Use this for initialization
	void Start ()
    {
        positions = new List<Pos>();
		foreach(Pos pos in System.Enum.GetValues(typeof(Pos)))
        {
            positions.Add(pos);
            print(pos);
        }
        UpdateMoves();
    }
	
	// Update is called once per frame
	void Update () {
        
        switch (state)
        {
            case State.MOVING:
                Update_Moving();
                break;
            case State.DEAD:
                Update_Dead();
                break;
            default:
                Debug.Log("Something went wrong");
                break;
        }
	}

#region Case updates
    private void Update_Moving()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            position = possibleMoves[1];
            UpdateMoves();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            position = possibleMoves[0];
            UpdateMoves();
        }
        print(position);
    }

    private void Update_Dead()
    {

    }

    #endregion

#region Case enters
    private void Enter_Moving()
    {

    }

    private void Enter_Dead()
    {

    }
#endregion

    void UpdateMoves()
    {
        positionIndex = positions.FindIndex(x => x == position);
        possibleMoves[0] = (positionIndex == positions.Count - 1) ? positions[positionIndex] : positions[positionIndex + 1];
        possibleMoves[1] = (positionIndex == 0) ? positions[positionIndex] : positions[positionIndex - 1];
    }

    private void ChangePosition()
    {

    }
}
