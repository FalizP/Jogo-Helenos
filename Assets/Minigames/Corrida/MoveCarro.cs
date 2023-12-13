using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCarro : MonoBehaviour
{
    [SerializeField]
    private string faseSaida;
    [SerializeField] private float speed = 25f;
    [SerializeField] private TextMeshProUGUI lbPontos;
    public static int pontos = 0;

    private void Start()
    {
        pontos = 0;
        lbPontos.text = "0";
    }

    void Update()
    {
        
        AtualizaPontuacao();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(faseSaida);
        }
    }
    
    private void FixedUpdate()
    {
        MoverCarro();
    }

    void MoverCarro()
    {
        // transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * speed, 0, 0);

        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized;
        transform.position += speed * Time.deltaTime * move;
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
