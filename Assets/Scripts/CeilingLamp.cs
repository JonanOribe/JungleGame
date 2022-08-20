using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingLamp : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFalling = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Fall()
    {
        isFalling = true;
        rb.gravityScale = 1;
        Object.Destroy(gameObject, 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isFalling) {
            GruntScript grunt = other.collider.GetComponent<GruntScript>();
            PlayerMovement Player = other.collider.GetComponent<PlayerMovement>();
            if (grunt != null)
            {
                grunt.Hit();
            }
            if (Player != null)
            {
                Player.Hit();
            }
        }
    }
}
