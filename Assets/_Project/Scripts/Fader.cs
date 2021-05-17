using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Image))]
public class Fader : MonoBehaviour
{
	public float duration = 1f;

	private Image image;

	// Start is called before the first frame update
	void Start()
	{
		image = GetComponent<Image>();
		image.DOFade(1f, duration).From();
	}
}
