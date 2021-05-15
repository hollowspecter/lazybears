using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source: https://www.gamasutra.com/blogs/GrahamTattersall/20190515/342454/Coding_to_the_Beat__Under_the_Hood_of_a_Rhythm_Game_in_Unity.php
[RequireComponent(typeof(AudioSource))]
public class Conductor : MonoBehaviour
{
	public static Conductor Instance = null;

	// Song beats per minute
	// This is determined by the song you're trying to sync up to
	public float songBpm;

	// Number of seconds for each song beat
	public float secPerBeat;

	// Current song position, in seconds
	public float songPosition;

	// Current song position in beats
	public float songPositionInBeats;

	// How many seconds have passed since the song started
	public float dspSongTime;

	// The offset to the first beat of the song in seconds
	public float firstBeatOffset;

	// An AudioSource attached to this GameObject that will play the music
	private AudioSource musicSource;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
		{
			Debug.LogWarning("Several instances of conductors are not okay, will be deleted");
			Destroy(gameObject);
		}

		musicSource = GetComponent<AudioSource>();
		secPerBeat = 60f / songBpm;
	}

	void Start()
	{
		dspSongTime = (float)AudioSettings.dspTime;
		musicSource.Play();
	}

	void Update()
	{
		songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
		songPositionInBeats = songPosition / secPerBeat;
	}
}
