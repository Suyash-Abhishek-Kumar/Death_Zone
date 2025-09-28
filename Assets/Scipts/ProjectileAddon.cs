using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    public int bullet_damage = 10;
    private int rock_damage = 5;

    private Rigidbody rb;

    private bool targetHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // make sure only to stick to the first target you hit
        if (targetHit)
            return;
        else
            targetHit = true;

        // check if you hit an enemy
        if (collision.gameObject.GetComponentInParent<EnemyAI>() != null)
        {
            Debug.Log("here 2" + bullet_damage);
            EnemyAI enemy = collision.gameObject.GetComponentInParent<EnemyAI>();

            enemy.TakeDamage(bullet_damage);

            // destroy projectile
            Destroy(gameObject);
        }
        else if (collision.gameObject.GetComponentInParent<Playerhealth>() != null)
        {
            Playerhealth player = collision.gameObject.GetComponentInParent<Playerhealth>();

            player.TakeDamage(rock_damage);

            // destroy projectile
            Destroy(gameObject);
        }

        // make sure projectile sticks to surface
        //rb.isKinematic = true;
        Destroy(gameObject);
        // make sure projectile moves with target
        //transform.SetParent(collision.transform);
    }
}
