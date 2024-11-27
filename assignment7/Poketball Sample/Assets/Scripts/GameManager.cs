using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    UIManager MyUIManager;

    public GameObject BallPrefab;   // prefab of Ball

    // Constants for SetupBalls
    public static Vector3 StartPosition = new Vector3(0, 0, -6.35f);
    public static Quaternion StartRotation = Quaternion.Euler(0, 90, 90);
    const float BallRadius = 0.286f;
    const float RowSpacing = 0.02f;

    GameObject PlayerBall;
    GameObject CamObj;

    const float CamSpeed = 3f;

    const float MinPower = 15f;
    const float PowerCoef = 1f;

    void Awake()
    {
        // PlayerBall, CamObj, MyUIManager를 얻어온다.
        // ---------- TODO ---------- 
        PlayerBall = GameObject.Find("PlayerBall");
        CamObj = GameObject.Find("Main Camera");
        MyUIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        // -------------------- 
    }

    void Start()
    {
        SetupBalls();
    }

    // Update is called once per frame
    void Update()
    {
        // 좌클릭시 raycast하여 클릭 위치로 ShootBallTo 한다.
        // ---------- TODO ---------- 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200f)){
                ShootBallTo(hit.point);
            }
        }
        // -------------------- 
    }

    void LateUpdate()
    {
        CamMove();
    }

    void SetupBalls()
    {
        // 15개의 공을 삼각형 형태로 배치한다.
        // 가장 앞쪽 공의 위치는 StartPosition이며, 공의 Rotation은 StartRotation이다.
        // 각 공은 RowSpacing만큼의 간격을 가진다.
        // 각 공의 이름은 {index}이며, 아래 함수로 index에 맞는 Material을 적용시킨다.
        // Obj.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/ball_1");
        // ---------- TODO ---------- 
            for(int i = 1; i <=5; i++)
        {
            if (i == 1)
            {
                GameObject Ball_object = Instantiate(BallPrefab, StartPosition, StartRotation);
                Ball_object.name = i.ToString();
                Ball_object.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/ball_" +i.ToString());
            }else{
                StartPosition -= new Vector3(BallRadius + RowSpacing, 0, 2*BallRadius + RowSpacing );
                for (int j = 1; j <= i; j++)
                {
                    GameObject Ball_Object_2 = Instantiate(BallPrefab, StartPosition + (j - 1) * new Vector3(2*BallRadius + RowSpacing, 0, 0), StartRotation);
                    Ball_Object_2.name = ((i-1)*(i)/2 + j).ToString();
                    Ball_Object_2.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/ball_" + ((i - 1) * (i) / 2 + j).ToString());
                }
            }

        }

        // -------------------- 
    }
    void CamMove()
    {
        // CamObj는 PlayerBall을 CamSpeed의 속도로 따라간다.
        // ---------- TODO ---------- 
        CamObj.transform.position += new Vector3(PlayerBall.transform.position.x - CamObj.transform.position.x,
            0,PlayerBall.transform.position.z - CamObj.transform.position.z) * Time.deltaTime * CamSpeed;
        // -------------------- 
    }

    float CalcPower(Vector3 displacement)
    {
        return MinPower + displacement.magnitude * PowerCoef;
    }

    void ShootBallTo(Vector3 targetPos)
    {
        // targetPos의 위치로 공을 발사한다.
        // 힘은 CalcPower 함수로 계산하고, y축 방향 힘은 0으로 한다.
        // ForceMode.Impulse를 사용한다.
        // ---------- TODO ---------- 
        PlayerBall.GetComponent<Rigidbody>().AddForce(new Vector3(targetPos.x - PlayerBall.transform.position.x,0, targetPos.z - PlayerBall.transform.position.z)
            *Time.deltaTime* CalcPower(targetPos - PlayerBall.transform.position)*7f, ForceMode.Impulse);
        // -------------------- 
    }
    
    // When ball falls
    public void Fall(string ballName)
    {
        // "{ballName} falls"을 1초간 띄운다.
        // ---------- TODO ---------- 
        MyUIManager.DisplayText(ballName+" falls", 1f);
        // -------------------- 
    }
}
