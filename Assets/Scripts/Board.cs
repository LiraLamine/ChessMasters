//Most of this game logic is much more complicated than I had predicted.
//I have the basic logic of the game, but I am working on studying chessprogramming.wikispaces.com to learn more about algorithms to work with chess

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Board : Singleton<Board>
{
    public enum PlayerE
    {
        White = 0,
        Black = 1
    };

    public enum AIE: int
    {
        NONE = 0,
        EASY = 1,
        NORMAL = 2,
        HARD = 3
    };

    bool gameActive;
    bool aIUpdated = true;
    int turn = (int) PlayerE.White;
    bool piecesUpdated = false;
<<<<<<< HEAD
    Piece[,] boardPieces;
    List<Piece> whiteList;
    List<Piece> blackList;
    History firstHistory, lastHistory;
    Point enPassant;
    Piece[] kings;
    public AIE ai;
=======
    GameObject[,] boardPieces;
    List<GameObject> whiteList;
    List<GameObject> blackList;
    List<GameObject> tileList;
    History firstHistory, lastHistory;
    Point enPassant;
    GameObject[] kings;
    BoardGeneration bg;
    public int gameMode;
    public AIE ai;
    public GameObject whitePawn;
    public GameObject blackPawn;
    public GameObject whiteRook;
    public GameObject blackRook;
    public GameObject whiteKnight;
    public GameObject blackKnight;
    public GameObject whiteBishop;
    public GameObject blackBishop;
    public GameObject whiteQueen;
    public GameObject blackQueen;
    public GameObject whiteKing;
    public GameObject blackKing;
    public GameObject tilePrefab;
>>>>>>> origin/master

    private void Awake()
    {
<<<<<<< HEAD
        boardPieces = new Piece[8, 8];
        kings = new Piece[2];
        whiteList = new List<Piece>();
        blackList = new List<Piece>();
        setupBoard();
=======
        bg = new BoardGeneration(this);
        boardPieces = new GameObject[8, 8];
        kings = new GameObject[2];
        whiteList = new List<GameObject>();
        blackList = new List<GameObject>();
        tileList = new List<GameObject>();
    }

    // Use this for initialization
    void Start()
    {
        switch (gameMode)
        {
            case 0:
                bg.defaultSetup();
                break;
            default:
                bg.defaultSetup();
                break;
        }
        firstHistory = null;
        lastHistory = null;
        enPassant = null;
        StartCoroutine("runEasyAI");
>>>>>>> origin/master
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameActive && piecesUpdated && aIUpdated)
        {
            piecesUpdated = false;
            gameActive = isCheckmate();
            switch (ai)
            {
                case AIE.NONE:
                    break;
                case AIE.EASY:
                    StartCoroutine("runEasyAI");
                    break;
                case AIE.NORMAL:
                    runNormalAI();
                    break;
                default:
                    break;

            }
        }
        //During Milestone 2, there will be tiles once we integrate the graphics with this code
        //I will use a similar detection of click as for the Piece class
        //When I detect a click, if the tile clicked is highlighted, I will move currentPiece to the new location
        //Next, I will remove any piece currently on that tile from the game
        //I will then update the location of the piece
        //Finally, I will make piecesUpdated true
    }

    private void switchTurn()
    {
        turn += 1;
        turn %= 2;
    }

