﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class swl : MonoBehaviour
{
    public GameObject leftshiled;
    public GameObject lkata;
    public GameObject lhand;
    public GameObject lhand2;
    public RuntimeAnimatorController ss;

    public int a = 0;
    bool bb = false;

    public Animator ani;

    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move.action = 2;
            lkata.GetComponent<Renderer>().enabled = true;
            lhand.GetComponent<Renderer>().enabled = true;
            lhand2.GetComponent<Renderer>().enabled = true;
            bb = true;
        }
        else
        {
            Move.action = 0;
            lkata.GetComponent<Renderer>().enabled = false;
            lhand.GetComponent<Renderer>().enabled = false;
            lhand2.GetComponent<Renderer>().enabled = false;
            bb = false;
        }

        ani.SetBool("left", bb);



    }
}
