using UnityEngine;

public class FollowNoParent : MonoBehaviour
{
    protected Transform parent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = transform.parent;
        transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        if (parent)
        {
            transform.position = parent.position;
        }
    }
}
