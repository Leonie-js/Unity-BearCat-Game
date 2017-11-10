using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SceneManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    public AudioSource click;

    Animator anims;
    float restartTimer;
    public Canvas canvas;

    
    void Start () {
        anims = GetComponent<Animator>();
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }

    void Update()
    {

        if (playerHealth.currentHealth <= 0)
        {
            //player is dead
            anims.SetTrigger("GameOver");

            //Time.timeScale = 0f;
        }
        else if (ScoreManager.score == 10)
        {
            //player won
            anims.SetTrigger("Gewonnen");

            //Time.timeScale = 0f;
        }

        // ability of stopping time (not correctly working yet)
        /*else if (Input.GetKey(KeyCode.Escape) )
        {
            canvas.enabled = true;
            anims.SetTrigger("pauze");
            Time.timeScale = 0f;
            Pause();

        }*/
    }
    
    public void Starten()
    {
        //user clicks on start button
        anims.SetTrigger("start");
        Time.timeScale = 1;
        click.Play();
    }

    public void Terug()
    {
        //user clicks on back button
        anims.SetTrigger("terug");
        Time.timeScale = 1;
        click.Play();
    }

    public void Overnieuw()
    {
        //user clicks on start again button
        click.Play();
        Application.LoadLevel(0);
    }

    public void Stoppen()
    {
        //user clicks on quit
        Application.Quit();
        click.Play();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
}
