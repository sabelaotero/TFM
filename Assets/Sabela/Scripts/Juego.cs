using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Juego : MonoBehaviour
{
    public GameObject PiezaSeleccionada;
    public int PiezasEncajadas;
    private Scene currentScene;
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneName == "Game1")
        {
            if (PiezasEncajadas == 7)
            {
                SceneManager.LoadScene("MenuNiveles");
            }
        } else if (sceneName == "Game2")
        {
            if (PiezasEncajadas == 11)
            {
                SceneManager.LoadScene("MenuNiveles");
            }
        } else if (sceneName == "Game3")
        {
            if (PiezasEncajadas == 6)
            {
                SceneManager.LoadScene("MenuNiveles");
            }
        } else if (sceneName == "Game4")
        {
            if (PiezasEncajadas == 8)
            {
                SceneManager.LoadScene("MenuNiveles");
            }
        } 
             
        
    }
}
