using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMeme : MonoBehaviour
{

    public int fase;
    
    public void PlayGame()
    {

        SceneManager.LoadSceneAsync(fase);

    }

    public void QuitGame()
    {

        Application.Quit();

    }

}
