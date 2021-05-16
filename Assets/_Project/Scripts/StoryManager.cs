using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class StoryManager : MonoBehaviour
{
	public float FadingTime = 1f;

	public GameObject[] panels;
	private WaitForSeconds wait;
	public string gameSceneName = "BasicGameplay";
	public string environmentSceneName = "Environment";

	// Start is called before the first frame update
	void Start()
	{
		wait = new WaitForSeconds(FadingTime);
		StartCoroutine(StoryTime());
	}

	private IEnumerator StoryTime()
	{
		for (int i = 0; i < panels.Length; ++i)
		{
			panels[i].gameObject.SetActive(true);

			// fade in
			Graphic[] graphics = panels[i].GetComponentsInChildren<Graphic>();
			foreach (Graphic g in graphics)
			{
				g.DOFade(0f, FadingTime).From();
			}
			yield return wait;

			//wait for input
			bool input = false;
			while (input == false)
			{
				input = Input.anyKeyDown;
				yield return null;
			}

			// fade out
			foreach (Graphic g in graphics)
			{
				g.DOFade(0f, FadingTime);
			}
			yield return wait;

			panels[i].gameObject.SetActive(false);
		}

		SceneManager.LoadScene(gameSceneName);
		SceneManager.LoadScene(environmentSceneName, LoadSceneMode.Additive);
	}
}
