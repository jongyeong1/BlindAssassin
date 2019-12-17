using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    int life = 3;
    float speed = 10.0f;
    Transform Target;
    private void Update()
    {
        Target = GameObject.Find("Player").transform;

        Vector3 direction = (transform.position - Target.position).normalized;
        transform.position -= direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            life -= 1;
            Debug.Log(life);
            gameObject.SetActive(false);
        }
    }

}