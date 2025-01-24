using UnityEngine;

public class Rocking : MonoBehaviour
{

    [SerializeField]
    protected float magnitude = 30f;

    [SerializeField]
    protected float frequency = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Mathf.Sin(Time.time / frequency) * magnitude;
        transform.localEulerAngles = new Vector3(0, 0, rotation);
    }
}
