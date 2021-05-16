using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class StatsText : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		var text = GetComponent<TextMeshProUGUI>();
		int misses = Lifebar.Instance.Misses;
		if (misses > 1)
			text.text = $"You've missed {misses} notes!";
		else if (misses == 1)
			text.text = $"You've missed exactly 1 note!";
		else
			text.text = $"FLAWLESS! No notes missed!";
	}

}
