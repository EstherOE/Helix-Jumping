using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Properties...
    public GameObject ball;
    private Vector3 offset;
    public float smoothSpeed = 0.04f;
    

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
        offset.y = transform.position.y - ball.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, ball.transform.position + offset, smoothSpeed);
        transform.position = newPos;
    }
}
