using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class ArrowFeedback : MonoBehaviour
{
	public KeyCode keyCode;
	public Sprite activeSprite;
	public Sprite inactiveSprite;

	private SpriteRenderer spriteRenderer;
	private bool pressed = false;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		Deactivate();
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
	}

	public void Deactivate()
	{
		pressed = false;
		spriteRenderer.sprite = inactiveSprite;
	}
}
