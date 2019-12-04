using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class MoveRightHand: MonoBehaviour
{
    public GameObject righthands;
    public GameObject hands11;
    public GameObject katana11;
    void Update()
    {

   

        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.LeftArrow))
        {
           
            righthands.GetComponent<Renderer>().enabled = false;
            hands11.GetComponent<Renderer>().enabled = false;
            katana11.GetComponent<Renderer>().enabled = false;

        }
        else
        {
            Move.action = 0;
            righthands.GetComponent<Renderer>().enabled = true;
            hands11.GetComponent<Renderer>().enabled = true;
            katana11.GetComponent<Renderer>().enabled = true;
        }
       


    }
}
