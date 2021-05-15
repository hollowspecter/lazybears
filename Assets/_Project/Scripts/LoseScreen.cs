using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
	public void OnRetryPressed()
	{
		Scene[] scenes = new Scene[SceneManager.sceneCount];
		for (int i = 0; i < scenes.Length; ++i)
		{
			scenes[i] = SceneManager.GetSceneAt(i);
		}

		SceneManager.LoadScene(scenes[0].buildIndex);
		for (int i = 1; i < scenes.Length; ++i)
		{
			SceneManager.LoadScene(scenes[i].buildIndex, LoadSceneMode.Additive);
		}
	}
}
