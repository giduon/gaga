using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mesage : MonoBehaviour
{
    public GameObject mesage;

    float currentTime = 0;

    public float alpha;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime * (1.0f / 3);
        alpha = Mathf.Lerp(0, 255, currentTime );
        mesage.GetComponent<Image>().color = new Color(0, 0, 0, alpha);

    }

    //public void SetActiveMesage(bool toggle)
    //{


    //    float alpha = Mathf.Lerp(0, 255, );

    //    mesage.GetComponent<Image>().color = new Color(0, 0, 0, alpha);

    //}

}
