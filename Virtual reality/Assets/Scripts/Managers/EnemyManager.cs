using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public static float spawnTime = 30f;
    public Transform[] spawnPoints;
    public static float Faster = 0f;


    void Start ()
    {
        //spawn new enemies after 30 seconds
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    void Update()
    {
        //possibility of having a quicker spawning (not used right now)
        spawnTime = spawnTime - Faster;
    }


    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        //make new enemies
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
