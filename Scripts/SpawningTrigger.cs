using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTrigger : MonoBehaviour
{

    public EnemySpawner enemySpawner;    
    public MeleeEnemySpawner meleeEnemySpawner;
    void Start()
    {
        enemySpawner.enabled = false;
        meleeEnemySpawner.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemySpawner.enabled = true;
            meleeEnemySpawner.enabled = true;
        }

    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemySpawner.enabled = false;
            meleeEnemySpawner.enabled = false;
        }
    }

}
