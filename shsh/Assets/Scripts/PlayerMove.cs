using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // ������� �����¿� Ű�� �Է��Ͽ� ������Ʈ�� �����̰� �ʹ�. 
    // �Է� ��� : ȭ��ǥ Ű�� �����¿� �Ǵ� WASD Ű
    // �ʿ� ��� : �ӵ�(���� + �ӷ�), ����� Ű�Է�  


    // �̵� �ӵ�
    public float moveSpeed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        // ���� �¿� �Է� �ޱ�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // ���� �Է°��� ���� ������ ����� �ʹ�. 
        Vector3 dir = new Vector3(h, v, 0);
        // �밢 ���� �̵��ӵ� ����ȭ
        dir.Normalize();

        // P = P0 + vt
        transform.position += dir * moveSpeed * Time.deltaTime;


		// 1. �÷��̾��� ��ġ�� ����Ʈ ��ǥ�� ��ȯ�Ѵ�. 
		Vector3 playerViewPos = Camera.main.WorldToViewportPoint(transform.position);
		// 2. ��ȯ�� ����Ʈ ��ǥ�� ���� 0~1 ���̸� ����� ���ϵ��� �Ѵ�.
		playerViewPos.x = Mathf.Clamp01(playerViewPos.x);
		playerViewPos.y = Mathf.Clamp01(playerViewPos.y);
		// 3. ���� ����Ʈ ���� �÷��̾��� ��ġ ������ �����Ѵ�. 
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
