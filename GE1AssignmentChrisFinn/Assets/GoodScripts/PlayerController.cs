using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    private World world;

    public float speed;
    public float gravity = -16f;
    public float jumpHeight = 7f;

    public float normalSpeed = 6f;
    public float sprintSpeed = 10f;

    public float playerWidth = 0.15f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;

    public bool isGrounded;
    public bool isSprinting;
    public bool jumpRequest;

    // Start is called before the first frame update
    void Start()
    {

        world = GameObject.Find("World").GetComponent<World>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
            isSprinting = false;
        }

        /*isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);*/

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        velocity += Vector3.up * gravity * Time.deltaTime;

        velocity.y = checkDownSpeed(velocity.y);

        controller.Move(velocity * Time.deltaTime);

    }

    private float checkDownSpeed (float downSpeed)
    {

        if (world.CheckForVoxel(new Vector3(transform.position.x - playerWidth, transform.position.y + downSpeed, transform.position.z - playerWidth)) ||
            world.CheckForVoxel(new Vector3(transform.position.x + playerWidth, transform.position.y + downSpeed, transform.position.z - playerWidth)) ||
            world.CheckForVoxel(new Vector3(transform.position.x + playerWidth, transform.position.y + downSpeed, transform.position.z + playerWidth)) ||
            world.CheckForVoxel(new Vector3(transform.position.x - playerWidth, transform.position.y + downSpeed, transform.position.z + playerWidth)))
        {
            isGrounded = true;
            return 0;
        }
        else
        {
            isGrounded = false;
            return downSpeed;
        }

    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Ground")
        {

            isGrounded = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Ground")
        {

            isGrounded = false;

        }

    }
    */

}
