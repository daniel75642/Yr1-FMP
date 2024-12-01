using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPaused = false;

    public GameObject TitleScreen;

    public GameObject DeathScreen;

    public GameObject Player;
    [SerializeField] PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        Title();
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
            if (!isPaused)
            {
                isPaused = true;
                Pause();
            }
            else
            {
                isPaused = false;
                UnPause();
            }
       } 

       if (playerHealth.currentHealth <= 0)
        {
            Death();
        }
    }


    public void Pause()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Title()
    {
        TitleScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void NoTitle()
    {
        TitleScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Death()
    {
        DeathScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Alive()
    {
        DeathScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
