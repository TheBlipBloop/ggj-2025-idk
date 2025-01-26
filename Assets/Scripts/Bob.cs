using UnityEngine;

public class Bob : MonoBehaviour
{

    [SerializeField]
    protected float magnitude = 0.5f;

    [SerializeField]
    protected float frequency = 1;

    private Vector3 initialPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.Cos(Time.time / frequency) * magnitude;
        transform.transform.position = new Vector3(0, offset, 0) + initialPosition;
    }
}
