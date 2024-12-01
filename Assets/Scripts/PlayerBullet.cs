using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float timeToLive;

    private Vector3 moveVector;

    private int damage = 5;

    private Rigidbody2D bulletRb;
    // Start is called before the first frame update
    private void Start()
    {

        moveVector = Vector3.up * bulletSpeed * Time.fixedDeltaTime;
        bulletRb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyBlast());

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //bulletRb.AddForce(moveVector, ForceMode2D.Force);
        transform.Translate(moveVector);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().dmg(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("MeleeEnemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().dmg(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Asteroids"))
        {
            other.gameObject.GetComponent<EnemyHealth>().dmg(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

    }

    IEnumerator DestroyBlast()
    {

        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }
}
