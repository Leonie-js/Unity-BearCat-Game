using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Audio;

public class Colliding : MonoBehaviour {

    int scoreValue = 1;
    public AudioSource audio;
    public int plusHealth = 5;
    GameObject player;
    PlayerHealth playerHealth;


    void Awake()
    {
        //intialise components
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

	void OnCollisionEnter(Collision Collider)
    {
        if (Collider.gameObject.name == "Player")
        {
            //show that candy is been eaten by updating score
            ScoreManager.score += scoreValue;

            //give player health back by eating candy
            //PlayerHealth.currentHealth += plusHealth;
            Heal();
            
            //delete the candy that has been eaten
            Destroy(gameObject);

            audio.Play();
            
            if (EnemyManager.spawnTime > 3f)
            {
                // make enemies faster after having a higher score
                EnemyManager.Faster += 3f;
            }
            else
            {
                EnemyManager.Faster = 0f;
            }

        }
    }
    void Heal()
    {
        if (playerHealth.currentHealth < 100)
        {
            //heal player
            playerHealth.Heal(plusHealth);
        }
    }

    
}
