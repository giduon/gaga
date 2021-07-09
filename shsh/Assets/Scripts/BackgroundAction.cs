using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAction : MonoBehaviour
{
    // 배경 이미지를 아래쪽 방향으로 스크롤 시키고 싶다. 
    // 스크롤 방향, 스크롤 속력, Material과 uv(xy)축

    public float scrollSpeed = 1.0f;
    Material backMat;

    void Start()
    {
        //mesh Renderer에서 Material을 가져온다
        backMat = GetComponent<MeshRenderer>().materials[0];
    }

    void Update()
    {
        // Material의 uv offset에서 y축 값을 증가시킨다
        backMat.mainTextureOffset += new Vector2(0,1)* scrollSpeed * Time.deltaTime;
    }
}
