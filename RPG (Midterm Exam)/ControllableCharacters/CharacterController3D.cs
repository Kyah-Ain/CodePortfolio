// ------------------------- Camera + Player Controller Method -------------------------

using System.Collections; // Grants access to collecitons structures like ArrayLists and Hashtables
using System.Collections.Generic; // Grants access to collections structures like Lists and Dictionaries
using UnityEngine; // Grants access to Unity's core features like Datatypes, DateTime, Math, and Debug

[RequireComponent(typeof(CharacterController))] // Adds CharacterController component to the GameObject if it doesn't already have one

public class CharacterController3D : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------
    [Header("COMPONENTS")]
    CharacterController characterController; // Placeholder for the CharacterController component
    public Animator animator; // Placholder for the Character's Animations

    [Header("ATTRIBUTES")]
    public float walkingSpeed; // Speed at which the character walks
    public float runningSpeed; // Speed at which the character runs
    public float stamina; // Limits how long the character can run
    public float jumpPower = 8.0f; // Power of the character's jump
    public float gravity = 20.0f; // Gravity applied to the character
    public float rayDistance; // How far the raycast will travel

    [Header("CAMERA NECK MOVEMENT")]
    public GameObject playerCamera; // Placeholder for the camera GameObject
    Vector3 moveDirection = Vector3.zero; // Placeholder for the character's movement direction

    public float lookSpeed = 2.0f; // Mouse look sensitivity
    public float lookXLimit = 45.0f; // Maximum angle the camera can look up or down
    float rotationX = 0; // Placeholder for the camera's X rotation

    [Header("BOOLEANS")]
    [HideInInspector] // Hides the variable from the Inspector but still allows it to be access on other scripts
    public bool canMove = true; // Determines if the character can move
    public bool isRunning; // Determines if the character is running
    public bool isWalking; // Determines if the character is running
    public bool isJumping; // Determines if the character is jumping

    // ------------------------- METHODS -------------------------
    void Start() // Start is called before the first frame update
    {
        characterController = GetComponent<CharacterController>(); // Automatically references the CharacterController component

        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor
        Cursor.visible = false; // Hides the cursor 
    }

    void Update() // Update is called once per frame
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Accepts "Esc" key input from the keyboard
        {
            Cursor.lockState = CursorLockMode.None; // Unlocks the cursor
            Cursor.visible = true; // Shows the cursor
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; // Locks the cursor
            Cursor.visible = false; // Hides the cursor
        }

        // Calculates move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward); // This checks forrward and backward movement
        Vector3 right = transform.TransformDirection(Vector3.right); // This checks forward and backward movement

        // For updating the animator
        if (Input.GetKey(KeyCode.LeftShift)) // Accepts "Left Shift" key input from the keyboard
        {
            isRunning = true; // Returns true if the Left Shift key is pressed
            isWalking = false; // Returns false if the Left Shift key is not pressed
            HandleAnimation(); // Calls the HandleAnimation function
        }
        else
        {
            isRunning = false; // Returns false if the Left Shift key is not pressed
            isWalking = true; // Returns true if the Left Shift key is pressed
            HandleAnimation(); // Calls the HandleAnimation function
        }

        // Condition for movement
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0; // Moves the character forward and backward
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0; // Moves the character left and right
        float movementDirectionY = moveDirection.y; // Placeholder for the character's y-axis movement
        moveDirection = (forward * curSpeedX) + (right * curSpeedY); // Identifies what direction the character is moving

        // Condition for jumping
        if (Input.GetButtonDown("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower; // Makes the character jump
            isJumping = true; // Returns true if the character is jumping
            HandleAnimation(); // Calls the HandleAnimation function
        }
        else
        {
            moveDirection.y = movementDirectionY; // Keeps the character grounded
            isJumping = false; // Returns false if the character is jumping
            HandleAnimation(); // Calls the HandleAnimation function
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime; // Applies gravity to the character
        }

        // Controller Movement
        characterController.Move(moveDirection * Time.deltaTime); // Moves the character based on the moveDirection

        // Camera Movement
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed; // Mouse y-axis movement sensitivity
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit); // Sets the maximum angle the camera can look up or down
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0); // Rotates the camera based on the mouse's y-axis movement

            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0); // Rotates the character based on the mouse's x-axis movement
        }

        PerformRaycast(); // Calls the PerformRaycast function
    }

    void HandleAnimation() // Handles the character's animations
    {   
        animator.SetBool("isRunning", isRunning); // Sets the character's running animation
        animator.SetBool("isWalking", isWalking); // Sets the character's walking animation
        animator.SetBool("isJumping", isJumping); // Sets the character's jumping animation
    }

    void PerformRaycast() // Performs a raycast from the camera's center
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // Creates a ray from the camera's center

        if (Input.GetMouseButtonDown(0)) // Accepts left mouse button input
        {
            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance)) // Checks if the raycast hits an object
            {
                if (hit.collider.CompareTag("NPC")) // Checks if the raycast hits an object with the "NPC" tag
                {
                    Debug.Log($"Hit {hit.collider.name} that has a collider TAG");
                }
                else // Checks if the raycast hits an object with a NPC script instead
                {
                    Debug.Log($"Hit {hit.collider.name} that has a collider SCRIPT");
                    hit.collider.GetComponent<NPC>()?.Interact(); // Calls the Interact function from the NPC script if the raycast hits an NPC
                }
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red); // Draws the raycast in the Scene view
    }
}
