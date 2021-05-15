using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beatmap : MonoBehaviour
{
	public Note[] notes;

	private void Awake()
	{
		notes = GetComponentsInChildren<Note>();

		for (int i = 0; i < notes.Length; ++i)
		{
			notes[i].Initialize();
			notes[i].gameObject.SetActive(false);
		}
	}
}
