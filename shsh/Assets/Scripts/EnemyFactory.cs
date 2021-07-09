using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    // 일정한 시간마다 에너미를 생성하고 싶다. 
    // 필요 요소 : 시간, 에너미 오브젝트 원본, 생성 위치

    public float delayTime = 2.0f;
    public GameObject enemy;

    public float currentTime = 0;

    void Start()
    {
        
    }

    void Update()
    {
        // 만일, 지정된 시간이 되었으면..
        if (delayTime <= currentTime)
		{
			// 에너미 오브젝트를 생성한다.
			Instantiate(enemy,transform.position, Quaternion.identity);
            
            currentTime = 0;
		}
		// 그렇지 않다면...
		else
		{
            // 현재 프레임 시간을 누적시킨다.
            currentTime += Time.deltaTime;
        }
	}
}
