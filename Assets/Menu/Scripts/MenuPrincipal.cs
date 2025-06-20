using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject botonJuego;

    public void LoadScene()
    {
        if (botonJuego.CompareTag("Puzzle"))
        {
            SceneManager.LoadScene("MenuNiveles");  
        } else if (botonJuego.CompareTag("Patos"))
        {
            SceneManager.LoadScene("DemoDay");   
        }
    }
}
