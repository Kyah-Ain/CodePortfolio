using System.Collections; // Grants access to collections structures like ArrayLists and Hashtables
using System.Collections.Generic; // Grants access to collections structures like Lists and Dictionaries   
using UnityEngine; // Grants access to Unity's core features like Datatypes, DateTime, Math, and Debug

public class PlayerControl3D : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------
    [Header("Components")]
    public CharacterController characterController; // Placeholder for the CharacterController component
    public Animator animator; // Placeholder for the Character's Animations

    [Header("Attributes")]
    public int movementSpeed; // Speed at which the character moves
    public int rotationSpeed; // Speed at which the character rotates
    public int jumpHeight; // Height of the character's jump
    public float gravity = 9.81f; // Gravity applied to the character

    [Header("Detectors")]
    public float groundDistance = 0.2f; // Distance from the ground
    public Transform groundCheck; // Ground check position
    public LayerMask groundMask; // Ground layer mask detection

    [Header("Booleans")]
    private bool isRunning; // Determines if the character is moving
    public bool isGrounded; // Determines if the character is grounded

    public Vector3 velocity; // Placeholder for the character's velocity

    // ------------------------- FUNCTIONS -------------------------
    void Start() // Start is called before the first frame update
    {
        characterController = GetComponent<CharacterController>(); // Automatically references the CharacterController component
        animator = GetComponent<Animator>(); // Automatically references the Animator component
    }

    void Update() // Update is called once per frame
    {
        MoveCharacter(); // Calls the MoveCharacter method/function
    }

    void MoveCharacter() // Moves the character
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // Checks if the character is grounded
        if (isGrounded && velocity.y < 0) // Determines if the character is grounded
        {
            velocity.y = -2f; // Resets the character's velocity
        }

        float horizontal = Input.GetAxis("Horizontal"); // Accepts horizontal input from the keyboard
        float vertical = Input.GetAxis("Vertical"); // Accepts vertical input from the keyboard

        isRunning = vertical + horizontal != 0 ? true : false; // Determines if the character is moving

        animator.SetFloat("Velocity", vertical); // Updates the character's velocity animation
        animator.SetBool("isRunning", isRunning); // Updates the character's movement animation

        Vector3 move = transform.right * horizontal + transform.forward * vertical; // Calculates the character's movement direction
        characterController.Move(move * movementSpeed * Time.deltaTime); // Moves the character

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y -= Mathf.Sqrt(jumpHeight * 2f * gravity); // Calculates the character's jump height
        }

        velocity.y -= gravity * Time.deltaTime; // Applies gravity to the character per frame
        characterController.Move(velocity * Time.deltaTime); // Moves the character
    }
}
