using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // 무조껀 위쪽 방향으로 나가게 하고싶다. 

   // 오버로딩 반환자료형과 함수 이름은 같고 매개변수만 다르면 오버로딩이 된다. 곧 같은 이름으로 함수선언 된다는 말 


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
		// 에너미한테 부딪히면 에너미를 제거하고, 나도 제거한다. 
		if (collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
			// 부딪힌 지점으로부터 반경 3미터의 구 형태로 범위 안에 오브젝트들을 검출한다.
			//Collider[] cols= Physics.OverlapSphere(collision.transform.position, 3.0f);

			//// 검출 대상에서 태그가 Enemy인 경우에는 그 오브젝트를 제거한다. 
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
			// foreach문은 get만 할 때 쓴다 



			// 폭발 이펙트를 실행한다
			GameObject go = Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
			ps = go.GetComponent<ParticleSystem>();
			ps.Play();
			

			 Destroy(gameObject);
		}
	}
}
