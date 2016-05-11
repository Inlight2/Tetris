using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour {

    //how many frames till next drop
    const int TICK_RATE = 30;
    int curTick = 0;

    //A collection of the different tetrino types that can fall
    public GameObject[] blockTypes;

    //current piece shifting down the grid
    GameObject curPiece;

    Grid grid;

    void Start()
    {
        grid = GetComponent<Grid>();
        NextPiece();
    }

    void Update()
    {
        curTick++;

        if(curTick > TICK_RATE && curPiece)
        {
            MoveDown();
            curTick = 0;
        }
    }

    void MoveDown()
    {
        curTick = 0;
        if (grid.ValidateNextPosition(0, -1, curPiece))
        {
            curPiece.transform.position = new Vector3(curPiece.transform.position.x,
                                                      curPiece.transform.position.y - 1,
                                                      curPiece.transform.position.z);
        }
        else
        {
            grid.SetTetrimino(curPiece);
            NextPiece();
        }
    }

    void NextPiece()
    {
        //grab a random piece
        GameObject randomPiece = blockTypes[Random.Range(0, blockTypes.Length)];

        //instantiate the random piece
        curPiece = Instantiate(randomPiece, Grid.START, Quaternion.identity) as GameObject;

        //place it where we know none of it is off the top of the screen. Or off the sides
        foreach (Transform block in curPiece.transform)
        {
            while (block.position.y > grid.height - 1)
            {
                curPiece.transform.position = new Vector3(curPiece.transform.position.x,
                                                          curPiece.transform.position.y - 1,
                                                          curPiece.transform.position.z);

                curPiece.transform.position = Grid.RoundPos(curPiece.transform.position);
            }

            while (block.position.x < 0)
            {
                curPiece.transform.position = new Vector3(curPiece.transform.position.x + 1,
                                                          curPiece.transform.position.y,
                                                          curPiece.transform.position.z);

                curPiece.transform.position = Grid.RoundPos(curPiece.transform.position);
            }

            while (block.position.x > grid.width - 1)
            {
                curPiece.transform.position = new Vector3(curPiece.transform.position.x - 1,
                                                          curPiece.transform.position.y,
                                                          curPiece.transform.position.z);

                curPiece.transform.position = Grid.RoundPos(curPiece.transform.position);
            }
        }

        if(!grid.ValidateNextPosition(0,0,curPiece))
        {
            //this ends the game
            //TODO:add a real game over state
            curPiece = null;
        }
    }
}
