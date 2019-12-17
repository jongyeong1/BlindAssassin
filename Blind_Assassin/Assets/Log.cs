using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    public float dodge = 0;
    float speed = 10.0f;
    Transform Target;


    public float TimeLeft = 2.0f;               ///2016039036 장병권
    public float nextTime = 0.0f;
    public GameObject trap;
    private void Start()                       //2016039036 장병권 시간 초기화
    {
        nextTime = Time.time + TimeLeft;
    }

    private void Update()
    {
        if (transform.position.z != -1000)                  //z값이 -1000이면 부동 2016039036 장병권
        {
            Target = GameObject.Find("Player").transform;

            Vector3 direction = (transform.position - Target.position).normalized;
            transform.position -= direction * speed * Time.deltaTime;


            if (Time.time > nextTime)                                            //2초뒤 삭제 if문 내용 2016039036 장병권
            {
                GameObject.Find("Trap").GetComponent<trap>().Tree_Trap = false;     //제거 시 false로 바꿈
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            GameObject.Find("Trap").GetComponent<trap>().Tree_Trap = false;      //제거 시 false로 바꿈
            Movecontroler.life--;                                      //피격 판정및 제거  2016039036 장병권
            Destroy(gameObject);

        }
    }

}