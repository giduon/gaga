using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 사용자의 상하좌우 키를 입력하여 오브젝트를 움직이고 싶다. 
    // 입력 방식 : 화살표 키의 상하좌우 또는 WASD 키
    // 필요 요소 : 속도(방향 + 속력), 사용자 키입력  


    // 이동 속도
    public float moveSpeed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        // 상하 좌우 입력 받기
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 받은 입력값을 방향 값으로 만들고 싶다. 
        Vector3 dir = new Vector3(h, v, 0);
        // 대각 방향 이동속도 정규화
        dir.Normalize();

        // P = P0 + vt
        transform.position += dir * moveSpeed * Time.deltaTime;


		// 1. 플레이어의 위치를 뷰포트 좌표로 변환한다. 
		Vector3 playerViewPos = Camera.main.WorldToViewportPoint(transform.position);
		// 2. 변환된 뷰포트 좌표의 값이 0~1 사이를 벗어나지 못하도록 한다.
		playerViewPos.x = Mathf.Clamp01(playerViewPos.x);
		playerViewPos.y = Mathf.Clamp01(playerViewPos.y);
		// 3. 계산된 뷰포트 값을 플레이어의 위치 값으로 적용한다. 
		Vector3 playerWorldPos = Camera.main.ViewportToWorldPoint(playerViewPos);
		transform.position = playerWorldPos;


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 15.0f;
            Invoke("Dashout", 0.1f);
        }

    }
        void Dashout()
		{
        moveSpeed = 5.0f;

    }
}
