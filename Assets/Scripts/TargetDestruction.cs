using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDestruction : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

