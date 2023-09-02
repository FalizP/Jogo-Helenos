using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    enum Estados
    {
        Idle = 0,
        Walking_Left = 1,
        Walking_Right = 2
    }
    Estados estadoAtual = new();

    SpriteRenderer spriteRenderer;

    private Vector2 moveDirection = Vector2.zero;
    private PlayerControls playerControls;
    private InputAction move;

    [SerializeField] private float speed = 25;

    #region Funções de Inicialização
    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
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
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        MoveCharacter();
        DefineEstadoAtual();
    }

    void DefineEstadoAtual()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            estadoAtual = Estados.Walking_Left;
            playerAnimation.PlayAnimation("Player_Walking_Left");
            spriteRenderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            estadoAtual = Estados.Walking_Right;
            playerAnimation.PlayAnimation("Player_Walking_Left");
            spriteRenderer.flipX = true;
        }
        else
        {
            estadoAtual = Estados.Idle;
            playerAnimation.PlayAnimation("Player_Idle");
        }
    }

    private void MoveCharacter()
    {
        moveDirection += speed * Time.deltaTime * move.ReadValue<Vector2>().normalized;
        transform.position = moveDirection;
    }

    public PlayerAnimationController playerAnimation;


    #region Detecção de Colisões
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
