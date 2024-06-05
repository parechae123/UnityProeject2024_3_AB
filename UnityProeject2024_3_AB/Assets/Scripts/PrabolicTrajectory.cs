using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrabolicTrajectory : MonoBehaviour
{
    public Slider sliderAngle;
    public Slider sliderDirection;
    public Slider sliderPower;


    public LineRenderer lineRenderer;       //Line Renderer 컴포넌트 할당
            
    public int resolution = 30;             //궤적을 그릴 때 사용할 점의 개수
    public float timeStep = 0.1f;           //궤적의 시간 간격(0.1초마다 점을 찍음)

    public Transform launchPoint;       //발사 위치를 나타내는 트랜스폼
    public Transform pivotPoint;        

    public float launchPower;           //발사 속도
    public float launchAngle;           //발사 각도 (도 단위)
    public float launchDirection;       //발사 방향(XZ 평면에서의 각도, 도 단위)
    public float gravity = -9.8f;        //중력 값

    public GameObject projectilePrefabs;            //발사할 물체의 프리팹

    void Start()
    {
        lineRenderer.positionCount = resolution;            //LineRenderer의 점 개수를 설정

        sliderAngle.onValueChanged.AddListener(SliderAngleValue);
        sliderDirection.onValueChanged.AddListener(SliderDirValue);
        sliderPower.onValueChanged.AddListener(SliderPowerValue);
    }

    // Update is called once per frame
    void Update()
    {
        RenderTrajectory();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject temp = Instantiate(projectilePrefabs);
            LaunchProjectile(temp);
        }
    }

    public void SliderAngleValue(float angle)
    {
        launchAngle = angle;
    }
    public void SliderDirValue(float dir)
    {
        launchDirection = dir;
    }
    public void SliderPowerValue(float pow)
    {
        launchPower = pow;
    }



    /// <summary>
    /// 궤적을 계산하고 LineRenderer에 설정하는 함수
    /// </summary>
    void RenderTrajectory()         
    {
        lineRenderer.positionCount = resolution;            //LineRenderer의 점 개수를 설정
        Vector3[] points = new Vector3[resolution];     //궤적 점들을 저장할 배열

        for (int i = 0; i < resolution; i++)            //각 시간 마다 점의 위치를 계산
        {
            float time = i * timeStep;                  //현재 시간 계산
            points[i] = CalculatePositionAtTime(time);
        }
        lineRenderer.SetPositions(points);              //라인 렌더러에 포인트 값들을 넘긴다.
    }

    Vector3 CalculatePositionAtTime(float time)         //주어진 시간에서 물체의 위치를 계싼하는 함수
    {
        float launchAngleRad = Mathf.Deg2Rad * launchAngle;         //발사 각도를 라디안으로 변환
        float launchDirectionRad = Mathf.Deg2Rad * launchDirection;     //발사 방향을 라디안으로 변환

        //시간 t에서의 x,y,z 좌표 계산

        float x = launchPower * time * Mathf.Cos(launchAngleRad) * Mathf.Cos(launchDirectionRad);
        float z = launchPower * time * Mathf.Cos(launchAngleRad) * Mathf.Sin(launchDirectionRad);
        float y = launchPower * time * Mathf.Sin(launchAngleRad) + 0.5f * gravity * time * time;

        return launchPoint.position + new Vector3(x, y, z);
    }

    public void LaunchProjectile(GameObject projectile)
    {
        projectile.transform.position = launchPoint.position;
        projectile.transform.rotation = launchPoint.rotation;
        projectile.transform.SetParent(null);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;

            //발사 각도와 방향을 라디안으로 변환
            float launchAngleRad = Mathf.Deg2Rad * launchAngle;         //발사 각도를 라디안으로 변환
            float launchDirectionRad = Mathf.Deg2Rad * launchDirection;     //발사 방향을 라디안으로 변환

            float initialVelocityX = launchPower * Mathf.Cos(launchAngleRad) * Mathf.Cos(launchDirectionRad);
            float initialVelocityZ = launchPower * Mathf.Cos(launchAngleRad) * Mathf.Sin(launchDirectionRad);
            float initialVelocityY = launchPower * Mathf.Sin(launchAngleRad);

            Vector3 initialVelocity = new Vector3(initialVelocityX, initialVelocityY, initialVelocityZ);

            rb.velocity = initialVelocity;
        }
    }
}
