using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Lifebar : MonoBehaviour
{
	public static Lifebar Instance = null;


	[Header("Settings")]
	[Range(0.1f, 1f)]
	public float healthStartAmount;
	public float recoveryAmount = 0.1f;
	public float missPenalty = 0.05f;
	public float wrongInputPenalty = 0.03f;
	[Tooltip("How long the grace time stays active in seconds.")]
	public float graceTimespan = 2f;
	[Tooltip("When the player loses health during grace time, they only lose this % less")]
	[Range(0f, 1f)]
	public float graceAmount = 0.5f;

	[Header("UnityEvents")]
	public UnityEvent onDeath;
	public UnityEvent onMiss;
	public UnityEvent onWrongInput;

	[Header("References")]
	public Slider slider;

	private float lastGraceTime;
	private float currentHealth;

	public bool IsGraceTimeActive => Time.time < lastGraceTime + graceTimespan;

	public float CurrentHealth
	{
		get => currentHealth;
		set
		{
			currentHealth = Mathf.Clamp01(value);
			OnValueChanged();
		}
	}


	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
		{
			Debug.LogWarning("Several instances of conductors are not okay, will be deleted");
			Destroy(gameObject);
		}

		Initialize();
	}

	private void Initialize()
	{
		CurrentHealth = healthStartAmount;
	}

	private void OnValueChanged()
	{
		slider.value = currentHealth;

		if (currentHealth <= 0f)
		{
			onDeath?.Invoke();
		}
	}

	public void OnMiss()
	{
		CurrentHealth = currentHealth - missPenalty * (IsGraceTimeActive ? graceAmount : 1f);
		lastGraceTime = Time.time;
		onMiss?.Invoke();
	}

	public void OnWrongInput()
	{
		CurrentHealth = currentHealth - wrongInputPenalty * (IsGraceTimeActive ? graceAmount : 1f);
		lastGraceTime = Time.time;
		onWrongInput?.Invoke();
	}

	public void OnHitSuccess()
	{
		CurrentHealth = currentHealth + recoveryAmount;
	}
}
