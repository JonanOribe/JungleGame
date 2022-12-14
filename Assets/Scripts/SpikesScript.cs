using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement Player = other.GetComponent<PlayerMovement>();
        if (Player != null)
        {
            Player.Hit();
        }
    }
}
