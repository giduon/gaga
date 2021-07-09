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

	// ����� ����
	Color backColor;
	Color fontColor;
	int fontSize;

	bool startFade = false;
	float currentTime = 0;


	private void Awake()
	{
        // �̱��� ����
		if (gm == null)
		{
            gm = this;
		}
        else
		{
            Destroy(gameObject);
		}
	}

	// UI�� Ȱ��ȭ�ϴ� �Լ� 
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

	// ��� ǥ�� ���̵��� ȿ�� �Լ� 
	void FadeInEffect()
	{
		currentTime += Time.deltaTime;

		// �� ������� ���� ���� �����ϱ�
		float alpha = Mathf.Lerp(backColor.a, 0.7f, currentTime);
		backImage.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, alpha);

		// ��Ʈ�� ���� ���� ���� �����ϱ� 
		float fontAlpha = Mathf.Lerp(fontColor.a, 1.0f, currentTime);
		resultTExt.color = fontColor + new Color(0, 0, 0, fontAlpha);

		// ��Ʈ�� ũ�⸦ �����ϱ�
		int fontDelta = (int)Mathf.Lerp(fontSize, 90, currentTime);
		resultTExt.fontSize = fontDelta;

	}

}
