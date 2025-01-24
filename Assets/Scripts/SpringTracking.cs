using UnityEditor;
using UnityEngine;

public class SpringTracking : MonoBehaviour
{
    [SerializeField]
    protected Transform target;

    [SerializeField]
    protected float maxDistance;

    [SerializeField]
    protected bool startOnTarget = false;

    [SerializeField]
    protected Spring springX;

    [SerializeField]
    protected Spring springY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.parent = null;

        if (startOnTarget)
        {
            springX.SetValue(target.position.x);
            springY.SetValue(target.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        springX.SetTarget(target.position.x);
        springY.SetTarget(target.position.y);

        springX.Update(Time.deltaTime);
        springY.Update(Time.deltaTime);

        Vector3 newPosition = new Vector3(springX.GetValue(), springY.GetValue(), 0f);
        Vector3 offset = newPosition - target.position;

        transform.position = target.position + Vector3.ClampMagnitude(offset, maxDistance);

        springX.SetValue(transform.position.x);
        springY.SetValue(transform.position.y);
    }
}
