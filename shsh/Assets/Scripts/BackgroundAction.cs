using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAction : MonoBehaviour
{
    // ��� �̹����� �Ʒ��� �������� ��ũ�� ��Ű�� �ʹ�. 
    // ��ũ�� ����, ��ũ�� �ӷ�, Material�� uv(xy)��

    public float scrollSpeed = 1.0f;
    Material backMat;

    void Start()
    {
        //mesh Renderer���� Material�� �����´�
        backMat = GetComponent<MeshRenderer>().materials[0];
    }

    void Update()
    {
        // Material�� uv offset���� y�� ���� ������Ų��
        backMat.mainTextureOffset += new Vector2(0,1)* scrollSpeed * Time.deltaTime;
    }
}
