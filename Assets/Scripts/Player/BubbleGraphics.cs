using UnityEngine;

public class BubbleGraphics : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		// WIP WIP WIP
		Vector3 morphPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		GetComponent<Renderer>().sharedMaterial.SetVector("_MorphTarget_0", morphPosition);
	}
}
