using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject boton;
    public GameObject panelInstrucciones;  
    public GameObject panelMenu;

    // Funci�n para mostrar las instrucciones
    public void ShowInstrucciones() {
        panelMenu.SetActive(false);  
        panelInstrucciones.SetActive(true);  // Activa el panel
    }

    // Funci�n para ocultar las instrucciones y volver al men�
    public void HideInstrucciones() {
        panelInstrucciones.SetActive(false); // Desactiva el panel
        panelMenu.SetActive(true);  
    }


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
        } else if (boton.CompareTag("Ni�a"))
        {
            SceneManager.LoadScene("Game4");  
        } else if (boton.CompareTag("Salir"))
        {
            SceneManager.LoadScene("MenuJuegos");  
        }
        
    }
}