<<<<<<< HEAD
    //This is effectively acting as the constructor for Board
    void setupBoard()
    {
        boardPieces[0, 0] = new Rook((int)PlayerE.White, new Point(0,0), this, Piece.PieceTypeE.ROOK);
        boardPieces[1, 0] = new Knight((int)PlayerE.White, new Point(1, 0), this, Piece.PieceTypeE.KNIGHT);
        boardPieces[2, 0] = new Bishop((int)PlayerE.White, new Point(2, 0), this, Piece.PieceTypeE.BISHOP);
        boardPieces[3, 0] = new Queen((int)PlayerE.White, new Point(3, 0), this, Piece.PieceTypeE.QUEEN);
        boardPieces[4, 0] = new King((int)PlayerE.White, new Point(4, 0), this, Piece.PieceTypeE.KING);
        boardPieces[5, 0] = new Bishop((int)PlayerE.White, new Point(5, 0), this, Piece.PieceTypeE.BISHOP);
        boardPieces[6, 0] = new Knight((int)PlayerE.White, new Point(6, 0), this, Piece.PieceTypeE.KNIGHT);
        boardPieces[7, 0] = new Rook((int)PlayerE.White, new Point(7, 0), this, Piece.PieceTypeE.ROOK);
        boardPieces[0, 1] = new Pawn((int)PlayerE.White, new Point(0, 1), this, Piece.PieceTypeE.PAWN);
        boardPieces[1, 1] = new Pawn((int)PlayerE.White, new Point(1, 1), this, Piece.PieceTypeE.PAWN);
        boardPieces[2, 1] = new Pawn((int)PlayerE.White, new Point(2, 1), this, Piece.PieceTypeE.PAWN);
        boardPieces[3, 1] = new Pawn((int)PlayerE.White, new Point(3, 1), this, Piece.PieceTypeE.PAWN);
        boardPieces[4, 1] = new Pawn((int)PlayerE.White, new Point(4, 1), this, Piece.PieceTypeE.PAWN);
        boardPieces[5, 1] = new Pawn((int)PlayerE.White, new Point(5, 1), this, Piece.PieceTypeE.PAWN);
        boardPieces[6, 1] = new Pawn((int)PlayerE.White, new Point(6, 1), this, Piece.PieceTypeE.PAWN);
        boardPieces[7, 1] = new Pawn((int)PlayerE.White, new Point(7, 1), this, Piece.PieceTypeE.PAWN);

        for(int i = 0; i < 8; i++)
        {
            whiteList.Add(boardPieces[0, i]);
            whiteList.Add(boardPieces[1, i]);
        }


        boardPieces[0, 6] = new Pawn((int)PlayerE.Black, new Point(0, 6), this, Piece.PieceTypeE.PAWN);
        boardPieces[1, 6] = new Pawn((int)PlayerE.Black, new Point(1, 6), this, Piece.PieceTypeE.PAWN);
        boardPieces[2, 6] = new Pawn((int)PlayerE.Black, new Point(2, 6), this, Piece.PieceTypeE.PAWN);
        boardPieces[3, 6] = new Pawn((int)PlayerE.Black, new Point(3, 6), this, Piece.PieceTypeE.PAWN);
        boardPieces[4, 6] = new Pawn((int)PlayerE.Black, new Point(4, 6), this, Piece.PieceTypeE.PAWN);
        boardPieces[5, 6] = new Pawn((int)PlayerE.Black, new Point(5, 6), this, Piece.PieceTypeE.PAWN);
        boardPieces[6, 6] = new Pawn((int)PlayerE.Black, new Point(6, 6), this, Piece.PieceTypeE.PAWN);
        boardPieces[7, 6] = new Pawn((int)PlayerE.Black, new Point(7, 6), this, Piece.PieceTypeE.PAWN);
        boardPieces[0, 7] = new Rook((int)PlayerE.Black, new Point(0, 7), this, Piece.PieceTypeE.ROOK);
        boardPieces[1, 7] = new Knight((int)PlayerE.Black, new Point(1, 7), this, Piece.PieceTypeE.KNIGHT);
        boardPieces[2, 7] = new Bishop((int)PlayerE.Black, new Point(2, 7), this, Piece.PieceTypeE.BISHOP);
        boardPieces[3, 7] = new Queen((int)PlayerE.Black, new Point(3, 7), this, Piece.PieceTypeE.QUEEN);
        boardPieces[4, 7] = new King((int)PlayerE.Black, new Point(4, 7), this, Piece.PieceTypeE.KING);
        boardPieces[5, 7] = new Bishop((int)PlayerE.Black, new Point(5, 7), this, Piece.PieceTypeE.BISHOP);
        boardPieces[6, 7] = new Knight((int)PlayerE.Black, new Point(6, 7), this, Piece.PieceTypeE.KING);
        boardPieces[7, 7] = new Rook((int)PlayerE.Black, new Point(7, 7), this, Piece.PieceTypeE.ROOK);

        for (int i = 0; i < 8; i++)
=======
    public void generatePiece(PlayerE player, Point p, Piece.PieceTypeE piece, GameObject prefab, string str)
    {
        GameObject go = Instantiate(prefab, new Vector3(p.turnToWorld()[0], 0.75f, p.turnToWorld()[1]), Quaternion.identity);
        ((Piece)go.GetComponent(str)).initialize((int)player, p, this, piece);
        if (piece == Piece.PieceTypeE.KING)
            go.transform.localScale = new Vector3(1f, 1f, 1f);
        else
            go.transform.localScale = new Vector3(4f, 4f, 4f);
        boardPieces[p.getX(), p.getY()] = go;
        if (player == PlayerE.White)
            whiteList.Add(boardPieces[p.getX(), p.getY()]);
        else
            blackList.Add(boardPieces[p.getX(), p.getY()]);
        if(piece == Piece.PieceTypeE.KING)
>>>>>>> origin/master
        {
            blackList.Add(boardPieces[6, i]);
            blackList.Add(boardPieces[7, i]);
        }

        kings[0] = boardPieces[4, 0];
        kings[1] = boardPieces[4, 7];

        firstHistory = null;
        lastHistory = null;
        enPassant = null;
    }

    //Returns the piece located at the point p (null if no piece)
    public Piece pieceAt(Point p)
    {
        return boardPieces[p.getX() , p.getY()];
    }

    //Returns the piece located at (x,y) (null if no piece)
    public Piece pieceAt(int x, int y)
    {
        return boardPieces[x, y];
    }

    //Moves the piece located at the point p to the point pt
    public void placePieceAt(Piece p, Point pt)
    {
        if (boardPieces[pt.getX(), pt.getY()] != null)
        {
            if (boardPieces[pt.getX(), pt.getY()].getAllegiance() == 0)
                whiteList.Remove(boardPieces[pt.getX(), pt.getY()]);
            else
                blackList.Remove(boardPieces[pt.getX(), pt.getY()]);
        }
<<<<<<< HEAD
=======
        Destroy(pieceAt(pt));
        ((Piece)p.GetComponent("Piece")).moveObjectLoc(pt);
>>>>>>> origin/master
        boardPieces[pt.getX(), pt.getY()] = p;
    }

    //Moves the piece at the point p1 to p2 (calls the 3 paramater function with the third point null)
    public void Move(Point p1, Point p2)
    {
        Move(p1, p2, null);
    }

    //Moves the piece at the point p1 to p2 and sets enpassant to ep
    //Updates the game history
    //Switches the current turn
    public void Move(Point p1, Point p2, Point ep)
    {
        History temp_hist = new History(p1, p2, this, lastHistory);
        lastHistory.setNext(temp_hist);
        lastHistory = temp_hist;
        enPassant = ep;
        switchTurn();
        piecesUpdated = true;
        placePieceAt(pieceAt(p1), p2);
        boardPieces[p1.getX(), p1.getY()] = null;
        //destroyTileField();
    }

    //Calls tryToMove for the piece at p1 to move to p2
    public void tryToMove(Point p1, Point p2)
    {
        Piece temp_piece = pieceAt(p1);
        if (temp_piece != null)
        {
            temp_piece.tryToMove(p2);
        }
    }

    //Kills the piece at enPassant
    public void killEnPassant()
    {
        if(boardPieces[enPassant.getX(), enPassant.getY()] != null)
        {
            if (boardPieces[enPassant.getX(), enPassant.getY()].getAllegiance() == 0)
                whiteList.Remove(boardPieces[enPassant.getX(), enPassant.getY()]);
            else
                blackList.Remove(boardPieces[enPassant.getX(), enPassant.getY()]);
        }
        boardPieces[enPassant.getX(), enPassant.getY()] = null;
    }

    //Tests if moving a piece from start to finish would put the current turn's king in check
    public bool inCheck(Point start, Point finish)
    {
        Piece startPiece = boardPieces[start.getX(), start.getY()];
        Piece finishPiece = boardPieces[finish.getX(), finish.getY()];

        boardPieces[finish.getX(), finish.getY()] = startPiece;

        bool flag = inCheck(kings[turn].getLoc());
        boardPieces[start.getX(), start.getY()] = startPiece;
        boardPieces[finish.getX(), finish.getY()] = finishPiece;

        return flag;
    }

    //Tests if any enemy piece can move to the current space (where the king is)
    public bool inCheck(Point p)
    {
        for(int i = 0; i < 7; i++)
            for(int j = 0; j < 7; j++)
                if(boardPieces[i,j] != null && boardPieces[i,j].getAllegiance() != turn)
                    if (boardPieces[i, j].canMove(p) != Piece.MoveTypesE.ILLEGAL)
                        return true;
        return false;
    }

    //Tests if you pick up notKing and king, if the king is placed at (xloc, yloc) then if the king is in check
    //Used for castling
    public bool inCheck(Piece notKing, Piece king, int xloc, int yloc)
    {
        boardPieces[notKing.getLoc().getX(), notKing.getLoc().getY()] = null;
        boardPieces[king.getLoc().getX(), king.getLoc().getY()] = null;
        bool flag = inCheck(new Point(xloc, yloc));
        boardPieces[notKing.getLoc().getX(), notKing.getLoc().getY()] = notKing;
        boardPieces[king.getLoc().getX(), king.getLoc().getY()] = king;
        return flag;
    }
    
    //Promotes the pawn at p
    //Currently promotes it to queen until we figure out how to prompt the user
    public void promotePawn(Point p)
    {
        if (turn == 0)
            whiteList.Remove(boardPieces[p.getX(), p.getY()]);
        else
            blackList.Remove(boardPieces[p.getX(), p.getY()]);
<<<<<<< HEAD
        boardPieces[p.getX(), p.getY()] = new Queen(turn, p, this, Piece.PieceTypeE.QUEEN);
=======
        generatePiece((turn == 1)?PlayerE.White:PlayerE.Black, p, Piece.PieceTypeE.QUEEN, (turn==1)?whiteQueen:blackQueen, "Queen");
>>>>>>> origin/master
        if (turn == 0)
            whiteList.Add(boardPieces[p.getX(), p.getY()]);
        else
            blackList.Add(boardPieces[p.getX(), p.getY()]);
    }

    //Gets the point enPassant refers to currently
    public Point getEnPassant()
    {
        return enPassant;
    }

    //Highlights square (x,y)
    public void highlightSquare(int x, int y)
    {
        //Part of Milestone 2
    }

    //Removes highlighting from every square
    public void unhighlight()
    {
        //Part of Milestone 2
    }

    //Checks if there is any legal moves to make
    bool isCheckmate()
    {
        for (int i = 0; i < 7; i++)
            for (int j = 0; j < 7; j++)
                if (boardPieces[i, j] != null && boardPieces[i, j].getAllegiance() == turn)
                    if (boardPieces[i, j].canMoveList().Count > 0)
                        return false;
        Debug.Log("In Checkmate!");
        return true;
    }

    //Compute a score for the player indicated
    public int computePlayerScore(int inScore, PlayerE currPlayer)
    {
        foreach (Piece p in whiteList)
            inScore += (p.getPieceScore() + p.canMoveList().Count);
        foreach (Piece p in blackList)
            inScore -= (p.getPieceScore() + p.canMoveList().Count);
        return inScore;
    }

    //Easy AI implementation
    //Picks a random valid piece and a random space it may move to
    //Hopefully not too computationally expensive
    public IEnumerator runEasyAI()
    {
<<<<<<< HEAD
=======
        aIUpdated = false;
>>>>>>> origin/master
        bool flag = true;
        if(turn == (int)PlayerE.White)
        {
            while (flag)
            {
                int randPieceInt = Random.Range(0, whiteList.Count);
                Piece randPiece = whiteList[randPieceInt];
                List<Point> pointList = randPiece.canMoveList();
<<<<<<< HEAD
                if(pointList != null)
=======
                makeTileField(pointList);
                if(pointList.Count != 0)
>>>>>>> origin/master
                {
                    Point randomPoint = pointList[Random.Range(0, pointList.Count)];
                    yield return new WaitForSeconds(2);
                    randPiece.tryToMove(randomPoint);
                    flag = false;
                }
            }
        }
        else
        {
            while (flag)
            {
                int randPieceInt = Random.Range(0, blackList.Count);
                Piece randPiece = blackList[randPieceInt];
                List<Point> pointList = randPiece.canMoveList();
<<<<<<< HEAD
                if (pointList != null)
=======
                makeTileField(pointList);
                if (pointList.Count != 0)
>>>>>>> origin/master
                {
                    Point randomPoint = pointList[Random.Range(0, pointList.Count)];
                    yield return new WaitForSeconds(2);
                    randPiece.tryToMove(randomPoint);
                    flag = false;
                }
            }
        }
        yield return new WaitForSeconds(2);
        aIUpdated = true;
    }

    //Normal AI implementation
    //Look at best move to a depth of 3 which is maximum depth with current efficiency
    public IEnumerator runNormalAI()
    {
        aIUpdated = false;
        bool flag = true;
        if (turn == (int)PlayerE.White)
        {
            while (flag)
            {
                int randPieceInt = Random.Range(0, whiteList.Count);
                Piece randPiece = whiteList[randPieceInt];
                List<Point> pointList = randPiece.canMoveList();
                if (pointList != null)
                {
                    Point randomPoint = pointList[Random.Range(0, pointList.Count)];
                    randPiece.tryToMove(randomPoint);
                    flag = false;
                }
            }
        }
        else
        {
            while (flag)
            {
                int randPieceInt = Random.Range(0, blackList.Count);
                Piece randPiece = blackList[randPieceInt];
                List<Point> pointList = randPiece.canMoveList();
                if (pointList != null)
                {
                    Point randomPoint = pointList[Random.Range(0, pointList.Count)];
                    randPiece.tryToMove(randomPoint);
                    flag = false;
                }
            }
        }
        yield return new WaitForSeconds(1);
        aIUpdated = true;
    }
<<<<<<< HEAD
=======

    private void makeTileField(List<Point> pointList)
    {
        destroyTileField();
        foreach(Point p in pointList)
        {
            tileList.Add(Instantiate(tilePrefab, new Vector3(p.turnToWorld()[0], 0.75f, p.turnToWorld()[1]), Quaternion.identity));
        }
    }

    private void destroyTileField()
    {
        foreach(GameObject tile in tileList)
        {
            Destroy(tile);
        }
    }
>>>>>>> origin/master
}