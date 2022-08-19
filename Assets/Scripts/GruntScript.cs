using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GruntScript : MonoBehaviour
{
    private Transform Player;
    public GameObject BulletPrefab;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    public float Speed = 1;

    private int Health = 1;
    private float LastShoot;

    void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }
    void Update()
    {
        
        if (Player == null) return;

        Vector3 direction = Player.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Player.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 1.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
        else {
            Animator.SetBool("running", false);
        }
    }

    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);

        new WaitForSeconds(0.500f);

        var random = new System.Random();
        int randomNumber = random.Next(2);
        Animator.SetBool("running", true);
        Onward(randomNumber);
        
    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }

    public void Onward(int randomNumber) {
        randomNumber = transform.localScale.x < 0 ? -randomNumber: randomNumber;
        Rigidbody2D.velocity = new Vector2(transform.localScale.x * Speed + randomNumber, Rigidbody2D.velocity.y);
    }
}