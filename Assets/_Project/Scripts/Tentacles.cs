using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tentacles : MonoBehaviour
{
	public Transform TentaclesPivot;
	public float moveInDuration = 10f;

	public void RaiseTheTentacles()
	{
		TentaclesPivot.DOLocalMoveY(0f, moveInDuration);
	}
}
