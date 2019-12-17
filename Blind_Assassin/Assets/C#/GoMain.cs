using UnityEngine;
using System.Collections;
using Windows.Kinect;
using UnityEngine.SceneManagement;
/*
 2015041007 문승현 , 2018038007 고의석
 유니티 와 키넥트의 연동부분을 처리하는 기능 구현
 키넥트 센서 작동부분과 코드에서의 작동부분을 분할해서
 봐야하기 때문에 같이 코드 진행함
     */
public class GoMain : MonoBehaviour
{
    KinectSensor m_Sensor;
    Body[] m_Body = null;
    BodyFrameReader m_bfReader;
    [SerializeField]
    int key = 0;
    // Use this for initialization
    void Start()
    {
        //키넥트센서, 리더 가져온다
        m_Sensor = KinectSensor.GetDefault();
        if (m_Sensor != null)
        {
            m_bfReader = m_Sensor.BodyFrameSource.OpenReader();
            if (!m_Sensor.IsOpen) m_Sensor.Open();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bfReader != null)
        {
            //한 프레임 얻는다
            BodyFrame frame = m_bfReader.AcquireLatestFrame();
            if (frame != null)
            {
                Debug.Log("1");
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
        if(key!=0)
        {
            SceneManager.LoadScene("FirstStep");
        }

    }
    void OnApplicationQuit()
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
            key = 2;
        }
        else if (p.Y < 0.45 && q.Y > 0.45)//오른손 들기
        {
            key = 3;
        }
        else if (p.Y > 0.45 && q.Y > 0.45)//양손 들기
        {
            key = 1;
        }
    }
}
