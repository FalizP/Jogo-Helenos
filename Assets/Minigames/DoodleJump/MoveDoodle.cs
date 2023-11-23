using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private float jumpForce = 9f;
    [SerializeField] private int maxJumpSpeed = 2;

    public float minX = 0f, maxX = 10f;

    [SerializeField] private TextMeshProUGUI lbPontos;
    public int pontos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        pontos = 0;
    }

    void Update()
    {
        playerInput = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        Vector3 velocity = speed * Time.deltaTime * playerInput;

        transform.position += velocity;

        //Limita as Paredes
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);

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
        if (rb.velocity.magnitude < maxJumpSpeed)
        {
            GameObject obj = collision.gameObject;

            if (obj.GetComponent<CheckColider>().isTouched == false)
            {
                obj.GetComponent<CheckColider>().isTouched = true;
                pontos++;
                lbPontos.text = $"Pontos: {pontos}";
            }

            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
