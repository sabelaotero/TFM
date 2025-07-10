using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject panelInstrucciones;  
    public GameObject panelMenuJuegos;
    public GameObject panelMenu;

    // Función para mostrar las instrucciones
    public void ShowInstrucciones() {
        panelMenu.SetActive(false);  
        panelInstrucciones.SetActive(true);  // Activa el panel
    }

     // Muestra el panel de selección de juegos
    public void ShowMenuJuegos()
    {
        panelMenu.SetActive(false);
        panelMenuJuegos.SetActive(true);
    }

     // Oculta el panel de juegos y vuelve al menú principal
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

    // Función para salir al menú principal
    public void QuitGame() {
        SceneManager.LoadScene("MenuJuegos");
    } 
}
