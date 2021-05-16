using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SongEventUtility : MonoBehaviour
{
	public float triggerEventAtSongTime = 10f;
	public UnityEvent songEvent;

	private bool hasTriggered = false;

	private void Update()
	{
		if (hasTriggered)
			return;

		if (Conductor.Instance.RawSongPosition >= triggerEventAtSongTime)
		{
			hasTriggered = true;
			songEvent?.Invoke();
		}
	}
}
