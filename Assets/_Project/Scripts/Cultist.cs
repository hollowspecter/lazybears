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

	private void Start()
	{
		Lifebar.Instance.onMiss.AddListener(OnBearFail);
		Lifebar.Instance.onWrongInput.AddListener(OnBearFail);
		Lifebar.Instance.onLose.AddListener(OnBearFail);
	}

	private void OnEnable()
	{
		Note.CultistAction += OnCultistAction;
	}

	private void OnDisable()
	{
		Note.CultistAction -= OnCultistAction;
		Lifebar.Instance.onMiss.RemoveListener(OnBearFail);
		Lifebar.Instance.onWrongInput.RemoveListener(OnBearFail);
		Lifebar.Instance.onLose.RemoveListener(OnBearFail);
	}

	private void OnCultistAction(string _triggerName)
	{
		animator.SetTrigger(_triggerName);
	}

	private void OnBearFail()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			animator.SetFloat("FailFace", Random.Range(0f, 7f));
			animator.SetTrigger("Fail");
		}
	}
}
