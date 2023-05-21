using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimation : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;
    public float speed = 2f;
    public float distance = 5f;
    public float interval = 3f;
    private float timer = 0f;
    private bool collided = false;
    private Vector3 direction1 = Vector3.right;
    private Vector3 direction2 = Vector3.forward;

    void Update()
    {
        // Animate Cube 1
        if (!collided)
        {
            cube1.transform.position += direction1 * speed * Time.deltaTime;
            if (Mathf.Abs(cube1.transform.position.x) >= distance)
                direction1 = -direction1;
        }

        // Animate Cube 2
        if (!collided)
        {
            cube2.transform.position += direction2 * speed * Time.deltaTime;
            if (Mathf.Abs(cube2.transform.position.z) >= distance)
                direction2 = -direction2;
        }

        // Check for collision
        if (Vector3.Distance(cube1.transform.position, cube2.transform.position) < 10f)
        {
            collided = true;
            timer += Time.deltaTime;

            if (timer >= interval)
            {
                // Create new cube
                GameObject newCubeObj = Instantiate(cube2, new Vector3(cube1.transform.position.x, cube1.transform.position.y, cube1.transform.position.z), Quaternion.identity);

                // Set new cube's rolling direction randomly
                Vector3 newDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
                newCubeObj.GetComponent<Rigidbody>().AddForce(newDirection * speed * 100f);

                // Reset timer and collided flag
                timer = 0f;
                collided = false;
            }
        }
        else
        {
            collided = false;
            timer = 0f;
        }
    }
}

