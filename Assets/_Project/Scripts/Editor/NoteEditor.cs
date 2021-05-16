using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Note))]
public class NoteEditor : Editor
{
	float newBeat;

	public override void OnInspectorGUI()
	{
		Note note = (Note)target;

		EditorGUILayout.LabelField("Beat Number = " + Mathf.Abs(note.transform.position.y));
		EditorGUILayout.BeginHorizontal();
		newBeat = EditorGUILayout.FloatField("New Beat Number", newBeat);
		if (GUILayout.Button("Update Beat"))
		{
			note.transform.position = new Vector3(note.transform.position.x, -newBeat, note.transform.position.z);
		}
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.Space(20f);

		base.DrawDefaultInspector();
	}
}
