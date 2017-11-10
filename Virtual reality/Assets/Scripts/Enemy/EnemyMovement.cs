using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;


    void Awake ()
    {
        //initialse components
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        nav = GetComponent <NavMeshAgent> ();
    }


    void Update ()
    {
        //attacker always walks towards the player
        nav.SetDestination (player.position);
    }
}
