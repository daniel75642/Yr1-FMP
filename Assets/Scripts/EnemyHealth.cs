using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject HealingPrefab;
    [SerializeField] public float currentHealth = 0f;
    [SerializeField] public float maxHealth = 10f;
    [SerializeField] public int DropChance = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        DropChance = Random.Range(0, 7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void dmg (int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (DropChance == 4)
            {
                Vector3 deathPos = this.gameObject.transform.position;
                GameObject prefabToSpawn = Instantiate(HealingPrefab, deathPos, transform.rotation);
            }
            
            Destroy(gameObject);
        }
    }
}
