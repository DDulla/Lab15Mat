using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrajectory3D : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float arrowSpeed = 20f;
    public int segmentCount = 20;
    public float simulationTimeStep = 0.1f;
    public Camera playerCamera;

    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100); 
        }

        Vector3 direction = (targetPoint - transform.position).normalized;

        lineRenderer.positionCount = segmentCount;

        Vector3[] positions = new Vector3[segmentCount];
        Vector3 position = transform.position;
        Vector3 velocity = direction * arrowSpeed;

        for (int i = 0; i < segmentCount; i++)
        {
            positions[i] = position;
            position += velocity * simulationTimeStep;
            velocity += Physics.gravity * simulationTimeStep;
        }

        lineRenderer.SetPositions(positions);
    }
}

