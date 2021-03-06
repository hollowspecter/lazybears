using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public string storySceneName = "Story";
	public GameObject howToPlay;
	public GameObject credits;

	private bool isSubMenuOpen = false;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			OnBackPressed();
	}

	public void OnBackPressed()
	{
		if (howToPlay.activeSelf)
			howToPlay.SetActive(false);
		if (credits.activeSelf)
			credits.SetActive(false);

		isSubMenuOpen = false;
	}

	public void OnStartPressed()
	{
		if (isSubMenuOpen)
			return;

		SceneManager.LoadScene(storySceneName);
	}

	public void OnHowToPlayPressed()
	{
		if (isSubMenuOpen)
			return;
		howToPlay.SetActive(true);
		isSubMenuOpen = true;
	}

	public void OnCreditsPressed()
	{
		if (isSubMenuOpen)
			return;
		isSubMenuOpen = true;
		credits.SetActive(true);
	}

	public void OnQuitPressed()
	{
		if (isSubMenuOpen)
			return;

#if UNITY_EDITOR
		Debug.Log("QUIT GAME. Only works in build.");
#endif
		Application.Quit();

	}
}
