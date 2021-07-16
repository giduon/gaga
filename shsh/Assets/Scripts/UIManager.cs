using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //씬 콘트롤 관련 네임 스페이스 

public class UIManager : MonoBehaviour
{
	public InputField playerName;

   public void Restart()
	{
		GameManager.gm.CheckScoreResult();
	}


	public void resume()
	{
		Time.timeScale = 1.0f;
		GameManager.gm.SetActiveUI(false);
	}


	public void Quit()
	{
		// 시스템에 접근할때는 어플리케이션으로
		Application.Quit();
	}

	public void ConfirmSaving()
	{
		// 만일 글자 수가 2글자 이상이라면...
		if (playerName.text.Length >= 2)
		{
			// 이름을 저장한다. 
			PlayerPrefs.SetString("bestName", playerName.text);

			// 플레이어 이름 입력 패널을 비활성화한다. 
			playerName.transform.parent.gameObject.SetActive(false);

			// 씬을 다시 실행한다 .
			SceneManager.LoadScene("shootingScene");
			Time.timeScale = 1.0f;

		}
	}
	
}
