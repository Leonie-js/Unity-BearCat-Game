using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float RotateSpeed = 30f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        //initialise components
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // walk forward or backwards
        bool walking = Input.GetKey("up") || Input.GetKey("down");
        anim.SetBool("IsWalking", walking);

        //only rotate when pressing the left or right key
        if (Input.GetKey("left"))
        {
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        }
        // walk forward or backwards
        if (Input.GetKey("up")) 
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey("down"))
       {
           transform.Translate(Vector3.back * speed * Time.deltaTime);
       }
    }
}
