using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerScript : MonoBehaviour
{

    private World world;

    public Transform cam;

    public float speed;
    public float gravity = -9.8f;
    public float jumpHeight = 5f;

    public float normalSpeed = 4f;
    public float sprintSpeed = 6f;

    public float playerWidth = 0.3f;

    private float horizontal;
    private float vertical;
    private float mouseHorizontal;
    private float mouseVertical;

    public float verticalMomentum = 0;

    private Vector3 velocity;

    public bool isGrounded;
    public bool isSprinting;
    public bool jumpRequest;

    public Transform highlightBlock;
    public Transform placeBlock;

    public float checkIncrement = 0.1f;
    public float reach = 8f;

    public byte selectedBlockIndex = 1;

    // Start is called before the first frame update
    void Start()
    {

        world = GameObject.Find("World").GetComponent<World>();
        speed = normalSpeed;

    }

    private void FixedUpdate()
    {


        GetPlayerInputs();
        CalculateVelocity();

        if (jumpRequest)
            Jump();

        transform.Rotate(Vector3.up * mouseHorizontal);
        transform.Translate(velocity, Space.World);


    }

    // Update is called once per frame
    void Update()
    {

        GetPlayerInputs();

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

        if (isGrounded)
        {
            verticalMomentum = -2.5f;
        }

        placeCursorBlocks();

    }

    void Jump()
    {

        verticalMomentum = jumpHeight;
        isGrounded = false;
        jumpRequest = false;

    }

    private void CalculateVelocity()
    {
        // Affect vertical momentum with gravity.
        if (verticalMomentum > gravity)
            verticalMomentum += Time.fixedDeltaTime * gravity;

        velocity = ((transform.forward * vertical) + (transform.right * horizontal)) * Time.fixedDeltaTime * speed;

        // Apply vertical momentum
        velocity += Vector3.up * verticalMomentum * Time.fixedDeltaTime;

        if ((velocity.z > 0 && front) || (velocity.z < 0) && back)
            velocity.z = 0;
        if ((velocity.x > 0 && right) || (velocity.x < 0) && left)
            velocity.x = 0;

        if (velocity.y < 0)
            velocity.y = checkDownSpeed(velocity.y);
        else if (velocity.y > 0)
            velocity.y = checkUpSpeed(velocity.y);

    }

    private void GetPlayerInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseHorizontal = Input.GetAxis("Mouse X");
        mouseVertical = Input.GetAxis("Mouse Y");

        if (isGrounded && Input.GetButton("Jump"))
        {
            jumpRequest = true;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            if (scroll > 0)
                selectedBlockIndex++;
            else
                selectedBlockIndex--;

            if (selectedBlockIndex > (byte)(world.blockTypes.Length - 1))
                selectedBlockIndex = 1;
            if (selectedBlockIndex < 1)
                selectedBlockIndex = (byte)(world.blockTypes.Length - 1);

        }

        if (highlightBlock.gameObject.activeSelf)
        {

            if (Input.GetMouseButtonDown(0))
            {
                world.GetChunkFromVector3(highlightBlock.position).EditVoxel(highlightBlock.position, 3);
            }

            if (Input.GetMouseButtonDown(1))
            {
                world.GetChunkFromVector3(placeBlock.position).EditVoxel(placeBlock.position, selectedBlockIndex);
            }


        }

    }
    
    private void placeCursorBlocks()
    {

        float step = checkIncrement;
        Vector3 lastPos = new Vector3();

        while ( step < reach)
        {
            Vector3 pos = cam.position + (cam.forward * step);

            if (world.CheckForVoxel(pos))
            {
                highlightBlock.position = new Vector3(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), Mathf.FloorToInt(pos.z));
                placeBlock.position = lastPos;

                highlightBlock.gameObject.SetActive(true);
                placeBlock.gameObject.SetActive(true);

                return;

            }

            lastPos = new Vector3(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), Mathf.FloorToInt(pos.z));

            step += checkIncrement;

        }

        highlightBlock.gameObject.SetActive(false);
        placeBlock.gameObject.SetActive(false);

    }

    private float checkDownSpeed(float downSpeed)
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

    private float checkUpSpeed(float upSpeed)
    {

        if (world.CheckForVoxel(new Vector3(transform.position.x - playerWidth, transform.position.y + 2f + upSpeed, transform.position.z - playerWidth)) ||
            world.CheckForVoxel(new Vector3(transform.position.x + playerWidth, transform.position.y + 2f + upSpeed, transform.position.z - playerWidth)) ||
            world.CheckForVoxel(new Vector3(transform.position.x + playerWidth, transform.position.y + 2f + upSpeed, transform.position.z + playerWidth)) ||
            world.CheckForVoxel(new Vector3(transform.position.x - playerWidth, transform.position.y + 2f + upSpeed, transform.position.z + playerWidth)))
        {
            return 0;
        }
        else
        {
            isGrounded = false;
            return upSpeed;
        }

    }

    public bool front
    {
        get
        {
            if (world.CheckForVoxel(new Vector3(transform.position.x, transform.position.y, transform.position.z + playerWidth)) ||
                world.CheckForVoxel(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z + playerWidth)))
                return true;  
            else
                return false;
        }
    }

    public bool back
    {
        get
        {
            if (world.CheckForVoxel(new Vector3(transform.position.x, transform.position.y, transform.position.z - playerWidth)) ||
                world.CheckForVoxel(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z - playerWidth)))
                return true;
            else
                return false;
        }
    }

    public bool left
    {
        get
        {
            if (world.CheckForVoxel(new Vector3(transform.position.x - playerWidth, transform.position.y, transform.position.z)) ||
                world.CheckForVoxel(new Vector3(transform.position.x - playerWidth, transform.position.y + 1f, transform.position.z)))
                return true;
            else
                return false;
        }
    }

    public bool right
    {
        get
        {
            if (world.CheckForVoxel(new Vector3(transform.position.x + playerWidth, transform.position.y, transform.position.z)) ||
                world.CheckForVoxel(new Vector3(transform.position.x + playerWidth, transform.position.y + 1f, transform.position.z)))
                return true;
            else
                return false;
        }
    }

}
