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
        if (Input.GetButtonDown("A"))
        {
            //TODO:Left
        }
        else if(Input.GetButtonDown("D"))
        {
           //TODO:Right
        }
        else if(Input.GetButtonDown("W"))
        {
            //TODO:Spin
        }
        else if(Input.GetButtonDown("S"))
        {
            //TODO:Down
        }
    }
	
}
