using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Lifebar : MonoBehaviour
{
	public static Lifebar Instance = null;


	[Header("Settings")]
	public SettingsWrapper settings;

	[Header("UnityEvents")]
	public UnityEvent onLose;
	public UnityEvent onMiss;
	public UnityEvent onWrongInput;

	[Header("References")]
	public Slider slider;

	private float lastGraceTime;
	private float currentHealth;

	public bool IsGraceTimeActive => Time.time < lastGraceTime + settings.settings.GraceTimespan;

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
			Debug.LogWarning("Several instances of lifebars are not okay, will be deleted");
			Destroy(gameObject);
		}

		Initialize();
	}

	private void Initialize()
	{
		CurrentHealth = settings.settings.HealthStartAmount;
	}

	private void OnValueChanged()
	{
		slider.value = currentHealth;

		if (currentHealth <= 0f)
		{
			OnLose();
		}
	}

	public void OnMiss()
	{
		CurrentHealth = currentHealth - settings.settings.MissPenalty * (IsGraceTimeActive ? settings.settings.GraceAmount : 1f);
		lastGraceTime = Time.time;
		onMiss?.Invoke();
	}

	public void OnWrongInput()
	{
		CurrentHealth = currentHealth - settings.settings.WrongInputPenalty * (IsGraceTimeActive ? settings.settings.GraceAmount : 1f);
		lastGraceTime = Time.time;
		onWrongInput?.Invoke();
	}

	public void OnHitSuccess()
	{
		CurrentHealth = currentHealth + settings.settings.RecoveryAmount;
	}

	private void OnLose()
	{
		onLose?.Invoke();
		Conductor.Instance.StopSong();
	}
}
