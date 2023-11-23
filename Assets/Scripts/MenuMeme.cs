using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMeme : MonoBehaviour
{
    
    public void PlayGame()
    {

        SceneManager.LoadSceneAsync(9);

    }

    public void QuitGame()
    {

        Application.Quit();

    }

}
