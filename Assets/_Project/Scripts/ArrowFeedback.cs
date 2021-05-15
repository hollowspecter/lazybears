using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.Feedbacks;

[RequireComponent(typeof(SpriteRenderer))]
public class ArrowFeedback : MonoBehaviour
{
	public KeyCode keyCode;
	public Sprite activeSprite;
	public Sprite inactiveSprite;
	public MMFeedbacks pressFeedback;
	public MMFeedbacks successFeedback;

	private SpriteRenderer spriteRenderer;
	private bool pressed = false;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		Deactivate();
	}

	private void OnEnable()
	{
		Note.NoteSuccess += OnNoteSuccess;
	}

	private void OnDisable()
	{
		Note.NoteSuccess -= OnNoteSuccess;
	}

	private void Update()
	{
		if (Input.GetKey(keyCode))
		{
			if (!pressed)
				Activate();
		}
		else
		{
			if (pressed)
				Deactivate();
		}
	}

	private void Activate()
	{
		pressed = true;
		spriteRenderer.sprite = activeSprite;
		if (pressFeedback != null)
			pressFeedback.PlayFeedbacks();
	}

	private void OnNoteSuccess(KeyCode _keyCode)
	{
		if (keyCode == _keyCode &&
			successFeedback != null)
		{
			successFeedback.PlayFeedbacks();
		}
	}

	public void Deactivate()
	{
		pressed = false;
		spriteRenderer.sprite = inactiveSprite;
	}
}
