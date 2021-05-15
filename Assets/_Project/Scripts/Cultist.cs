using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Cultist : MonoBehaviour
{
	public int idleType = 1;

	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		animator.SetInteger("IdleType", idleType);
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