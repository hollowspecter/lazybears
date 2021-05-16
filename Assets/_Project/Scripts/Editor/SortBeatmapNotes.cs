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

	[MenuItem("CONTEXT/Note/Convert to Normal Note")]
	static void ConvertToNormalNote(MenuCommand command)
	{
		Note note = (Note)command.context;
		if (PrefabUtility.IsOutermostPrefabInstanceRoot(note.gameObject))
			PrefabUtility.UnpackPrefabInstance(note.gameObject, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
		note.isCultistNote = false;


		// position
		if (note.direction == Note.Direction.Left)
		{
			note.transform.localPosition = new Vector3(1.5f, note.transform.localPosition.y, note.transform.localPosition.z);
		}
		else if (note.direction == Note.Direction.Down)
		{
			note.transform.localPosition = new Vector3(3f, note.transform.localPosition.y, note.transform.localPosition.z);
		}
		else if (note.direction == Note.Direction.Up)
		{
			note.transform.localPosition = new Vector3(4.5f, note.transform.localPosition.y, note.transform.localPosition.z);
		}
		else if (note.direction == Note.Direction.Right)
		{
			note.transform.localPosition = new Vector3(6f, note.transform.localPosition.y, note.transform.localPosition.z);
		}

		note.name = System.Enum.GetName(typeof(Note.Direction), note.direction);

		note.GetComponent<SpriteRenderer>().color = Color.white;
		EditorUtility.SetDirty(note);
	}

	[MenuItem("CONTEXT/Note/Convert to Cultist Note")]
	static void ConvertToCultistNote(MenuCommand command)
	{
		Note note = (Note)command.context;
		if (PrefabUtility.IsOutermostPrefabInstanceRoot(note.gameObject))
			PrefabUtility.UnpackPrefabInstance(note.gameObject, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
		note.isCultistNote = true;

		// position
		if (note.direction == Note.Direction.Left)
		{
			note.transform.localPosition = new Vector3(-6f, note.transform.localPosition.y, note.transform.localPosition.z);
		}
		else if (note.direction == Note.Direction.Down)
		{
			note.transform.localPosition = new Vector3(-4.5f, note.transform.localPosition.y, note.transform.localPosition.z);
		}
		else if (note.direction == Note.Direction.Up)
		{
			note.transform.localPosition = new Vector3(-3f, note.transform.localPosition.y, note.transform.localPosition.z);
		}
		else if (note.direction == Note.Direction.Right)
		{
			note.transform.localPosition = new Vector3(-1.5f, note.transform.localPosition.y, note.transform.localPosition.z);
		}

		note.name = System.Enum.GetName(typeof(Note.Direction), note.direction) + " (Cultist)";

		note.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
		EditorUtility.SetDirty(note);
	}
}
