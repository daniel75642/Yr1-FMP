using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float timeToLive;

    private Vector3 moveVector;

    private Rigidbody2D bulletRb;

    [SerializeField] private int damage = 5;

    // Start is called before the first frame update
    private void Start()
    {

        moveVector = Vector3.up * bulletSpeed * Time.fixedDeltaTime;

        StartCoroutine(DestroyBlast());

    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        transform.Translate(moveVector);
        bulletRb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyBlast());
    }

    private void OnCollisionEneter2D(Collision2D collision)
    {

        Destroy(gameObject);

    }

    IEnumerator DestroyBlast()
    {

        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("playerBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().dmgUnit(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Asteroids"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }


    }

}
