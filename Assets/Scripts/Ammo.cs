using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public AmmoText ammoText;
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerMovement Player = other.collider.GetComponent<PlayerMovement>();
        if (Player != null)
        {
            DestroyBox();
        }
    }

    public void DestroyBox()
    {
        Destroy(gameObject);
        ammoText.ChangeText();
    }
}
