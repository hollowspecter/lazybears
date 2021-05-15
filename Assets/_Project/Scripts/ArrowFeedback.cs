using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class ArrowFeedback : MonoBehaviour
{
	public KeyCode keyCode;
	public Color activeColor;
	public Color inactiveColor;

	private SpriteRenderer spriteRenderer;
	private bool pressed = false;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
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
		spriteRenderer.color = activeColor;
	}

	public void Deactivate()
	{
		pressed = false;
		spriteRenderer.color = inactiveColor;
	}
}
