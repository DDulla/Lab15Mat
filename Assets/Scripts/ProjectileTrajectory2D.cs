using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrajectory2D : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float arrowSpeed = 20f;
    public int segmentCount = 20;
    public float simulationTimeStep = 0.1f;

    void Update()
    {
        DrawTrajectory();
    }

    void DrawTrajectory()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero); 
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 mousePosition = ray.GetPoint(distance); 
            Vector3 direction = (mousePosition - transform.position).normalized;

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
}




