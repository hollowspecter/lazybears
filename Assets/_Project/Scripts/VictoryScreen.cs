using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
	public string MainMenuScene = "MainMenu";

	public void GoBackToMenu()
	{
		SceneManager.LoadScene(MainMenuScene);
	}
}
