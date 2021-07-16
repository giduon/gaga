using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //�� ��Ʈ�� ���� ���� �����̽� 

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
		// �ý��ۿ� �����Ҷ��� ���ø����̼�����
		Application.Quit();
	}

	public void ConfirmSaving()
	{
		// ���� ���� ���� 2���� �̻��̶��...
		if (playerName.text.Length >= 2)
		{
			// �̸��� �����Ѵ�. 
			PlayerPrefs.SetString("bestName", playerName.text);

			// �÷��̾� �̸� �Է� �г��� ��Ȱ��ȭ�Ѵ�. 
			playerName.transform.parent.gameObject.SetActive(false);

			// ���� �ٽ� �����Ѵ� .
			SceneManager.LoadScene("shootingScene");
			Time.timeScale = 1.0f;

		}
	}
	
}
