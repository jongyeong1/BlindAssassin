using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Threading;

public class life2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lifep2;

    // Update is called once per frame
    void Update()
    {

        if (Movecontroler.life <= 1)
        {
            lifep2.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            lifep2.GetComponent<Renderer>().enabled = true;
        }
    }
}