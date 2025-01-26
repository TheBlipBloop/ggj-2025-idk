using System;
using TMPro;
using UnityEngine;

public class DeathCounterUI : MonoBehaviour
{
	[SerializeField]
	protected TMP_Text text;

	[SerializeField]
	protected string format = "dead cats {0: d}";

	protected void Update()
	{
		print(Game.GetDeathCount().ToString());
		string textContents = String.Format(format, Game.GetDeathCount());
		text.text = textContents;
	}
}
