using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MoreMountains.Feedbacks;

[RequireComponent(typeof(SpriteRenderer))]
public class Note : MonoBehaviour
{
	private const float CultistLatencyCorrection = 0.05f;

	public delegate void CultistDelegate(string triggerName);
	public static CultistDelegate CultistAction;
	public delegate void DirectionSuccessDelegate(KeyCode keyCode);
	public static DirectionSuccessDelegate NoteSuccess;

	public enum Direction
	{
		Up, Down, Left, Right
	}

	public Direction direction;
	public float length = 0f;
	[Header("Read only")]
	public float beatOfNote;
	public bool isCultistNote = false;
	public float cultistNoteAlpha = 0.5f;
	public MMFeedbacks feedbackOnHit;

	private SpriteRenderer spriteRenderer;
	private float beatsShownInAdvance;
	private Vector3 spawnPosition;
	private Vector3 removePosition;
	private KeyCode keyCode;

	public float BeatOfNote => beatOfNote;

	public void Initialize()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		beatOfNote = Mathf.Abs(transform.position.y);
		if (isCultistNote)
		{
			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, cultistNoteAlpha);
		}

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
		spawnPosition = new Vector3(transform.position.x, _spawnPosition, transform.position.z);
		removePosition = new Vector3(transform.position.x, _removePosition, transform.position.z);
		beatsShownInAdvance = _beatsShownInAdvance;
		gameObject.SetActive(true);
	}

	private void Update()
	{
		float t = (beatsShownInAdvance - (beatOfNote - Conductor.Instance.songPositionInBeats)) / beatsShownInAdvance;
		transform.position = Vector3.Lerp(spawnPosition, removePosition, t);

		// cultist notes go away by themselves
		if (isCultistNote)
		{
			if (t >= 1f - CultistLatencyCorrection)
			{
				TriggerCultistAction();
				gameObject.SetActive(false);
			}
			return;
		}


		// check for input
		if (Conductor.Instance.songPositionInBeats >= (beatOfNote - Conductor.Instance.HitPeriodInBeats) &&
			Conductor.Instance.songPositionInBeats <= (beatOfNote + Conductor.Instance.HitPeriodInBeats))
		{
			if (Input.GetKeyDown(keyCode))
			{
				if (feedbackOnHit != null)
					feedbackOnHit.PlayFeedbacks();
				Lifebar.Instance.OnHitSuccess();
				Conductor.Instance.OnHitSuccess();
				NoteSuccess(keyCode);
				gameObject.SetActive(false);
				return;
			}
		}

		// Deactivate if too long
		if (Conductor.Instance.songPositionInBeats > beatOfNote + length + Conductor.Instance.HitPeriodInBeats)
		{
			Lifebar.Instance.OnMiss();
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

	private void TriggerCultistAction()
	{
		switch (direction)
		{
			case Direction.Up:
				CultistAction?.Invoke("Up");
				break;
			case Direction.Down:
				CultistAction?.Invoke("Down");
				break;
			case Direction.Left:
				CultistAction?.Invoke("Left");
				break;
			case Direction.Right:
				CultistAction?.Invoke("Right");
				break;
		}
	}
}
