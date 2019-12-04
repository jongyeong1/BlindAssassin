using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class katana : MonoBehaviour
{
    public GameObject righthands;

    void Update()
    {



        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {

            righthands.GetComponent<Renderer>().enabled = false;


        }
        else
        {
            Movecontroler.action = 0;
            righthands.GetComponent<Renderer>().enabled = true;

        }



    }
}
