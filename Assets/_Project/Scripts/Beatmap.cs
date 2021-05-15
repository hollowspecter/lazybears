using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Beatmap : MonoBehaviour
{
	public List<Note> notes;

	private void Awake()
	{
		notes.AddRange(GetComponentsInChildren<Note>());
		notes.Sort((a, b) => Mathf.Abs(a.transform.position.y).CompareTo(Mathf.Abs(b.transform.position.y)));

		for (int i = 0; i < notes.Count; ++i)
		{
			notes[i].Initialize();
			notes[i].gameObject.SetActive(false);
		}
	}

	public void DeactivateAllNotes()
	{
		for (int i = 0; i < notes.Count; ++i)
		{
			notes[i].gameObject.SetActive(false);
		}
	}
}
