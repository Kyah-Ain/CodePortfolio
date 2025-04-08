using System.Collections; // Grants access to collections structure like ArrayLists and Hashtables
using System.Collections.Generic; // Grants access to collections structure like Lists and Dictionaries
using UnityEngine; // Grants access to Unity's core features like Datatypes, Time, Math, and Debug

public class CameraControl3D : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------
    [Header("Components")]
    public float rayDistance; // Distance of the raycast from the camera
    public Transform headPosition; // Placeholder for the head position
    public Vector3 cameraOffset; // Offset of the camera from the head position

    [Header("Attributes")]
    public int sensitivity; // Mouse look sensitivity
    public float mouseX; // Placeholder for the mouse's X position
    public float mouseY; // Placeholder for the mouse's Y position

    public float maxYAngle = 80f; // Maximum angle the camera can look up or down
    private float rotationX = 0f; // Placeholder for the camera's X rotation

    // ------------------------- FUNCTIONS -------------------------
    void Start() // Start is called before the first frame update
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor
    }

    void SetUpStartingPosition() // Sets up the starting position of the camera
    {
        transform.position = headPosition.position + cameraOffset; // Sets the camera's position
    }

    void Update() // Update is called once per frame
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; // Accepts mouse X input
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime; // Accepts mouse Y input

        rotationX -= mouseY; // Updates the camera's X rotation
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle); // Clamps the camera's X rotation

        transform.rotation = Quaternion.Euler(rotationX, headPosition.rotation.eulerAngles.y, 0f); // Rotates the camera
        transform.parent.Rotate(Vector3.up * mouseX); // Rotates the camera's parent
        PerformRaycast(); // Calls the PerformRaycast method/function
    }

    void PerformRaycast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Creates a ray from the camera's center
        if (Input.GetMouseButtonDown(0)) // Accepts left mouse button input
        {
            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance)) // CHecks if the ray hits an object
            {
                if (hit.collider.CompareTag("NPC")) // Checks if the object is an NPC
                {
                    Debug.Log($"Hit {hit.collider.name} with a collider TAG");
                }
                else
                {
                    hit.collider.GetComponent<NPC>()?.Interact(); // Checks if the object is an NPC
                    Debug.Log($"Hit {hit.collider.name} with a collider SCRIPT");
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
        }
    }
}
