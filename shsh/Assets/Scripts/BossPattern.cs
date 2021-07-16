using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    public GameObject missileFactory;
    public Transform[] firePosition = new Transform[2];
    public Transform basePosition;
    public float delayTime = 0.2f;

    float currentTime = 0;
    bool startFire = true;

    int fireCount = 0;

    enum BossState
    {
        EMERGE,
        Pattern1,
        Pattern2
    }
    BossState bState = BossState.EMERGE;

    void Start()
    {
        // 등장할 곳을 찾는다.
        basePosition = GameObject.Find("BossBasePoint").transform;
    }

    void Update()
    {
        switch (bState)
        {
            case BossState.EMERGE:
                BossEmergeProcess();
                break;
            case BossState.Pattern1:
                StartPattern1();
                break;
            case BossState.Pattern2:
                StartPattern2();
                break;
        }
    }

    void BossEmergeProcess()
    {
        // 만일 도착지까지의 거리가 0.05미터 이내라면 도착지에 나를 위치시킨다.
        if (Vector3.Distance(transform.position, basePosition.position) < 0.05f)
        {
            transform.position = basePosition.position;
            bState = BossState.Pattern1;
        }
        // 그렇지 않다면, 아래로 일정 속도로 내려간다.
        else
        {
            transform.position += Vector3.down * 4.0f * Time.deltaTime;
        }
    }

    //  두 총구에서 총알을 발사하면서 좌우로 몸체를 이동한다.
    void StartPattern1()
    {
        if (startFire)
        {
            InvokeRepeating("FireType1", 0, delayTime);
            startFire = false;
        }

        Pattern1();
    }


    void Pattern1()
    {
        currentTime += Time.deltaTime;

        // 지그재그 이동 방식 1
        #region
        //if (currentTime <= 1.0f)
        //{
        //    transform.position = Vector3.Lerp(basePosition.position, basePosition.position + new Vector3(5, 0, 0), currentTime);
        //}
        //else if (currentTime <= 3.0f)
        //{
        //    float myTime = (currentTime - 1.0f) * 0.5f;
        //    transform.position = Vector3.Lerp(basePosition.position + new Vector3(5, 0, 0), basePosition.position + new Vector3(-5, 0, 0), myTime);
        //}
        //else if (currentTime <= 4.0f)
        //{
        //    transform.position = Vector3.Lerp(basePosition.position + new Vector3(-5, 0, 0), basePosition.position, currentTime - 3.0f);
        //}
        //else
        //{
        //    // 총알 발사 예약 끝내기
        //    CancelInvoke();
        //}
        #endregion

        // 지그재그 이동 방식 2
        #region
        //if (currentTime < 2.0f)
        //{
        //    float temp = Mathf.Sin(currentTime * Mathf.PI) * 5.0f;
        //    transform.position = basePosition.position + new Vector3(temp, 0, 0);
        //}
        //else
        //{
        //    // 총알 발사 예약 끝내기
        //    CancelInvoke();
        //}
        #endregion

        // 지그재그 이동 방식 3
        #region
        float temp = Mathf.PingPong(currentTime * 5.0f, 5);

        if (currentTime <= 2.0f)
        {
            transform.position = basePosition.position + new Vector3(temp, 0, 0);
        }
        else if (currentTime <= 4.0f)
        {
            transform.position = basePosition.position + new Vector3(-temp, 0, 0);
        }
        else if (currentTime < 7.0f)
        {
            // 총알 발사 예약 끝내기
            CancelInvoke();
        }
        else
        {
            bState = BossState.Pattern2;
        }
        #endregion
    }

    void FireType1()
    {
        // 총알 발사
        for (int i = 0; i < firePosition.Length; i++)
        {
            Instantiate(missileFactory, firePosition[i].position, Quaternion.Euler(new Vector3(0, 0, 180.0f)));
        }
    }

    // 1. 22.5도 간격으로 4회 미사일을 생성한다.
    // 2. 생성 간격을 줄 수 있다.
    void StartPattern2()
    {
        if (startFire)
        {
            currentTime = 0;
            startFire = false;
        }

        Pattern2();
    }

    void Pattern2()
    {
        currentTime += Time.fixedDeltaTime;

        if (currentTime > delayTime && fireCount < 4)
        {
            for (int i = 0; i < firePosition.Length; i++)
            {
                // 제곱근 처리
                //Instantiate(missileFactory, firePosition[0].position,
                //            Quaternion.Euler(new Vector3(0, 0, 110.0f + 22.5f * fireCount) * Mathf.Pow(-1, (i+1))));

                // 홀수 짝수 처리
                float iter = 0;

                if (i % 2 == 0)
                {
                    iter = -1.0f;
                }
                else
                {
                    iter = 1.0f;
                }

                Instantiate(missileFactory, firePosition[i].position,
                            Quaternion.Euler(new Vector3(0, 0, 110.0f + 22.5f * fireCount) * iter));
            }
            fireCount++;
            //print(fireCount);
            currentTime = 0;
        }
    }
}
