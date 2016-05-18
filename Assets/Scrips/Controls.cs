using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    BlockManager manager;

    void Start ()
    {
        manager = GetComponent<BlockManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            manager.Left();
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            manager.Right();
        }
        else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            manager.Turn();
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            manager.Down();
        }
    }
	
}
