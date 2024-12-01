using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Move : MonoBehaviour
{
    public float strength = 50f;
    private float x = 300f;
    private float y = 300;
    public float speed = 1f;

    private Vector2 lastVelocity;
    private Vector3 moveVector;

    public Rigidbody2D rb;
    public int damage = 20;
    public int enemyDamager = 5;
    void Start()
    {
        //playerHealth = GameObject.Find("Player");
        Vector2 targetVelocity = new Vector2(x, y);
        Vector2 currentVelocity = rb.velocity;
        rb.AddForce((targetVelocity - currentVelocity) * strength);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().dmgUnit(damage);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().dmg(enemyDamager);
        }
    }
}
 