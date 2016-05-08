using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour {
    //start position of every new tetrino
    readonly Vector3 START = new Vector3(5f, 15f, 0f);

    //A collection of the different tetrino types that can fall
    public GameObject[] blockTypes;

    //The grid of blocks that have already been placed
    GameObject [,] Grid = new GameObject [12, 16];

    //current piece shifting down the grid
    GameObject curPiece;

    void Start()
    {
        
    }

    void NextPiece()
    {
        //grab a random piece
        GameObject randomPiece = blockTypes[Random.Range(0, blockTypes.Length)];

        //instantiate the random piece
        curPiece = Instantiate(randomPiece, START, Quaternion.identity) as GameObject;

        //place it where we know none of it is off the top of the screen.
        foreach (Transform block in transform)
        {
            if (block.position.y > 15)
            {

            }
        }

    }

    public static Vector3 RoundPos(Vector3 pos)
    {
        return new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), pos.z);
    }
}
