using UnityEngine;

public class MoveDoodle : MonoBehaviour
{
    Vector2 playerInput;

    [Header("Força do Pulo")]
    [SerializeField] private float force;
 
    void Start()
    {
        force = 10;
    }
    
    void Update()
    {
        playerInput = new(x: Input.GetAxisRaw("Horizontal"), y: Input.GetAxisRaw("Vertical"));
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(playerInput.x * force, 0), ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
    }
}
