using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRotator : MonoBehaviour
{
	public int smallPrio = 0;
	public int highPrio = 10;
	public Vector2 minMaxTimePerCamera = new Vector2(3f, 10f);

	private CinemachineVirtualCamera[] cameras;
	private float cameraTimer;
	private int currentIndex = 0;

	private void Awake()
	{
		cameras = GetComponentsInChildren<CinemachineVirtualCamera>();

		for (int i = 0; i < cameras.Length; ++i)
		{
			cameras[i].Priority = smallPrio;
		}

		cameras[currentIndex].Priority = highPrio;
	}

	private void Start()
	{
		ResetTimer();
	}

	private void Update()
	{
		if (Time.time > cameraTimer)
		{
			SwitchCamera();
			ResetTimer();
		}
	}

	private void SwitchCamera()
	{
		cameras[currentIndex].Priority = smallPrio;
		currentIndex = (currentIndex + 1) % cameras.Length;
		cameras[currentIndex].Priority = highPrio;
	}

	private void ResetTimer()
	{
		cameraTimer = Time.time + Random.Range(minMaxTimePerCamera.x, minMaxTimePerCamera.y);
	}
}
