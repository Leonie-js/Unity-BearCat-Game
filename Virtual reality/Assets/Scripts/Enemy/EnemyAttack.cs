using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public AudioSource hurt;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {

        //initialise components
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            //when player is close enough to hurt
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            //when player walks out of range
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange)
        {
            // attack when player is close enough and there is enough time between the attack before
            Attack ();
        }

        if(playerHealth.currentHealth <= 0)
        {
            // player is killed
            anim.SetTrigger ("PlayerDead");
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            //take health of player
            playerHealth.TakeDamage (attackDamage);
            hurt.Play();
        }
    }
}
