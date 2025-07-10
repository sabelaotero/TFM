using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject panelInstrucciones;  
    public GameObject panelMenuJuegos;
    public GameObject panelMenu;

    // Funci�n para mostrar las instrucciones
    public void ShowInstrucciones() {
        panelMenu.SetActive(false);  
        panelInstrucciones.SetActive(true);  // Activa el panel
    }

     // Muestra el panel de selecci�n de juegos
    public void ShowMenuJuegos()
    {
        panelMenu.SetActive(false);
        panelMenuJuegos.SetActive(true);
    }

     // Oculta el panel de juegos y vuelve al men� principal
    public void BackToMainMenu()
    {
        panelMenuJuegos.SetActive(false);
        panelInstrucciones.SetActive(false);
        panelMenu.SetActive(true);
    }

    // Carga una escena
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Funci�n para salir al men� principal
    public void QuitGame() {
        SceneManager.LoadScene("MenuJuegos");
    } 
}
