using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SortBeatmapNotes
{
	[MenuItem("CONTEXT/Beatmap/Sort Notes")]
	static void SortNotes(MenuCommand command)
	{
		Beatmap beatmap = (Beatmap)command.context;

		var notes = beatmap.GetComponentsInChildren<Note>();
		for (int i = 0; i < notes.Length; ++i)
		{
			if (notes[i].isCultistNote)
			{
				if (notes[i].direction == Note.Direction.Left)
				{
					notes[i].transform.localPosition = new Vector3(-6f, notes[i].transform.localPosition.y, notes[i].transform.localPosition.z);
				}
				else if (notes[i].direction == Note.Direction.Down)
				{
					notes[i].transform.localPosition = new Vector3(-4.5f, notes[i].transform.localPosition.y, notes[i].transform.localPosition.z);
				}
				else if (notes[i].direction == Note.Direction.Up)
				{
					notes[i].transform.localPosition = new Vector3(-3f, notes[i].transform.localPosition.y, notes[i].transform.localPosition.z);
				}
				else if (notes[i].direction == Note.Direction.Right)
				{
					notes[i].transform.localPosition = new Vector3(-1.5f, notes[i].transform.localPosition.y, notes[i].transform.localPosition.z);
				}
			}
			else
			{
				if (notes[i].direction == Note.Direction.Left)
				{
					notes[i].transform.localPosition = new Vector3(1.5f, notes[i].transform.localPosition.y, notes[i].transform.localPosition.z);
				}
				else if (notes[i].direction == Note.Direction.Down)
				{
					notes[i].transform.localPosition = new Vector3(3f, notes[i].transform.localPosition.y, notes[i].transform.localPosition.z);
				}
				else if (notes[i].direction == Note.Direction.Up)
				{
					notes[i].transform.localPosition = new Vector3(4.5f, notes[i].transform.localPosition.y, notes[i].transform.localPosition.z);
				}
				else if (notes[i].direction == Note.Direction.Right)
				{
					notes[i].transform.localPosition = new Vector3(6f, notes[i].transform.localPosition.y, notes[i].transform.localPosition.z);
				}
			}

			notes[i].transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

		}//endfor

		EditorUtility.SetDirty(beatmap.gameObject);
	}

}
