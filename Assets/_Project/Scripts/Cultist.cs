using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Cultist : MonoBehaviour
{
	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void OnEnable()
	{
		Note.CultistAction += OnCultistAction;
	}

	private void OnDisable()
	{
		Note.CultistAction -= OnCultistAction;
	}

	private void OnCultistAction(string _triggerName)
	{
		animator.SetTrigger(_triggerName);
	}
}
