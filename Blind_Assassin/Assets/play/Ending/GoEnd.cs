using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoEnd : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > -180)
        {
            switch (Movecontroler.life)
            {
                case 3:
                    SceneManager.LoadScene("ENDHP3");
                    break;
                case 2:
                    SceneManager.LoadScene("ENDHP2");
                    break;
                case 1:
                    SceneManager.LoadScene("ENDHP1");
                    break;
            }
        }
    }
}
