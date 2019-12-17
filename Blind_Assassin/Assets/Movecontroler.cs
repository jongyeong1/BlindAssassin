/* 2016039029 이종영
 * 캐릭터 이동에 대한 정보 스크립트 하나에 모든 게임오브젝트 설정 적용대신
 * 하나의 오브젝트당 하나의 스크립트를 두어 객체화 시키는데 의의를 둠
 * 기본적인 알고리즘은 같은 이름 공유시 동일함
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Windows.Kinect;
/*
   2015041007 문승현 , 2018038007 고의석
   유니티 와 키넥트의 연동부분을 처리하는 기능 구현
   키넥트 센서 작동부분과 코드에서의 작동부분을 분할해서
   봐야하기 때문에 같이 코드 진행함
  */
public class Movecontroler : MonoBehaviour
{
    KinectSensor m_Sensor;
    Body[] m_Body = null;
    BodyFrameReader m_bfReader;
    static public int life = 3;            // 캐릭터 생명력  
    public GameObject player;              // 캐릭터 게임오브젝트 지정
    static public int action = 0;          // 캐릭터 액션 설정
    [SerializeField] 
    CharacterController cc;                // 캐릭터 컨트롤러 설정 y축 값
    
    public float speed = 3.0F;             // z축 이동속도 디폴트 3
    public float jumpSpeed = 4.0F;         // y축 이동속도 디폴트4
    public float gravity = 9.81F;          // 중력 부여 


    private void Start()
    {
        //키넥트센서 부분, 리더 가져온다
        m_Sensor = KinectSensor.GetDefault();
        if (m_Sensor != null)
        {
            m_bfReader = m_Sensor.BodyFrameSource.OpenReader();
            if (!m_Sensor.IsOpen) m_Sensor.Open();
        }
    }
    private Vector3 moveDirection = Vector3.zero;       // 캐릭터 움직임값 변수 설정
    void Update()
    {
        if (cc.isGrounded) // 길위에 존재할 경우
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 30f);  // 기본 이동속도 z 30 y 중력에 비례
            moveDirection = transform.TransformDirection(moveDirection);       // 백터에 따른 방향 제공 ( 일직선 이동이니 사용x)
            
            if (Input.GetButton("Jump"))                                       // 함정 피하기 동작 부여                  
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;                           // y축에 대해 항상 중력값 부여
        action = 0;
        if (m_bfReader != null)//커넥트 센서 부분
        {
            //한 프레임 얻는다
            BodyFrame frame = m_bfReader.AcquireLatestFrame();
            if (frame != null)
            {
                if (m_Body == null)
                    m_Body = new Body[m_Sensor.BodyFrameSource.BodyCount];
                //몸 데이터 갱신
                frame.GetAndRefreshBodyData(m_Body);
                //프레임 해제
                frame.Dispose();
                frame = null;
                //모든 몸 데이터 가져온다
                foreach (Body body in m_Body)
                {
                    if (!body.IsTracked) continue;
                    HandCheck(body.Joints[JointType.HandLeft].Position, body.Joints[JointType.HandRight].Position);
                }
            }
        }
        cc.Move(moveDirection * Time.deltaTime);                               // 캐릭터 움직임
        if (life <= 0)
        {
            SceneManager.LoadScene("Main");
        }
    }

    void OnApplicationQuit()//커넥트 센서 부분 프레임당 센서값을 가져온것을 사용한 이후 해제해줌
    {
        //모든 인스턴스 해제
        if (m_bfReader != null)
        {
            m_bfReader.Dispose();
            m_bfReader = null;
        }
        if (m_Sensor != null)
        {
            if (m_Sensor.IsOpen) m_Sensor.Close();
            m_Sensor = null;
        }
    }
    void HandCheck(CameraSpacePoint p, CameraSpacePoint q)//손부분의 데이터를 받아와서 처리해줌
    {
        if (p.Y > 0.45 && q.Y < 0.45)//왼손 들기
        {
            action = 2;
        }
        else if (p.Y < 0.45 && q.Y > 0.45)//오른손 들기
        {
            action = 3;
        }
        else if (p.Y > 0.45 && q.Y > 0.45)//양손 들기
        {
            action = 1;
        }
    }
}

