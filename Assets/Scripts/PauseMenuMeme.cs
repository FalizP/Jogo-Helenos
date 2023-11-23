using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuMeme : MonoBehaviour
{

    public Transform pauseMenuMeme;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if(pauseMenuMeme.gameObject.activeSelf)
            {

                pauseMenuMeme.gameObject.SetActive(false);
                Time.timeScale = 1;

            }
            else
            {

                pauseMenuMeme.gameObject.SetActive(true);
                Time.timeScale = 0;

            }
        }

    }

    public void VoltarJogo()
    {

        pauseMenuMeme.gameObject.SetActive(false);
        Time.timeScale = 1;

    }
}
