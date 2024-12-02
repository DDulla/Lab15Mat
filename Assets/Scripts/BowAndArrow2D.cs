using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowAndArrow2D : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float arrowSpeed = 20f;
    public float arrowMass = 1f;
    public float spawnOffset = 1f; 

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero); 
            float distance;

            if (plane.Raycast(ray, out distance))
            {
                Vector3 mousePosition = ray.GetPoint(distance); 
                Vector3 direction = (mousePosition - transform.position).normalized;

                Vector3 spawnPosition = transform.position + direction * spawnOffset;

                GameObject arrow = Instantiate(arrowPrefab, spawnPosition, Quaternion.identity);
                Rigidbody rb = arrow.GetComponent<Rigidbody>();
                rb.velocity = direction * arrowSpeed;
                rb.mass = arrowMass;
            }
        }
    }
}
