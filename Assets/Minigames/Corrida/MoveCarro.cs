using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCarro : MonoBehaviour
{
    [SerializeField] private float speed = 0.15f;
    [SerializeField] private TextMeshProUGUI lbPontos;
    public static int pontos = 0;

    private void Start()
    {
        pontos = 0;
        lbPontos.text = "0";
    }

    void Update()
    {
        MoverCarro();
        AtualizaPontuacao();
    }

    void MoverCarro()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * speed, 0, 0);
    }

    void AtualizaPontuacao()
    {
        lbPontos.text = pontos.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            SceneManager.LoadScene("Corrida");
        }
    }
}
