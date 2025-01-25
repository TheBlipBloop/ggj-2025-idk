using System;
using TMPro;
using UnityEngine;

public class CollectableUI : MonoBehaviour
{
	[SerializeField]
	protected TMP_Text text;

	[SerializeField]
	protected string format = "{0: d} / {0: d}";


	protected void Update()
	{
		string textContents = String.Format(format, Collector.GetCurrentCollectables(), Collector.GetMaxCollectables());
		text.text = textContents;
	}
}
