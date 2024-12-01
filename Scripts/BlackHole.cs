using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    Vector3 direction;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        direction = transform.position - player.transform.position;
        if (direction.magnitude < 40)
        {
            player.GetComponent<Rigidbody2D>()?.AddForce((direction * Time.deltaTime)/2000);
        }
    }
}
