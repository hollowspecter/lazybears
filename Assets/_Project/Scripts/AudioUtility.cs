using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioUtility : MonoBehaviour
{
	public Vector2 minMaxPitch = new Vector2(1f, 1f);
	public Vector2 minMaxVolume = new Vector2(1f, 1f);

	private new AudioSource audio;

	private void Awake()
	{
		audio = GetComponent<AudioSource>();
	}

	public void PlayRandomly()
	{
		audio.pitch = Random.Range(minMaxPitch.x, minMaxPitch.y);
		audio.volume = Random.Range(minMaxVolume.x, minMaxVolume.y);
		audio.Play();
	}
}
