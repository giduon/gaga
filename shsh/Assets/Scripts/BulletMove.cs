using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // ������ ���� �������� ������ �ϰ�ʹ�. 

   // �����ε� ��ȯ�ڷ����� �Լ� �̸��� ���� �Ű������� �ٸ��� �����ε��� �ȴ�. �� ���� �̸����� �Լ����� �ȴٴ� �� 


    public float speed = 10.0f;
    public GameObject explosionPrefab;

    ParticleSystem ps;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.position += Vector3.up * speed * Time.deltaTime;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

	private void OnCollisionEnter(Collision collision)
	{
		// ���ʹ����� �ε����� ���ʹ̸� �����ϰ�, ���� �����Ѵ�. 
		if (collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
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
			GameObject go = Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
			ps = go.GetComponent<ParticleSystem>();
			ps.Play();
			

			 Destroy(gameObject);
		}
	}
}
