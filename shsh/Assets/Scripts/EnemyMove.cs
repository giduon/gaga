using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	// 태어나면 지정된 확률에 따라서
	// 플레이어를 쫒아가거나(70%)
	// 아래로 내려가겠다(30%)
	// 필요 요소 : 확률 변수

	public float speed = 4.0f;
    public float probability = 70.0f;

    GameObject player;
    Vector3 dir;

    Animation myAnim;
    

    // 확률증명
    public int[] checkRandom = new int[2];


	void Start()
    {
        myAnim = GetComponentInChildren<Animation>();
        myAnim.Play();

        //CheckResult();

        // 1. 랜덤한(1~100) 값을 추첨한다.
        int result = Random.Range(1,101);

        // 2. 추첨된 값이 확률 변수의 값 이하일 경우 이동 뱡향을 플레이어쪽으로 한다. ]
        if (result <= probability)
        {
            
            player = GameObject.Find("Player");
            if(player != null)
			{
                dir = player.transform.position - transform.position;
                dir.Normalize();
			}
            else
            {
                dir = Vector3.down;
            }

        }
            // 3. 그렇지 않고 추첨된 값이 확률 변수 값을 초과할 경우 이동방향을 아래쪽으로 정한다. 
		else
		{
            dir = Vector3.down;
		}
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

	// 플레이어와 충돌하면 플레이어를 제거하고 나도 제거한다.

	private void OnTriggerEnter(Collider collision)
	{
        if (collision.gameObject.layer == 6)
        {
            Destroy(collision.gameObject);

            GameManager.gm.SetActiveUI(true);

            Destroy(gameObject);
        }
    }

	// 확률 검증
	void CheckResult()
	{
        for (int i = 0; i <1000000; i++)
		{
            int result = Random.Range(1, 101);

            if(result <= 70)
			{
                checkRandom[0]++;
			}
			else
			{
                checkRandom[1]++;
            }
		}
	}

}
