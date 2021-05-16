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
	public bool isEnemyArrow = false;
	public string cultistTriggerName;

	private SpriteRenderer spriteRenderer;
	private bool pressed = false;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		Deactivate();
	}

	private void OnEnable()
	{
		if (!isEnemyArrow)
			Note.NoteSuccess += OnNoteSuccess;
		else
			Note.CultistAction += OnCultistAction;
	}

	private void OnDisable()
	{
		if (!isEnemyArrow)
			Note.NoteSuccess -= OnNoteSuccess;
		else
			Note.CultistAction -= OnCultistAction;
	}

	private void Update()
	{
		if (isEnemyArrow)
			return;

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

	private void OnCultistAction(string _triggerName)
	{
		if (cultistTriggerName == _triggerName)
		{
			if (pressFeedback != null)
				pressFeedback.PlayFeedbacks();
			if (successFeedback != null)
				successFeedback.PlayFeedbacks();
		}
	}
}
