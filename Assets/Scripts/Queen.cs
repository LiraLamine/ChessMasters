﻿using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece {

    public Queen()
    {

    }

    public Queen(int all, Point p, Board b, PieceTypeE t) : base(all, p, b, t)
    {

    }

    //Create list of valid moves moving along diagonal, file, rank until finding illegal move
    //Queen has way too many possible moves!
    override public List<Point> canMoveList()
    {
        List<Point> retMoveList = new List<Point>();
        bool[] flagArray = { true, true, true, true, true, true, true, true};
        for (int i = 1; flagArray[0] && i < 8; i++)
        {
            Point p = new Point(loc.getX() + i, loc.getY() + i);
            if (canMove(p) == MoveTypesE.ILLEGAL)
                flagArray[0] = false;
            else
                retMoveList.Add(p);
        }
        for (int i = 1; flagArray[1] && i < 8; i++)
        {
            Point p = new Point(loc.getX() - i, loc.getY() + i);
            if (canMove(p) == MoveTypesE.ILLEGAL)
                flagArray[1] = false;
            else
                retMoveList.Add(p);
        }
        for (int i = 1; flagArray[2] && i < 8; i++)
        {
            Point p = new Point(loc.getX() + i, loc.getY() - i);
            if (canMove(p) == MoveTypesE.ILLEGAL)
                flagArray[2] = false;
            else
                retMoveList.Add(p);
        }
        for (int i = 1; flagArray[3] && i < 8; i++)
        {
            Point p = new Point(loc.getX() - i, loc.getY() - i);
            if (canMove(p) == MoveTypesE.ILLEGAL)
                flagArray[3] = false;
            else
                retMoveList.Add(p);
        }
        for (int i = 1; flagArray[4] && i < 8; i++)
        {
            Point p = new Point(loc.getX() + i, loc.getY());
            if (canMove(p) == MoveTypesE.ILLEGAL)
                flagArray[0] = false;
            else
                retMoveList.Add(p);
        }
        for (int i = 1; flagArray[5] && i < 8; i++)
        {
            Point p = new Point(loc.getX(), loc.getY() + i);
            if (canMove(p) == MoveTypesE.ILLEGAL)
                flagArray[1] = false;
            else
                retMoveList.Add(p);
        }
        for (int i = 1; flagArray[6] && i < 8; i++)
        {
            Point p = new Point(loc.getX() - i, loc.getY());
            if (canMove(p) == MoveTypesE.ILLEGAL)
                flagArray[2] = false;
            else
                retMoveList.Add(p);
        }
        for (int i = 1; flagArray[7] && i < 8; i++)
        {
            Point p = new Point(loc.getX(), loc.getY() - i);
            if (canMove(p) == MoveTypesE.ILLEGAL)
                flagArray[3] = false;
            else
                retMoveList.Add(p);
        }
        return retMoveList;
    }

    //The queen moves to any square (except as limited by Article 4.2) [No leapfrogging] on the file, rank, or diagonals on which it stands.
    override public MoveTypesE canMove(Point p)
    {
        MoveTypesE mt = base.canMove(p);
        if (mt == MoveTypesE.ILLEGAL)
            return MoveTypesE.ILLEGAL;
        int dy = p.getY() - loc.getY();
        int dx = p.getX() - loc.getX();

        if (dy == 0)
        {
            int signFactor = (dx * System.Math.Abs(dx) > 0) ? 1 : -1;
            for (int i = 1; i < System.Math.Abs(dx); i++)
            {
                if (gameBoard.pieceAt(loc.getX() + signFactor * i, loc.getY()) != null)
                    return MoveTypesE.ILLEGAL;
            }
        }
        else if (dx == 0)
        {
            int signFactor = (dy * System.Math.Abs(dy) > 0) ? 1 : -1;
            for (int i = 1; i < System.Math.Abs(dy); i++)
            {
                if (gameBoard.pieceAt(loc.getX(), loc.getY() + signFactor * i) != null)
                    return MoveTypesE.ILLEGAL;
            }
        }
        if (System.Math.Abs(dy) == System.Math.Abs(dx))
        {
            int signFactorX = (dx * System.Math.Abs(dx) > 0) ? 1 : -1;
            int signFactorY = (dy * System.Math.Abs(dy) > 0) ? 1 : -1;
            for (int i = 1; i < System.Math.Abs(dx); i++)
            {
                if (gameBoard.pieceAt(loc.getX() + signFactorX * i, loc.getY() + signFactorY * i) != null)
                    return MoveTypesE.ILLEGAL;
            }
        }
        return mt;
    }
}