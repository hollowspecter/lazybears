using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Bear : MonoBehaviour
{
	private Animator animator;
	private string trigger;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void Start()
	{
		Lifebar.Instance.onMiss.AddListener(Fail);
		Lifebar.Instance.onWrongInput.AddListener(Fail);
	}

	private void OnDisable()
	{
		Lifebar.Instance.onMiss.RemoveListener(Fail);
		Lifebar.Instance.onWrongInput.RemoveListener(Fail);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			animator.SetTrigger("Up");
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			animator.SetTrigger("Down");
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			animator.SetTrigger("Left");
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			animator.SetTrigger("Right");
		}
	}

	private void Fail()
	{
		animator.SetTrigger("Fail");
	}
}
