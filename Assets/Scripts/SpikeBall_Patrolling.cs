using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall_Patrolling : MonoBehaviour
{
    public float rotationAngle = 90f; // Rotation speed (degrees per second)
    public float patrolSpeed = 2f;    // Patrol speed
    public Vector3 pointA;            // Patrol start position
    public Vector3 pointB;            // Patrol end position
    private Vector3 targetPoint;      // Current target point
    public float reachThreshold = 0.1f; // Threshold to check if the spike ball reached the target point

    private void Start() => SetPatrolPoints();

    private void Update()
    {
        RotateSpikeBall();
        PatrolSpikeBall();
    }

    // Initialize patrol points
    private void SetPatrolPoints()
    {
        transform.position = pointA;  // Start at pointA
        targetPoint = pointB;         // Set target to pointB initially
    }

    // Rotate the spike ball continuously
    private void RotateSpikeBall()
    {
        transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
    }

    // Move the spike ball between pointA and pointB
    private void PatrolSpikeBall()
    {
        // Move the spike ball toward the target point
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);

        // Check if the spike ball has reached the target point
        if (Vector3.Distance(transform.position, targetPoint) <= reachThreshold)
        {
            // Switch target point
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }
    }
}
