using System.Collections;
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
    }

    private void AbrirPorta()
    {
        if (interacting.IsPressed() && canInteract)
        {
           StartCoroutine(TrocarDeFaseComAnimacao());
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

    public Animator animacaoDoPortao;

    private IEnumerator TrocarDeFaseComAnimacao()
    {
        // Acione a animação no animator
        if (animacaoDoPortao != null)
        {
            animacaoDoPortao.SetTrigger("Transição");
            yield return new WaitForSeconds(animacaoDoPortao.GetCurrentAnimatorStateInfo(0).length);
        }

        // Troque de fase
        SceneManager.LoadScene(proximaFase);
    }

}
