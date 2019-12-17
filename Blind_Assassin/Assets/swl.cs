﻿/* 2016039029 이종영
 * 왼쪽 막기 에 대한 정보 스크립트 하나에 모든 게임오브젝트 설정 적용대신
 * 하나의 오브젝트당 하나의 스크립트를 두어 객체화 시키는데 의의를 둠
 * 기본적인 알고리즘은 같은 이름 공유시 동일함
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class swl : MonoBehaviour
{
    public GameObject leftshiled;                    // 좌측 막기 애니메이션 적용 게임오브젝트
    public GameObject lkata;                         // 자식오브젝트 중 검
    public GameObject lhand;                         // 자식오브젝트 중 팔뚝
    public GameObject lhand2;                        // 자식오브젝트 중 어깨
    public RuntimeAnimatorController ss;             // 에니메이터 연속수행 좌측막기 

    bool bb = false;                                 // 동작수행 여부

    public Animator ani;                             // 애니메이터 좌측막기

    void Update()
    {
        leftshiled.GetComponent<Renderer>().enabled = false;    // 디폴트 - 랜더링 제거 (동작시 랜더링 팝)
        if (Input.GetKey(KeyCode.LeftArrow))                    // 좌측손 동작시 
        {
            Movecontroler.action = 2;                           // 캐릭터 컨트롤러 액션값 2 부여
            lkata.GetComponent<Renderer>().enabled = true;      // 동작수행전 랜더링 돌려주기 작업
            //lhand.GetComponent<Renderer>().enabled = true;    // 부자연스러워서 제거 
            lhand2.GetComponent<Renderer>().enabled = true;     // 작업 2
            bb = true;                                          // 애니메이터 동작 수행 
        }
        else 
        {
            if(Input.GetKey(KeyCode.RightArrow))
            {

            }
            else 
            { 
               lkata.GetComponent<Renderer>().enabled = false;     // 랜더링 하이드
               lhand.GetComponent<Renderer>().enabled = false;
               lhand2.GetComponent<Renderer>().enabled = false;    
               bb = false;       
            }// 애니메이터 동작 대기
        }

        ani.SetBool("left", bb);                                // bb를 애니메이터 동작 조건 left로 지정



    }
}