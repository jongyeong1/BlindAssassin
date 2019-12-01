using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class MoveRightHand: MonoBehaviour
{
    public GameObject hands;
    void Update()
    {




        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            hands.SetActive(true);


        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {

            hands.SetActive(false);


        }


    }
}
