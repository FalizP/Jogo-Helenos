using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCenas : MonoBehaviour
{
    public float TempoLimite;
    public string sceneNeme;

    void Update()
    {
        TempoLimite -= Time.deltaTime;

        if ( TempoLimite <= 0)
        {

            SceneManager.LoadScene(sceneNeme);

        }
    }
}
