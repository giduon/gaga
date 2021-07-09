using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerFire : MonoBehaviour
{
    // 만일, 마우스 좌클릭을 하면 총알을 생성하고 싶다 

    public GameObject bulletFactory;
    public Transform firePosition;
    public GameObject wareHouse;
    AudioSource audioSource;

    [Range(1, 5)]
    public int bulletCount=1;

    //public GameObject[] magazine = new GameObject[20];
    public List<GameObject> magazine = new List<GameObject>();

    void Start()
    {
        
        // 탄창 배열을 만들어서 20발의 총알을 장전해 논다. 
        for(int i =0; i<20; i++)
		{
            GameObject go = Instantiate(bulletFactory);
            magazine.Add(go);

            //생성된 총알을 플레이어의 자식 오브젝트로 등록한다. 
            go.transform.parent = wareHouse.transform;
            //생성된 총알을 비활성화한다.
            go.SetActive(false);
		}
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if(!EventSystem.current.currentSelectedGameObject)
            { 

            //  FireStyle1();
            // FireStyle2();

            // 만일,탄창에 총알이 있다면
            if (magazine.Count > 0)
			{

                // 탄창의 첫 번째 총알을 활성화시킨다.
                magazine[0].SetActive(true);
                // 활성화된 총알을 총구에 위치시킨다.
                magazine[0].transform.position = firePosition.position;
                // 활성화된 총알을 탄창에서 제거한다. 
                magazine.RemoveAt(0);
			}

                // 총알 발사 사운드를 플레이한다.
                audioSource.Play();
            }
        }


        //null체크: 오류안나는대신 오류를 눈치못챌수도..런칭 때 사용
  //      if (bulletFactory != null)
		//{
		//	Instantiate(bulletFactory);
		//}

	}
	void FireStyle1()
    {
       
            GameObject go = Instantiate(bulletFactory);
            go.transform.position = transform.position + Vector3.up * 2;


            switch (bulletCount)
            {

                case 2:
                    go = Instantiate(bulletFactory);
                    go.transform.position = transform.position + Vector3.up * 2 + Vector3.left * 0.5f;
                    break;
                case 3:
                    go = Instantiate(bulletFactory);
                    go.transform.position = transform.position + Vector3.up * 2 + Vector3.left * 0.5f;
                    go = Instantiate(bulletFactory);
                    go.transform.position = transform.position + Vector3.up * 2 + Vector3.right * 0.5f;
                    break;
                case 4:
                    go = Instantiate(bulletFactory);
                    go.transform.position = transform.position + Vector3.up * 2 + Vector3.left * 0.5f;
                    go = Instantiate(bulletFactory);
                    go.transform.position = transform.position + Vector3.up * 2 + Vector3.right * 0.5f;
                    go = Instantiate(bulletFactory);
                    go.transform.position = transform.position + Vector3.up * 2 + Vector3.left * 1;
                    break;
                case 5:
                    go = Instantiate(bulletFactory);
                    go.transform.position = transform.position + Vector3.up * 2 + Vector3.left * 0.5f;
                    go = Instantiate(bulletFactory);
                    go.transform.position = transform.position + Vector3.up * 2 + Vector3.right * 0.5f;
                    go = Instantiate(bulletFactory);
                    go.transform.position = transform.position + Vector3.up * 2 + Vector3.left * 1;
                    go = Instantiate(bulletFactory);
                    go.transform.position = transform.position + Vector3.up * 2 + Vector3.right * 1;
                    break;

            }
    }

    void FireStyle2()
    {
            GameObject go = Instantiate(bulletFactory);
            go.transform.position = transform.position + Vector3.up * 2;
            for (int i = 0; i < bulletCount - 1; i++)
            {

                go = Instantiate(bulletFactory);
                go.transform.position = transform.position + Vector3.up * 2 + Vector3.right * (i + 0.5f);
            }
    }

}