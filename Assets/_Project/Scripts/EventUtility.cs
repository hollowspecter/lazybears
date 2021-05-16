using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventUtility : MonoBehaviour
{
	public UnityEvent onEnable;
	public UnityEvent onStart;

	private void OnEnable()
	{
		onEnable?.Invoke();

	}

	// Start is called before the first frame update
	void Start()
	{
		onStart?.Invoke();
	}

}
