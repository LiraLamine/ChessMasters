﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece {

    public Rook()
    {

    }

    public Rook(bool all, int x, int y): base(all, x, y)
    {

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //The rook moves to any square (except as limited by Article 4.2) on the file or rank on which it stands.
    public override bool findValidSpaces()
    {
        bool flag = false;
        for(int i = 1; i <= 7-loc[0] && gameBoard.pieceAtSpace(loc[0] + i, loc[1], allegiance) != 2; i++)
        {
            Debug.Log("Rook can move to: (" + (loc[0]+ i) + "," + (loc[1]) + ")");
            flag = true;
            gameBoard.highlightSquare(loc[0]+i, loc[1]);
        }
        for (int i = 1; i <= loc[0] && gameBoard.pieceAtSpace(loc[0] - i, loc[1], allegiance) != 2; i++)
        {
            Debug.Log("Rook can move to: (" + (loc[0] - i) + "," + (loc[1]) + ")");
            flag = true;
            gameBoard.highlightSquare(loc[0] + i, loc[1]);
        }
        for (int i = 1; i <= 7-loc[1] && gameBoard.pieceAtSpace(loc[0], loc[1]+i, allegiance) != 2; i++)
        {
            Debug.Log("Rook can move to: (" + (loc[0]) + "," + (loc[1]+i) + ")");
            flag = true;
            gameBoard.highlightSquare(loc[0], loc[1]+i);
        }
        for (int i = 1; i <= loc[1] && gameBoard.pieceAtSpace(loc[0], loc[1]-i, allegiance) != 2; i++)
        {
            Debug.Log("Rook can move to: (" + (loc[0]) + "," + (loc[1]-i) + ")");
            flag = true;
            gameBoard.highlightSquare(loc[0], loc[1]-i);
        }
        return flag;
    }
}