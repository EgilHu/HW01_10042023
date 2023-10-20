using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public Vector3 startPosition = new Vector3(12.0610266f, 0f, 1.31353378f);
    public Vector3 endPosition = new Vector3(12.0610266f, 0f, 20.6700001f);
    public float speed = 2.0f;
    private bool movingToStart = true;

    private void Update()
    {
        if (movingToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, startPosition) < 0.01f)
        {
            movingToStart = false;
        }
        else if (Vector3.Distance(transform.position, endPosition) < 0.01f)
        {
            movingToStart = true;
        }
    }
}
