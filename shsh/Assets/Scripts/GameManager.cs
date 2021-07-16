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

    // 저장용 변수
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

        // 최초의 게임 오버 레이블의 값을 저장한다.
        backColor = backImage.color;
        fontColor = resultText.color;
        fontSize = resultText.fontSize;

        // 옵션 패널 UI를 비활성화한다.
        ui.SetActive(false);

        // 현재 점수 UI 값을 초기화한다.
        scoreText[0].text = "현재 점수: 0";

        // 최고 점수 UI의 텍스트를 저장장치에 기록된 점수로 초기화한다.
        bestScore = PlayerPrefs.GetInt("highScore");
        string bestPlayer = PlayerPrefs.GetString("bestName");
        scoreText[1].text = "최고 점수: " + bestScore.ToString() + " - " + bestPlayer;
    }

    // UI를 활성화하는 함수
    public void SetActiveUI(bool toggle)
    {
        ui.SetActive(toggle);
        resultText.text = "게임 오버";
        startFade = toggle;

        // 만일, 현재 점수가 종전에 기록되어 있던 최고 점수를 초과하였다면...
        //if (curScore > bestScore)
        //{
        //    // 최고 점수를 현재 점수의 값으로 덮어쓴다(외부 저장장치).
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
            resultText.text = "일시 정지";
            ui.SetActive(true);
        }

        if (startFade)
        {
            FadeInEffect();
        }

        // 플레이어의 라이프가 0 미만이 되면 플레이어 폭발
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

    // 결과 표시 페이드인 효과 함수
    void FadeInEffect()
    {
        currentTime += Time.deltaTime;

        // 뒷 배경판의 알파 값을 변경하기
        //float backAlpha = Mathf.Lerp(backColor.a, 0.7f, currentTime);
        //backImage.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, backAlpha);

        backImage.color = Color.Lerp(backColor, new Color(backImage.color.r, backImage.color.g, backImage.color.b, 0.7f), currentTime);

        // 폰트의 색상 알파 값을 변경하기
        float fontAlpha = Mathf.Lerp(fontColor.a, 1.0f, currentTime);
        resultText.color = fontColor + new Color(0, 0, 0, fontAlpha);

        // 폰트의 크기를 변경하기
        int fontDelta = (int)Mathf.Lerp(fontSize, 90, currentTime);
        resultText.fontSize = fontDelta;
    }

    public void AddPoint(int point)
    {
        // 현재 점수가 point 만큼 추가된다.
        curScore += point;

        // 현재 점수 UI에 점수 값을 출력한다.
        scoreText[0].text = "현재 점수: " + curScore.ToString();
    }

    // 최고 점수 갱신 여부에 따라 재시작 방식을 달리하기
    public void CheckScoreResult()
    {
        print("cur Score: " + curScore.ToString());
        print("best Score: " + bestScore.ToString());

        // 만일, 현재 스코어가 최고 점수를 초과하였다면...
        if (curScore > bestScore)
        {
            // 옵션 패널을 비활성화한다.
            ui.SetActive(false);

            // 스코어 패널을 활성화한다.
            scorePanel.SetActive(true);

            // 최고 점수를 현재 점수의 값으로 덮어쓴다(외부 저장장치).
            bestScore = curScore;
            PlayerPrefs.SetInt("highScore", bestScore);
        }
        // 그렇지 않다면...
        else
        {
            // 현재 씬을 다시 실행한다.
            SceneManager.LoadScene("ShootingScene");
            Time.timeScale = 1.0f;
        }
    }
}
