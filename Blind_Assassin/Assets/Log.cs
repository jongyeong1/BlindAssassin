using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 2015041007 문승현
 생성된 통나무 의 충돌을 검사하는 기능 구현
 */
/*2016039036 장병권
함정기능의 큰 틀인 trap에 맞춰서 코드 수정,최종 보완
    */
public class Log : MonoBehaviour
{
    public static float dodge = 1;
    float speed = 10.0f;
    Transform Target;


    public float TimeLeft = 2.0f;               
    public float nextTime = 0.0f;
    public GameObject trap;
    public AudioSource Sound_effect1;


    private void Start()                      
    {
            nextTime = Time.time + TimeLeft;
        if(transform.position.x>40)
        {
            Sound_effect1= GameObject.Find("Sound_log").GetComponent<AudioSource>();
            Sound_effect1.Play();
        }
    }

    private void Update()
    {
        if (transform.position.z != -1000)                  
        {
            Target = GameObject.Find("Player").transform;

            Vector3 direction = (transform.position - Target.position).normalized;
            transform.position -= direction * speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            GameObject.Find("Trap").GetComponent<trap>().Tree_Trap = false;
            if (dodge == 1)//통나무 회피는 dodge가 0일때 충돌해도 체력이 안깍임
            {
                Movecontroler.life--;
            }
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}