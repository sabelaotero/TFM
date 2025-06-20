using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject boton;

    public void LoadScene()
    {
        if (boton.CompareTag("Caracol"))
        {
            SceneManager.LoadScene("Game1");  
        } else if (boton.CompareTag("Jirafa"))
        {
            Debug.Log("Game2");
            SceneManager.LoadScene("Game2");   
        } else if (boton.CompareTag("Sol"))
        {
            SceneManager.LoadScene("Game3");  
        } else if (boton.CompareTag("Niña"))
        {
            SceneManager.LoadScene("Game4");  
        } else if (boton.CompareTag("Salir"))
        {
            SceneManager.LoadScene("MenuJuegos");  
        }
        
    }
}
