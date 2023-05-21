using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube2Animation : MonoBehaviour
{
    public float speed = 2f;
    public float minHeight = 0f;
    public float maxHeight = 2f;

    void Update()
    {
        float height = Mathf.PingPong(Time.time * speed + 1f, maxHeight - minHeight) + minHeight;
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
}

