using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Custom/Settings", order = 1)]
public class Settings : ScriptableObject
{
	public float HitPeriodInSeconds = 0.2f;
	[Range(0.1f, 1f)]
	public float HealthStartAmount;
	public float RecoveryAmount = 0.1f;
	public float MissPenalty = 0.05f;
	public float WrongInputPenalty = 0.03f;
	[Tooltip("How long the grace time stays active in seconds.")]
	public float GraceTimespan = 2f;
	[Tooltip("When the player loses health during grace time, they only lose this % less")]
	[Range(0f, 1f)]
	public float GraceAmount = 0.5f;
	public float BeatsShownInAdvance = 8;
}
