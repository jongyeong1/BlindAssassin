using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//장병권 2016039036
//함정기능 전반에 대한 처리 
//트랩을 밟는 순간 부터 랜덤으로 arrow 생성(통나무도 할 수 있으면 구현 하는게 좋을듯)
public class trap : MonoBehaviour
{
    public float logtime=0.0f;
    public Vector3 pos;
    public bool key = false;            // Trap 작동      게임 종료나 맵 끝에 도착하면 false로 다시 바꾸어주면 된다.

    public int Level = 1;          //최대 2까지
    int ran = 0;                //랜덤 값을 집어넣어서 어느방향에서 날아올지 정함
    int dir;
    Transform Target;
    GameObject Trap;
    public bool Tree_Trap = false;  //통나무 함정 여부

    public float TimeLeft = 1.5f;
    public float nextTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Character").transform.position.x >= 40f)           //final step
            Level = 2;
    }


    void Log_trap()//통나무를 생성하는 기능       //마지막 수정 2015041007 문승현 통나무 충돌 여부 확을 위해서 수정
    {
        Vector3 Cposition = GameObject.Find("Character").transform.position;//캐릭터의 위치
        Cposition.y += 10.0f;
        Cposition.z += 40.0f;//통나무 생성 위치 조정 필요(캐릭터의 위치에서 좌표값을 추가시켜서 생성함)
        Trap = Instantiate(GameObject.FindWithTag("Log1"), Cposition, Quaternion.identity);//오브젝트를 생성하는 기능인 instantiate함수 실행
        Log.dodge = 1;
        
    }


    void Arrow_Trap()       //호출시 Arrow 생성
    {
        dir = Random.Range(0, 2);     //방향 난수 생성 0이면 플레이어기준 왼쪽으로 1이면 오른쪽으로 생성

        Target = GameObject.Find("Player").transform;   //플레이어의 좌표 저장

        if (dir == 0)//왼쪽  생성
        {
            Trap = (GameObject)Instantiate(GameObject.Find("Arrow"), new Vector3(Target.position.x - 30, 15f, Target.position.z + 300), Quaternion.Euler(10, 165.0f, 0));
            Trap.GetComponent<arrow>().dir = 1;
        }
        if (dir == 1)//오른쪽 생성
        {
            Trap = (GameObject)Instantiate(GameObject.Find("Arrow"), new Vector3(Target.position.x + 30, 15f, Target.position.z + 300), Quaternion.Euler(10, 195.0f, 0));
            Trap.GetComponent<arrow>().dir = 2;
        }

    }
    // Update is called once per frame
    void Update()

    {

        Target = GameObject.Find("Player").transform;          //플레이어의 좌표 받기

        if ((transform.position - Target.transform.position).magnitude <= 5)      //trap과 간격이 5 이하(거의 밟음) 즉 밟으면
        {
            key = true;
        }

        if (Movecontroler.life == 0)              //죽음
        {
            key = false;
        }

        if (key)  //player 통나무 소환시 쉬어야함
        {
            ran = Random.Range(0, Level);       //0~level(함정 고르기)   level이 2이면 통나무도 소환 가능

            if (Time.time > nextTime)      //2초마다 한번 부름
            {
                nextTime = Time.time + TimeLeft;
                if (ran == 0 && !Tree_Trap)
                {
                    Arrow_Trap();

                }
                else if (!Tree_Trap)                   //ran ==1 && Tree_Trap = False
                {
                    Log_trap();
                    Tree_Trap = true;
                    Debug.Log(Tree_Trap);
                    //통나무 생성            ->통나무 안에서 처리를 
                }
            }
   
        }
        if (Tree_Trap == true)//통나무가 생성이 되어 있으면
        {
            logtime += Time.deltaTime;//시간을 계산하고
            Debug.Log(logtime);
            if(0.9f>logtime)//통나무 생성된지 1.0초 안에 양팔든 코드가 입력되면 회피실행
            {
                if(Movecontroler.action==1)
                {
                    Log.dodge = 0;
                }
            }
            else if(logtime>0.9f)//시간 초과시 초기화
            {
                logtime = 0;
            }
        }
    }
}
