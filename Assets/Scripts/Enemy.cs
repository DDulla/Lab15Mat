using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;  
    void Update() 
    { 
        if (player != null) 
        { 
            Vector3 direction = (player.position - transform.position).normalized; 
            transform.position += direction * speed * Time.deltaTime; 
        } 
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

