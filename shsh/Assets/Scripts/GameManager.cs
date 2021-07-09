using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject ui;

	public Image backImage;
	public Text resultTExt;

	// 저장용 변수
	Color backColor;
	Color fontColor;
	int fontSize;

	bool startFade = false;
	float currentTime = 0;


	private void Awake()
	{
        // 싱글톤 패턴
		if (gm == null)
		{
            gm = this;
		}
        else
		{
            Destroy(gameObject);
		}
	}

	// UI를 활성화하는 함수 
	public void SetActiveUI(bool toggle)
	{
		ui.SetActive(toggle);
		startFade=toggle;
	}

	private void Start()
	{
		backColor = backImage.color;
		fontColor = resultTExt.color;
		fontSize = resultTExt.fontSize;
	}



	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Time.timeScale = 0;
			SetActiveUI(true);
		}
		if (startFade)
		{
			FadeInEffect();
		}
	}

	// 결과 표시 페이드인 효과 함수 
	void FadeInEffect()
	{
		currentTime += Time.deltaTime;

		// 뒷 배경판의 알파 값을 변경하기
		float alpha = Mathf.Lerp(backColor.a, 0.7f, currentTime);
		backImage.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, alpha);

		// 폰트의 색상 알파 값을 변경하기 
		float fontAlpha = Mathf.Lerp(fontColor.a, 1.0f, currentTime);
		resultTExt.color = fontColor + new Color(0, 0, 0, fontAlpha);

		// 폰트의 크기를 변경하기
		int fontDelta = (int)Mathf.Lerp(fontSize, 90, currentTime);
		resultTExt.fontSize = fontDelta;

	}

}
