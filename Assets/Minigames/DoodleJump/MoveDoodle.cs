using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class MoveDoodle : MonoBehaviour
{
    [Header("Velocidade")]
    [SerializeField] private float speed = 9f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    Vector3 playerInput;

    [Header("Força do Pulo")]
    [SerializeField] private float jumpForce = 10;

    public float minX = 0f, maxX = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        playerInput = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        Vector3 velocity = speed * Time.deltaTime * playerInput;

        transform.position += velocity;
        //Limita as Paredes
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);

        switch (playerInput.x)
        {
            case -1: spriteRenderer.flipX = true; break;
            case 0: break;
            case 1: spriteRenderer.flipX = false; break;
            default: break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
