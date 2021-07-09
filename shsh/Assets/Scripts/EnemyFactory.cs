using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    // ������ �ð����� ���ʹ̸� �����ϰ� �ʹ�. 
    // �ʿ� ��� : �ð�, ���ʹ� ������Ʈ ����, ���� ��ġ

    public float delayTime = 2.0f;
    public GameObject enemy;

    public float currentTime = 0;

    void Start()
    {
        
    }

    void Update()
    {
        // ����, ������ �ð��� �Ǿ�����..
        if (delayTime <= currentTime)
		{
			// ���ʹ� ������Ʈ�� �����Ѵ�.
			Instantiate(enemy,transform.position, Quaternion.identity);
            
            currentTime = 0;
		}
		// �׷��� �ʴٸ�...
		else
		{
            // ���� ������ �ð��� ������Ų��.
            currentTime += Time.deltaTime;
        }
	}
}
