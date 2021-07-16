using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	// �¾�� ������ Ȯ���� ����
	// �÷��̾ �i�ư��ų�(70%)
	// �Ʒ��� �������ڴ�(30%)
	// �ʿ� ��� : Ȯ�� ����

	public float speed = 4.0f;
    public float probability = 70.0f;

    GameObject player;
    Vector3 dir;

    Animation myAnim;
    

    // Ȯ������
    public int[] checkRandom = new int[2];


	void Start()
    {
        myAnim = GetComponentInChildren<Animation>();
        myAnim.Play();

        //CheckResult();

        // 1. ������(1~100) ���� ��÷�Ѵ�.
        int result = Random.Range(1,101);

        // 2. ��÷�� ���� Ȯ�� ������ �� ������ ��� �̵� ������ �÷��̾������� �Ѵ�. ]
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
            // 3. �׷��� �ʰ� ��÷�� ���� Ȯ�� ���� ���� �ʰ��� ��� �̵������� �Ʒ������� ���Ѵ�. 
		else
		{
            dir = Vector3.down;
		}
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

	// �÷��̾�� �浹�ϸ� �÷��̾ �����ϰ� ���� �����Ѵ�.

	private void OnTriggerEnter(Collider collision)
	{
        if (collision.gameObject.layer == 6)
        {
            Destroy(collision.gameObject);

            GameManager.gm.SetActiveUI(true);

            Destroy(gameObject);
        }
    }

	// Ȯ�� ����
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
