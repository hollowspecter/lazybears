using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
	public enum Direction
	{
		Up, Down, Left, Right
	}

	public Direction direction;
	public float length = 0f;

	private float beatOfNote;
	private float beatsShownInAdvance;
	private Vector2 spawnPosition;
	private Vector2 removePosition;

	public float BeatOfNote => beatOfNote;

	public void Initialize()
	{
		beatOfNote = Mathf.Abs(transform.position.y);
	}

	public void Enable(float _spawnPosition, float _removePosition, float _beatsShownInAdvance)
	{
		spawnPosition = new Vector2(transform.position.x, _spawnPosition);
		removePosition = new Vector2(transform.position.x, _removePosition);
		beatsShownInAdvance = _beatsShownInAdvance;
		gameObject.SetActive(true);
	}

	private void Update()
	{
		float t = (beatsShownInAdvance - (beatOfNote - Conductor.Instance.songPositionInBeats)) / beatsShownInAdvance;
		transform.position = Vector2.Lerp(spawnPosition, removePosition, t);

		// check for input
		if (Conductor.Instance.songPositionInBeats >= (beatOfNote - Conductor.Instance.gracePeriodInBeats) &&
			Conductor.Instance.songPositionInBeats <= (beatOfNote + Conductor.Instance.gracePeriodInBeats))
		{
			if ((direction == Direction.Down && Input.GetKeyDown(KeyCode.DownArrow)) ||
				(direction == Direction.Up && Input.GetKeyDown(KeyCode.UpArrow)) ||
				(direction == Direction.Left && Input.GetKeyDown(KeyCode.LeftArrow)) ||
				(direction == Direction.Right && Input.GetKeyDown(KeyCode.RightArrow)))
			{
				// TODO SUCCESS --> let conductor know that a note has been pressed correctly this frame, so no error
				gameObject.SetActive(false);
				return;
			}
		}

		// Deactivate if too long
		if (Conductor.Instance.songPositionInBeats > beatOfNote + length + Conductor.Instance.gracePeriodInBeats)
		{
			// TODO FAILED
			gameObject.SetActive(false);
		}
	}

	public void OnDrawGizmos()
	{
		if (length > 0f)
		{
			Gizmos.DrawLine(transform.position, transform.position + Vector3.down * length);
		}
	}
}
