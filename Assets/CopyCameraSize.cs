using UnityEngine;

public class CopyCameraSize : MonoBehaviour
{
    [SerializeField]
    protected Camera target;

    [SerializeField]
    protected Camera self;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (target == null)
        {
            target = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        self.orthographicSize = target.orthographicSize;
        self.backgroundColor = target.backgroundColor;
    }
}
