using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject Player;

    public Transform target;
    public float speed = 8f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    [SerializeField] private GameObject bulletPrefab;

    public float distanceToShoot = 25f;
    public float distanceToStop = 25f;

    public float fireRate = 0.75f;
    public float fireTime = 0.75f;

    public Transform bulletSpawnPosition;

    [SerializeField] private int damage = 5;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
        if(target != null && Vector2.Distance(target.position, transform.position) <= distanceToShoot)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (fireTime <= 0f)
        {
            Instantiate(bulletPrefab, bulletSpawnPosition.position, transform.rotation);
            fireTime = fireRate;
        }
        else
        {
            fireTime -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            if (Vector2.Distance(target.position, transform.position) >= distanceToShoot)
            {
                rb.velocity = transform.up * speed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }
    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().dmgUnit(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }

}
