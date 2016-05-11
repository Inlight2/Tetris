using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    //start position of every new tetrino
    public static readonly Vector3 START = new Vector3(5f, 15f, 0f);

    //The grid of blocks that have already been placed
    GameObject[,] grid = new GameObject[12, 16];

    public int width
    {
        get
        {
            return grid.GetLength(0);
        }
    }

    public int height
    {
        get
        {
            return grid.GetLength(1);
        }
    }

    public void SetTetrimino(GameObject tetrimino)
    {
        foreach(Transform block in tetrimino.transform)
        {
            grid[(int)block.position.x, (int)block.position.y] = block.gameObject;
        }
    }

    public bool ValidateNextPosition(int deltaX, int deltaY, GameObject curPiece)
    {
        foreach (Transform block in curPiece.transform)
        {
            if (block.position.y + deltaY < 0 || grid[(int)block.position.x + deltaX, (int)block.position.y + deltaY])
            {
                return false;
            }
        }

        return true;
    }

    public static void RoundTetriminoPos(GameObject tetrimino)
    {
        foreach(Transform block in tetrimino.transform)
        {
            block.position = RoundPos(block.position);
        }
    }

    public static Vector3 RoundPos(Vector3 pos)
    {
        return new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), pos.z);
    }
}
