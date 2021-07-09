using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 콘트롤 관련 네임 스페이스 

public class UIManager : MonoBehaviour
{
   public void Restart()
	{
		SceneManager.LoadScene("ShootingScene");
		Time.timeScale = 1.0f;
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
}
