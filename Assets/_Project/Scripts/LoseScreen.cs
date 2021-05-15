using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
	public void OnRetryPressed()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
