using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Threading;

public class life1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lifep1;

    // Update is called once per frame
    void Update()
    {

        if (Move.life <= 0)
        {
            lifep1.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            lifep1.GetComponent<Renderer>().enabled = true;
        }
    }
}