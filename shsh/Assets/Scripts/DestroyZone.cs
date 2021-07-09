using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    public PlayerFire pFire;
    

    
	private void OnCollisionEnter(Collision collision)
	{
        // 부딪힌 대상의 이름이 Bullet이라는 글자를 포함하고 있다면..
        if(collision.gameObject.name.Contains("Bullet"))
		{
            // 그 총알을 비활성화 한다. 
            collision.gameObject.SetActive(false);
            // 비활성화된 총알을 탄창 리스트에 추가한다.
            pFire.magazine.Add(collision.gameObject);
		}
        else
		{
            // 나에게 부딪힌 대산을 씬에서 제거한다.
            Destroy(collision.gameObject);
		}
	}
}
