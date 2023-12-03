using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

public class BallController : MonoBehaviour
{
    // Public variables that can be adjusted in the Unity Editor
    public float power = 10f;  // Force applied to the ball
    public Rigidbody2D rb;  // Reference to the Rigidbody2D component of the ball
    public Vector2 minPower;  // Minimum force that can be applied
    public Vector2 maxPower;  // Maximum force that can be applied

    // Variables for handling input and drawing the trajectory line
    Camera cam;  // Main camera
    Vector2 force;  // Force vector to be applied to the ball
    Vector3 startPoint;  // Starting point for dragging
    Vector3 endPoint;  // Ending point for dragging
    bool isOverBall = false;  // Flag to check if the mouse/touch is over the ball

    // Reference to the LineController script for drawing trajectory lines
    LineController line;

    // Awake is called before Start and is used for initialization
    private void Awake()
    {
        // Get the LineController component attached to this GameObject
        line = GetComponent<LineController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the main camera in the scene
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the mouse/touch is over the ball
        if (isOverBall)
        {
            // Handle touch input
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    // Get the starting point when touch begins
                    startPoint = cam.ScreenToWorldPoint(touch.position);
                    startPoint.z = 15;  // Set the z-coordinate to ensure it's in front of the ball
                }

                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    // Get the current point during touch movement and render the trajectory line
                    Vector3 currentPoint = cam.ScreenToWorldPoint(touch.position);
                    line.RenderLine(startPoint, currentPoint);
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    // Get the ending point when touch ends and apply force to the ball
                    endPoint = cam.ScreenToWorldPoint(touch.position);
                    endPoint.z = 15;
                    ApplyForce();
                }
            }
            // Handle mouse input
            else if (Input.GetMouseButtonDown(0))
            {
                // Get the starting point when the mouse button is pressed
                startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                startPoint.z = 15;
            }
            else if (Input.GetMouseButton(0))
            {
                // Get the current point during mouse drag and render the trajectory line
                Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                line.RenderLine(startPoint, currentPoint);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                // Get the ending point when the mouse button is released and apply force to the ball
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                endPoint.z = 15;
                ApplyForce();
            }
        }
    }

    // Called when the mouse is pressed over the collider of this GameObject
    private void OnMouseDown()
    {
        isOverBall = true;  // Set the flag to true when the mouse is down over the ball
    }

    // Called when the mouse is released after being pressed over the collider of this GameObject
    private void OnMouseUp()
    {
        // Get the ending point when the mouse button is released and apply force to the ball
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        endPoint.z = 15;
        ApplyForce();
    }

    // Apply force to the ball based on the drag distance and direction
    void ApplyForce()
    {
        // Calculate the force vector based on the drag distance and direction
        force = new Vector2(
            Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x),
            Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y)
        );

        // Apply the calculated force to the ball using Impulse mode
        rb.AddForce(force * power, ForceMode2D.Impulse);

        // End the rendering of the trajectory line and reset the flag
        line.EndLine();
        isOverBall = false;
    }
}
