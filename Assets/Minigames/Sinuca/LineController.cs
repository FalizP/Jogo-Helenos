using UnityEngine;

public class LineController : MonoBehaviour
{
    public LineRenderer lr;  // Reference to the LineRenderer component

    // Awake is called before Start and is used for initialization
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();  // Get the LineRenderer component attached to this GameObject
    }

    // Start is called before the first frame update
    private void Start()
    {
        lr.positionCount = 0;  // Initialize the position count to zero
    }

    // Render a line between the given start and end points
    public void RenderLine(Vector2 startPoint, Vector2 endPoint)
    {
        lr.positionCount = 2;  // Set the position count to 2 for a line

        Vector3[] points = new Vector3[2];
        points[0] = startPoint;  // Set the starting point of the line
        points[1] = endPoint;  // Set the ending point of the line

        lr.SetPositions(points);  // Set the positions of the LineRenderer
    }

    // End the rendering of the line by setting the position count to zero
    public void EndLine()
    {
        lr.positionCount = 0;  // Set the position count to zero to hide the line
    }
}
