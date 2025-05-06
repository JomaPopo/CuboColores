using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    
    public string nombreDeLaEscena; 

    public void LoadScene()
    {
        
            SceneManager.LoadScene(nombreDeLaEscena);
        
    }
}

