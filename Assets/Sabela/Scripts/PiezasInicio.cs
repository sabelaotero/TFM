using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

public class PiezasInicio : MonoBehaviour
{

    public GameObject[] piezas; // Asigna tus piezas desde el Inspector
    public Transform centro;    // El punto central desde donde distribuir
    public float radio = 1f;


    // Start is called before the first frame update
    void Start()
    {
         foreach (GameObject pieza in piezas)
         {
            // Generamos un ángulo aleatorio entre 0 y 2 * PI (360 grados)
            float angulo = Random.Range(0f, 2f * Mathf.PI);
    
            // Calculamos el desplazamiento sobre la circunferencia usando trigonometría
            Vector2 desplazamiento = new Vector2(Mathf.Cos(angulo), Mathf.Sin(angulo)) * radio;
    
            // Calculamos la posición final de la pieza sobre la circunferencia
            Vector3 posicionFinal = new Vector3(centro.position.x + desplazamiento.x, centro.position.y, centro.position.z + desplazamiento.y);
    
            // Asignamos la nueva posición de la pieza
            pieza.transform.position = posicionFinal;

            // Vector2 randomOffset = Random.insideUnitCircle * radio;
             //Vector3 posicionFinal = new Vector3(centro.position.x + randomOffset.x, centro.position.y , centro.position.z + randomOffset.y);
             //pieza.transform.position = posicionFinal;
         }
              
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
