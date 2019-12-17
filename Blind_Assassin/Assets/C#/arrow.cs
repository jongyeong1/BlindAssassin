﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public float speed = 10.0f;                           //속도
    public int dir = 0;                        //방향 1이면 플레이어 기준 왼쪽 2이면 오른쪽으로 판단
    Transform Target;                          //플레이어의 위치 저장

    public AudioSource Sound_effect1, Sound_effect2, Sound_effect3;        //효과음 저장

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y > -1000)//오브젝트 생성을 위해 화살 오브젝트를 하나 생성을 해놓는데 그 부분에서 활소리가 나서 예외처리
        {
            if (dir == 1)        //왼쪽일 경우
            {
                Sound_effect1 = GameObject.Find("Bow_left").GetComponent<AudioSource>();
            }
            else if (dir == 2)   //오른쪽일 경우
            {
                Sound_effect1 = GameObject.Find("Bow_right").GetComponent<AudioSource>();
            }
            else
            {
                Sound_effect1 = GameObject.Find("Bow_right").GetComponent<AudioSource>();
            }
            Sound_effect1.Play();                                                       //사운드 재생
            Sound_effect2 = GameObject.Find("diffend").GetComponent<AudioSource>();     //막았을때
            Sound_effect3 = GameObject.Find("hit").GetComponent<AudioSource>();         //맞았을때
            dir++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z != -3000)              //z가 -3000이 아니면 발사함
        {
          

            Target = GameObject.Find("Player").transform;

            Vector3 direction = (transform.position - Target.position).normalized;   //내적



            transform.position -= direction * speed * Time.deltaTime;               //해당 방향으로 힘을줌

            //////////////////////////// 히트 판정
            
            if ((transform.position - Target.position).magnitude < 10f && (transform.position - Target.position).magnitude > 1.0f && Movecontroler.action == dir)
            {
                Sound_effect2.Play();   //막음
                Destroy(gameObject);
            }

            if ((transform.position - Target.position).magnitude < 1 )                //화살과 플레이어 간의 거리가 5이면
            {   //막은 소리
                Movecontroler.life--;
                Sound_effect3.Play();
                Destroy(gameObject);                                                //제거
            }
            if (Movecontroler.life <= 0)    //체력이 0이면 삭제
                Destroy(gameObject);

        }
    }
}
