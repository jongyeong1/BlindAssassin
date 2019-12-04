using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class sw : MonoBehaviour
{
    public GameObject rightshiled;
    public GameObject kata;
    public GameObject hand;
    public RuntimeAnimatorController ss;

    public int a = 0;
    bool bb = false;

    public Animator ani;

    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move.action = 3;
            kata.GetComponent<Renderer>().enabled = true;
            hand.GetComponent<Renderer>().enabled = true;
            bb = true;
        }
        else
        {
            Move.action = 0;
            kata.GetComponent<Renderer>().enabled = false;
            hand.GetComponent<Renderer>().enabled = false;
            bb = false;
        }
       
        ani.SetBool("right",bb);
        
      

    }
}
