using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Source: https://www.gamasutra.com/blogs/GrahamTattersall/20190515/342454/Coding_to_the_Beat__Under_the_Hood_of_a_Rhythm_Game_in_Unity.php
[RequireComponent(typeof(AudioSource))]
public class Conductor : MonoBehaviour
{
	public static Conductor Instance = null;

	[Header("Settings")]
	public float songBpm;
	public float firstBeatOffset;
	public float beatsShownInAdvance = 4;
	[SerializeField]
	protected float hitPeriodInSeconds = 0.2f;
	public bool startSongOnStart = true;

	[Header("Read only")]
	public float secPerBeat;
	public float songPosition;
	public float songPositionInBeats;
	public float dspSongTime;

	[Header("References")]
	public Beatmap beatmap;
	public Transform spawnPosition;
	public Transform removePos;

	[Header("Unity Events")]
	public UnityEvent onError;

	private AudioSource musicSource;
	private int nextIndex = 0;
	private bool songIsPlaying = false;

	private bool inputThisFrame = false;
	private bool hitNoteThisFrame = false;

	public float HitPeriodInBeats
	{
		get; private set;
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

		musicSource = GetComponent<AudioSource>();
		secPerBeat = 60f / songBpm;
		HitPeriodInBeats = hitPeriodInSeconds / secPerBeat;
	}

	void Start()
	{
		if (startSongOnStart)
			StartSong();
	}

	void Update()
	{
		inputThisFrame = false;
		hitNoteThisFrame = false;

		if (songIsPlaying)
		{
			songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
			songPositionInBeats = songPosition / secPerBeat;

			// enable notes
			if (nextIndex < beatmap.notes.Length &&
				beatmap.notes[nextIndex].BeatOfNote < songPositionInBeats + beatsShownInAdvance)
			{
				beatmap.notes[nextIndex].Enable(spawnPosition.position.y, removePos.position.y, beatsShownInAdvance);
				nextIndex++;
			}

			if (Input.GetKeyDown(KeyCode.DownArrow) ||
				Input.GetKeyDown(KeyCode.UpArrow) ||
				Input.GetKeyDown(KeyCode.LeftArrow) ||
				Input.GetKeyDown(KeyCode.RightArrow))
				inputThisFrame = true;
		}
	}

	private void LateUpdate()
	{
		if (inputThisFrame == true &&
			hitNoteThisFrame == false)
		{
			Lifebar.Instance.OnWrongInput();
		}
	}

	public void StartSong()
	{
		dspSongTime = (float)AudioSettings.dspTime;
		musicSource.Play();
		songIsPlaying = true;
	}

	public void OnHitSuccess()
	{
		hitNoteThisFrame = true;
	}
}
