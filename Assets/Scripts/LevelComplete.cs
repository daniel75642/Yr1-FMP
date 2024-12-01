using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    public GameObject levelComplete;
    // Start is called before the first frame update
    void Start()
    {
        levelComplete.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void levelFinished()
    {
        levelComplete.SetActive(true);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelFinished();
            Destroy(gameObject);
        }
    }
}
