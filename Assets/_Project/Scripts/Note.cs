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
	[Header("Read only")]
	public float beatOfNote;

	private float beatsShownInAdvance;
	private Vector2 spawnPosition;
	private Vector2 removePosition;
	private KeyCode keyCode;

	public float BeatOfNote => beatOfNote;

	public void Initialize()
	{
		beatOfNote = Mathf.Abs(transform.position.y);

		switch (direction)
		{
			case Direction.Up:
				keyCode = KeyCode.UpArrow;
				break;
			case Direction.Down:
				keyCode = KeyCode.DownArrow;
				break;
			case Direction.Left:
				keyCode = KeyCode.LeftArrow;
				break;
			case Direction.Right:
				keyCode = KeyCode.RightArrow;
				break;
		}
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
			if (Input.GetKeyDown(keyCode))
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
