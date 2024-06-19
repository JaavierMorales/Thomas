using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plattaform : MonoBehaviour
{
    public Transform platform, startPoint, endPoint;
    public float speed = 0.5f;
    public int direction = 1;

    private void Start()
    {
    }

    public void Update()
    {
        Vector2 target = currentMovementTarget();
        platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);
        float distance = (target - (Vector2)platform.position).magnitude;
        if (distance <= 0.2f)
        {
            direction *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(platform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}