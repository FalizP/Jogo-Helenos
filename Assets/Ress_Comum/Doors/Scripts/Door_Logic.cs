using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class Door_Logic : MonoBehaviour
{
    private Controles_InteracaoComPorta porta;
    private InputAction interacting;
    private bool canInteract = false;

    public string proximaFase;

    #region Funções de Inicialização
    private void Awake()
    {
        porta = new Controles_InteracaoComPorta();
    }
     
    private void OnEnable()
    {
        interacting = porta.Player.Interacting;
        interacting.Enable();
    }

    private void OnDisable()
    {
        interacting.Disable();
    }
    #endregion


    void Update()
    {
        AbrirPorta();
        print(canInteract);
    }

    private void AbrirPorta()
    {
        if (interacting.IsPressed())
        {
            print("interagindo");
        }

        if (interacting.IsPressed() && canInteract)
        {
            SceneManager.LoadScene(proximaFase);
        }
        else
            return;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        canInteract = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }

}
