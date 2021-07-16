using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject ui;

    public Image backImage;
    public Text resultText;
    public Text[] scoreText = new Text[2];
    public GameObject scorePanel;
    public int playerLifeCount = 2;
    public int bossCounter = 5;
    public GameObject bossPrefab;

    // ����� ����
    Color backColor;
    Color fontColor;
    int fontSize;

    bool startFade = false;
    float currentTime = 0;

    int curScore = 0;
    int bestScore = 0;

    private void Awake()
    {
        // singletone pattern...
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //PlayerPrefs.SetInt("highScore", 0);

        // ������ ���� ���� ���̺��� ���� �����Ѵ�.
        backColor = backImage.color;
        fontColor = resultText.color;
        fontSize = resultText.fontSize;

        // �ɼ� �г� UI�� ��Ȱ��ȭ�Ѵ�.
        ui.SetActive(false);

        // ���� ���� UI ���� �ʱ�ȭ�Ѵ�.
        scoreText[0].text = "���� ����: 0";

        // �ְ� ���� UI�� �ؽ�Ʈ�� ������ġ�� ��ϵ� ������ �ʱ�ȭ�Ѵ�.
        bestScore = PlayerPrefs.GetInt("highScore");
        string bestPlayer = PlayerPrefs.GetString("bestName");
        scoreText[1].text = "�ְ� ����: " + bestScore.ToString() + " - " + bestPlayer;
    }

    // UI�� Ȱ��ȭ�ϴ� �Լ�
    public void SetActiveUI(bool toggle)
    {
        ui.SetActive(toggle);
        resultText.text = "���� ����";
        startFade = toggle;

        // ����, ���� ������ ������ ��ϵǾ� �ִ� �ְ� ������ �ʰ��Ͽ��ٸ�...
        //if (curScore > bestScore)
        //{
        //    // �ְ� ������ ���� ������ ������ �����(�ܺ� ������ġ).
        //    bestScore = curScore;
        //    PlayerPrefs.SetInt("highScore", bestScore);
        //}
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            resultText.fontSize = 90;
            resultText.text = "�Ͻ� ����";
            ui.SetActive(true);
        }

        if (startFade)
        {
            FadeInEffect();
        }

        // �÷��̾��� �������� 0 �̸��� �Ǹ� �÷��̾� ����
        if (playerLifeCount < 0)
        {
            GameObject player = GameObject.Find("Player");
            Destroy(player);
        }

        if (curScore >= bossCounter)
        {
            GameObject.Find("EnemyFactories").SetActive(false);
            Instantiate(bossPrefab);
        }
    }

    // ��� ǥ�� ���̵��� ȿ�� �Լ�
    void FadeInEffect()
    {
        currentTime += Time.deltaTime;

        // �� ������� ���� ���� �����ϱ�
        //float backAlpha = Mathf.Lerp(backColor.a, 0.7f, currentTime);
        //backImage.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, backAlpha);

        backImage.color = Color.Lerp(backColor, new Color(backImage.color.r, backImage.color.g, backImage.color.b, 0.7f), currentTime);

        // ��Ʈ�� ���� ���� ���� �����ϱ�
        float fontAlpha = Mathf.Lerp(fontColor.a, 1.0f, currentTime);
        resultText.color = fontColor + new Color(0, 0, 0, fontAlpha);

        // ��Ʈ�� ũ�⸦ �����ϱ�
        int fontDelta = (int)Mathf.Lerp(fontSize, 90, currentTime);
        resultText.fontSize = fontDelta;
    }

    public void AddPoint(int point)
    {
        // ���� ������ point ��ŭ �߰��ȴ�.
        curScore += point;

        // ���� ���� UI�� ���� ���� ����Ѵ�.
        scoreText[0].text = "���� ����: " + curScore.ToString();
    }

    // �ְ� ���� ���� ���ο� ���� ����� ����� �޸��ϱ�
    public void CheckScoreResult()
    {
        print("cur Score: " + curScore.ToString());
        print("best Score: " + bestScore.ToString());

        // ����, ���� ���ھ �ְ� ������ �ʰ��Ͽ��ٸ�...
        if (curScore > bestScore)
        {
            // �ɼ� �г��� ��Ȱ��ȭ�Ѵ�.
            ui.SetActive(false);

            // ���ھ� �г��� Ȱ��ȭ�Ѵ�.
            scorePanel.SetActive(true);

            // �ְ� ������ ���� ������ ������ �����(�ܺ� ������ġ).
            bestScore = curScore;
            PlayerPrefs.SetInt("highScore", bestScore);
        }
        // �׷��� �ʴٸ�...
        else
        {
            // ���� ���� �ٽ� �����Ѵ�.
            SceneManager.LoadScene("ShootingScene");
            Time.timeScale = 1.0f;
        }
    }
}
