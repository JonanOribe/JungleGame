using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBarrel : MonoBehaviour
{
    private int Health = 3;
    private Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Animator.SetBool("destroy", true);
        if (Health == 0) Destroy(gameObject);
        //GameObject explosion = Instantiate(explosion_red, transform.position, Quaternion.identity);
    }
}
