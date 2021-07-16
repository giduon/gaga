using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletMove : MonoBehaviour
{
    // ������ ���� �������� ������ �ϰ�ʹ�. 

   // �����ε� ��ȯ�ڷ����� �Լ� �̸��� ���� �Ű������� �ٸ��� �����ε��� �ȴ�. �� ���� �̸����� �Լ����� �ȴٴ� �� 


    public float speed = 10.0f;
    public GameObject explosionPrefab;

	public enum MoveType
	{
		UserBullet,
		BossMissile
	}

	public MoveType bulletType = MoveType.UserBullet;

	ParticleSystem ps;
	Vector3 dir;

    void Start()
    {
		// ���¿� ���� �Ѿ��� �̵� ������ �����Ѵ�.
		if (bulletType == MoveType.UserBullet)
		{
			dir = Vector3.up;
		}
		else if (bulletType == MoveType.BossMissile)
		{
			dir = transform.up;
		}
    }
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
        //transform.Translate(dir * speed * Time.deltaTime);
    }

	private void OnTriggerEnter(Collider col)
	{
		if (bulletType == MoveType.UserBullet)
		{
			CheckColiidingEnemy(col);
		}
		else if (bulletType == MoveType.BossMissile)
		{
			CheckColiidingPlayer(col);
		}
	}

	void CheckColiidingEnemy(Collider col)
	{
		// ���ʹ����� �ε����� ���ʹ̸� �����ϰ�, ���� �����Ѵ�. 
		if (col.gameObject.tag == "Enemy")
		{
			Destroy(col.gameObject);
			GameManager.gm.AddPoint(10);
			// �ε��� �������κ��� �ݰ� 3������ �� ���·� ���� �ȿ� ������Ʈ���� �����Ѵ�.
			//Collider[] cols= Physics.OverlapSphere(collision.transform.position, 3.0f);

			//// ���� ��󿡼� �±װ� Enemy�� ��쿡�� �� ������Ʈ�� �����Ѵ�. 
			//for (int i = 0; i < cols.Length; i ++)
			//{
			//	if(cols[i].gameObject.tag=="Enemy")
			//	{
			//		Destroy(cols[i].gameObject);
			//	}
			//}
			/*
			foreach(Collider enemy in cols)
			{
				Destroy(enemy.gameObject);
			}
			*/
			// foreach���� get�� �� �� ���� 



			// ���� ����Ʈ�� �����Ѵ�
			GameObject go = Instantiate(explosionPrefab, col.transform.position, Quaternion.identity);
			ps = go.GetComponent<ParticleSystem>();
			ps.Play();
			

			 Destroy(gameObject);
		}
	}

	void CheckColiidingPlayer(Collider col)
	{
		if (col.gameObject.name == "Player")
		{
			GameManager.gm.playerLifeCount--;
			Destroy(gameObject);
		}
	}

}
