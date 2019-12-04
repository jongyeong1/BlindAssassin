using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Threading;

public class life3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lifep3;

    // Update is called once per frame
    void Update()
    {

        if (Movecontroler.life <= 0)
        {
            lifep3.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            lifep3.GetComponent<Renderer>().enabled = true;
        }
    }
}