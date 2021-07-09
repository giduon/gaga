using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�� ��Ʈ�� ���� ���� �����̽� 

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
		// �ý��ۿ� �����Ҷ��� ���ø����̼�����
		Application.Quit();
	}
}
