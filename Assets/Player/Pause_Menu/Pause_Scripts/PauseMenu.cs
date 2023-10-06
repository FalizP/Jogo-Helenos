using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private InputAction UI_Actions;
    private void OnEnable()
    {
        UI_Actions.Enable();
    }

    void Update()
    {
        if (UI_Actions.WasPressedThisFrame())
        {
            Pause();
        }
    }

    [SerializeField] private GameObject pauseMenu;
    private void Pause()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        TimeScaleLogic();
    }

    public void Btn_Resume()
    {
        pauseMenu.gameObject.SetActive(false);
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
