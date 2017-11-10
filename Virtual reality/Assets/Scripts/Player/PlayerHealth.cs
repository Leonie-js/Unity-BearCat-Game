using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    bool isDead;
    bool damaged;


    void Awake ()
    {
        //initialise components
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        currentHealth = startingHealth;
    }

    void Update ()
    {
        if(damaged)
        {
            //show red color on screen
            damageImage.color = flashColour;
        }
        else
        {
            //red color disappears
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    public void TakeDamage (int amount)
    {
        //player is hit
        damaged = true;
        currentHealth -= amount;        
        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            //player died
            Death ();
        }
    }

    public void Heal (int health)
    {
        //player has eaten candy
        currentHealth += health;
        healthSlider.value = currentHealth;
    }

    void Death ()
    {
        isDead = true;
        anim.SetTrigger ("Die");

        //stop player from moving
        playerMovement.enabled = false;
    }
}
