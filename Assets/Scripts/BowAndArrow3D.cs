using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowAndArrow3D : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float arrowSpeed = 20f;
    public float arrowMass = 1f;
    public Camera playerCamera;

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 targetPoint = ray.GetPoint(100); 

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                targetPoint = hit.point;
            }

            Vector3 direction = (targetPoint - transform.position).normalized;

            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            rb.velocity = direction * arrowSpeed;
            rb.mass = arrowMass;
        }
    }
}

