using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerFire : MonoBehaviour
{
    // ����, ���콺 ��Ŭ���� �ϸ� �Ѿ��� �����ϰ� �ʹ� 

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
        
        // źâ �迭�� ���� 20���� �Ѿ��� ������ ���. 
        for(int i =0; i<20; i++)
		{
            GameObject go = Instantiate(bulletFactory);
            magazine.Add(go);

            //������ �Ѿ��� �÷��̾��� �ڽ� ������Ʈ�� ����Ѵ�. 
            go.transform.parent = wareHouse.transform;
            //������ �Ѿ��� ��Ȱ��ȭ�Ѵ�.
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

            // ����,źâ�� �Ѿ��� �ִٸ�
            if (magazine.Count > 0)
			{

                // źâ�� ù ��° �Ѿ��� Ȱ��ȭ��Ų��.
                magazine[0].SetActive(true);
                // Ȱ��ȭ�� �Ѿ��� �ѱ��� ��ġ��Ų��.
                magazine[0].transform.position = firePosition.position;
                // Ȱ��ȭ�� �Ѿ��� źâ���� �����Ѵ�. 
                magazine.RemoveAt(0);
			}

                // �Ѿ� �߻� ���带 �÷����Ѵ�.
                audioSource.Play();
            }
        }


        //nullüũ: �����ȳ��´�� ������ ��ġ��ç����..��Ī �� ���
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