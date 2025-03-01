using System; // Grants access to classess and functions that uses your system
using System.Collections; // Grants access to collections and data structures like ArrayList
using System.Collections.Generic; // Grants access to collections and data structures like List and Dictionary
using UnityEngine; // Grants access to Unity's core features 

public class PlayerController : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------

    public Rigidbody2D ghostBoy; // Placeholder of the character object
    public Animator animator; // Placeholder for the character's animations

    public float speed; // Sets how fast the player could move 
    public float jumpingPower; // Sets how high the player could jump
    public float raycastDistance; // Sets how long the raycast distance

    public float horizontal; // Stores the character's horizontal position
    public float vertical; // Stores the character's vertical position

    public Transform groundCheck; // Stores the current 3D position of an object in the space
    public LayerMask groundMask; // Checks if the collision was to a ground
    public LayerMask ladder; // Checks if the collision was to a ladder 

    public bool isRunning = false; // For matching the animation to the displacement of the character in order to recreates running
    public bool isJumping = false; // For matching the animation to the displacement of the character in order to recreates running
    private bool isFacingRight = true; // For flipping the character based on which direction it's moving
    private bool isClimbing = false; // For checking if the player is doing climbing or not

    // ------------------------- FUNCTIONS -------------------------
    void Start() // Start is called before the first frame update
    {
        ghostBoy = GetComponent<Rigidbody2D>(); // Provides access to the RigidBody of the object being passed on
        animator = GetComponent<Animator>(); // Provides access to the Animations of the object being passed on
    }

    void Update() // Update is called once per frame
    {
        CharacterMovement(); // Executes the codes inside this function on every frame
        HandleAnimation(); // Executes the codes inside this function on every frame
        Flip(); // Executes the codes inside this function on every frame
    }

    void CharacterMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // Get's the key inputs/values from the Input Manager (specifically the "Horizontal" section)

        if (IsGrounded() && Input.GetButtonDown("Jump")) // Determines if collision and jump was true to proceed jumping ONLY WHEN THE CHARACTER IS AT GROUND
        {
            ghostBoy.velocity = new Vector2(ghostBoy.velocity.x, jumpingPower); // JUMP
            //isJumping = true; // NOT WORKING

            //if () 
            //{
            //    isJumping = false; // NOT WORKING
            //}
        }

        // Shortest If-Else Statement (Shortcut Method)
        isRunning = horizontal != 0 ? true : false; // Animation's on/off switch in order for the computer to know when to trigger the animation and when to stop
    }

    void HandleAnimation()
    {
        animator.SetBool("isRunning", isRunning); // Passes the isRunning value to the Animator in order to make a transition
        //animator.SetBool("isJumping", isJumping); // NOT WORKING
    }

    void Flip()
    {               // Flip to Left                    // Flip to Right
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            // Responsible for switching the value true or false (On and Off)
            isFacingRight = !isFacingRight;

            // Responsible for Flipping/Mirroring of the sprite
            Vector2 localScale = transform.localScale; // Creates a modifieable copy of transform from the inspector
            localScale.x *= -1f; // Updates the copy
            transform.localScale = localScale; // Applying the effect to the gameobject's transformScale
        }
    }

    void FixedUpdate() // Smoother Movement for Left and Right (in order to evenly distribute the milliseconds per frame)
    {
        if (ghostBoy != null) // To prevent Unity from spamming the unreferenced error of something you don't need to use
        {
            ghostBoy.velocity = new Vector2(horizontal * speed, ghostBoy.velocity.y); // Updates the horizontal movement while keeping the current vertical speed.

            // Variable to call    // Creates laser  // Starting point  // direction // How long     // What layer could trigger the collision
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, ladder); // Shoots an invisible laser collider at a specified direction (acts as a one dimension collider)
            //Debug.DrawRay(transform.position, Vector2.up * raycastDistance, Color.green); // Alternative to OnDrawGizmo but only could seen when the game runs

            if (hitInfo.collider != null) // Checks if there's a collision with a ladder and this laser
            {
                isClimbing = true; // Activates the code below
            } 
            else
            {
                isClimbing = false; // Deactivate the code below
            }

            if (isClimbing == true) // Checks if the collision between the laser and the ladder really happened
            {
                vertical = Input.GetAxisRaw("Vertical"); // Get's the key inputs/values from the Input Manager (specifically the "Vertical" section)
                ghostBoy.velocity = new Vector2(ghostBoy.velocity.x, vertical * 3f); // Keeps horizontal speed the same and change the vertical speed based on input
                ghostBoy.gravityScale = 0; // Removes gravity in order for you to climb the ladder with no resistance 
            } 
            else
            {
                ghostBoy.gravityScale = 4f; // Brings back the gravity at the specified intensity
            }
        }
    }

    private bool IsGrounded() // Determines if there's a collision between the Character and the Ground
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundMask); // Returns true or false
    }

    void OnDrawGizmosSelected() // Adds highlight markings to whatever unseen system range detector (THIS TOOL IS JUST FOR DEBUGGING)
    {
        if (groundCheck != null) // To prevent Unity from spamming the unreferenced error of something you don't need to use
        {
            Gizmos.color = Color.green; // Color of the Raycast for Ladder Wireframe
            Gizmos.DrawRay(transform.position, Vector2.down * raycastDistance); // Visualizes the laser in the Unity Scene for you to see it (beacause it's invisible at the game and at default)

            Gizmos.color = Color.white; // Color of the GroundCheck Radius Wireframe
            Gizmos.DrawWireSphere(groundCheck.position, 0.3f); // Mimics the groundCheck.position in wireframes in order for you to see how large the detection to GROUND is
        }
        else
        {
            Debug.Log("Gizmos don't exists");
        }
    }
}
