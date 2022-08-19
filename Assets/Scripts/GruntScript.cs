using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GruntScript : MonoBehaviour
{
    private Transform Player;
    public GameObject BulletPrefab;

    private int Health = 1;
    private float LastShoot;

    void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
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
    }

    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }
}