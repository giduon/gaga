using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    public PlayerFire pFire;
    

    
	private void OnCollisionEnter(Collision collision)
	{
        // �ε��� ����� �̸��� Bullet�̶�� ���ڸ� �����ϰ� �ִٸ�..
        if(collision.gameObject.name.Contains("Bullet"))
		{
            // �� �Ѿ��� ��Ȱ��ȭ �Ѵ�. 
            collision.gameObject.SetActive(false);
            // ��Ȱ��ȭ�� �Ѿ��� źâ ����Ʈ�� �߰��Ѵ�.
            pFire.magazine.Add(collision.gameObject);
		}
        else
		{
            // ������ �ε��� ����� ������ �����Ѵ�.
            Destroy(collision.gameObject);
		}
	}
}
