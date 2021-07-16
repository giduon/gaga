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
        // ������ ���� ã�´�.
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
        // ���� ������������ �Ÿ��� 0.05���� �̳���� �������� ���� ��ġ��Ų��.
        if (Vector3.Distance(transform.position, basePosition.position) < 0.05f)
        {
            transform.position = basePosition.position;
            bState = BossState.Pattern1;
        }
        // �׷��� �ʴٸ�, �Ʒ��� ���� �ӵ��� ��������.
        else
        {
            transform.position += Vector3.down * 4.0f * Time.deltaTime;
        }
    }

    //  �� �ѱ����� �Ѿ��� �߻��ϸ鼭 �¿�� ��ü�� �̵��Ѵ�.
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

        // ������� �̵� ��� 1
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
        //    // �Ѿ� �߻� ���� ������
        //    CancelInvoke();
        //}
        #endregion

        // ������� �̵� ��� 2
        #region
        //if (currentTime < 2.0f)
        //{
        //    float temp = Mathf.Sin(currentTime * Mathf.PI) * 5.0f;
        //    transform.position = basePosition.position + new Vector3(temp, 0, 0);
        //}
        //else
        //{
        //    // �Ѿ� �߻� ���� ������
        //    CancelInvoke();
        //}
        #endregion

        // ������� �̵� ��� 3
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
            // �Ѿ� �߻� ���� ������
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
        // �Ѿ� �߻�
        for (int i = 0; i < firePosition.Length; i++)
        {
            Instantiate(missileFactory, firePosition[i].position, Quaternion.Euler(new Vector3(0, 0, 180.0f)));
        }
    }

    // 1. 22.5�� �������� 4ȸ �̻����� �����Ѵ�.
    // 2. ���� ������ �� �� �ִ�.
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
                // ������ ó��
                //Instantiate(missileFactory, firePosition[0].position,
                //            Quaternion.Euler(new Vector3(0, 0, 110.0f + 22.5f * fireCount) * Mathf.Pow(-1, (i+1))));

                // Ȧ�� ¦�� ó��
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
