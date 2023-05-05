using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 moveDirection = Vector2.zero;
    private PlayerControls playerControls;
    private InputAction move;
    private InputAction interacting;

    private bool isJumping = false;

    [SerializeField] private float speed = 650;

    #region Inventário
    private List<string> keys = new List<string>();
    #endregion

    #region Funções de Inicialização
    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        interacting = playerControls.Player.Interacting;
        interacting.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }
    #endregion

    private void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        moveDirection = move.ReadValue<Vector2>();
        rb.velocity = speed * moveDirection.normalized;
    }

    #region Detecção de Colisões
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            move.Disable();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            move.Enable();
        }
    }
    #endregion
}
