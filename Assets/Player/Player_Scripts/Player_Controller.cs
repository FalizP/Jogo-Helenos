using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;
    private PlayerControls playerControls;
    private InputAction move;

    [SerializeField] private float speed = 1000;

    #region Invent�rio
    private List<string> keys = new List<string>();
    #endregion

    #region Fun��es de Inicializa��o
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
    }

    private void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        moveDirection += speed * Time.deltaTime * move.ReadValue<Vector2>().normalized;
        transform.position = moveDirection;
        // Movimenta��o usando RigidBody2D
        // rb.velocity = speed * moveDirection.normalized;
    }

    #region Detec��o de Colis�es
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
