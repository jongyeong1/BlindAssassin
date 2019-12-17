/* 2016039029 이종영
 * 라이프 1 에 대한 정보 스크립트 하나에 모든 게임오브젝트 설정 적용대신
 * 하나의 오브젝트당 하나의 스크립트를 두어 객체화 시키는데 의의를 둠
 * 기본적인 알고리즘은 같은 이름 공유시 동일함
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class life1 : MonoBehaviour
{
 
    public GameObject lifep1;                                   // 게임오브젝트 지정

    
    void Update()                      
    {

        if (Movecontroler.life <= 2)                            // 캐릭터 컨트롤러에 있는 life 값이 2 이하일시
        {
            lifep1.GetComponent<Renderer>().enabled = false;    // 랜더링 false - 라이프 소실
        }
        else
        {
            lifep1.GetComponent<Renderer>().enabled = true;     // 아닐시 랜더링 true
        }
    }
}