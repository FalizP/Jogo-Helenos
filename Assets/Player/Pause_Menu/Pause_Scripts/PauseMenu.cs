using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuPanel;

    private void Start()
    {
        pauseMenuPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        pauseMenuPanel.SetActive(!pauseMenuPanel.activeSelf);
        TimeScaleLogic();
    }

    public void Btn_Resume()
    {
        pauseMenuPanel.SetActive(false);
        TimeScaleLogic();
    }

    private void TimeScaleLogic()
    {
        const int PAUSE = 0;
        const int RESUME = 1;
        Time.timeScale = Time.timeScale == RESUME ? PAUSE : RESUME;
    }


    public void Btn_MenuPrinciapl()
    {
        string nomeCena = "Menu_Principal";
        SceneManager.LoadScene(nomeCena);
    }
}
