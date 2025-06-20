using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

public class Circulo1 : MonoBehaviour
{
    private Vector3 posicionCorrecta;
    private Vector3 posicionCorrecta2;
    private Vector3 posicionInicial;
    private Quaternion rotacionCorrecta;
    private Quaternion rotacionCorrecta2; 
    public bool encajada;


    public GameObject pieza;
    public GameObject piezaPos;
    public GameObject piezaPos2;

    public BoxCollider box;
    private XRGrabInteractable grabInteractable;

    // Start is called before the first frame update
    void Start()
    {
         posicionCorrecta = piezaPos.transform.position + new Vector3(0, 0, 0.02f); 
         rotacionCorrecta = piezaPos.transform.rotation;

     
         posicionCorrecta2 = piezaPos2.transform.position + new Vector3(0, 0, 0.02f);
         rotacionCorrecta2 = piezaPos2.transform.rotation;

         box = GetComponent<BoxCollider>();         
         box.enabled = true; 
         grabInteractable = GetComponent<XRGrabInteractable>();
         
         posicionInicial = pieza.transform.position;
              
    }

    // Update is called once per frame
    void Update()
    {
        if (!grabInteractable.isSelected) // Esto es para verificar si el objeto está siendo agarrado
        {
                
            if(Vector3.Distance(pieza.transform.position, posicionCorrecta) < 0.5f || Vector3.Distance(pieza.transform.position, posicionCorrecta2) < 0.5f)
            {
            
                if (encajada == false)
                {
                    if(Vector3.Distance(pieza.transform.position, posicionCorrecta) < 0.5f && 
                    !PosicionesCompartidas.EstaOcupada(posicionCorrecta))
                    {
                        pieza.transform.position = posicionCorrecta;
                        pieza.transform.rotation = rotacionCorrecta;
                        encajada = true;
                        GetComponent<SortingGroup>().sortingOrder = 2;
                        Camera.main.GetComponent<Juego>().PiezasEncajadas++;
                        box.enabled = false; // Esto lo desactiva
                    } else if (Vector3.Distance(pieza.transform.position, posicionCorrecta2) < 0.5f && 
                         !PosicionesCompartidas.EstaOcupada(posicionCorrecta2))
                    {
                        pieza.transform.position = posicionCorrecta2;
                        pieza.transform.rotation = rotacionCorrecta2;
                        encajada = true;
                        GetComponent<SortingGroup>().sortingOrder = 2;
                        Camera.main.GetComponent<Juego>().PiezasEncajadas++;
                        box.enabled = false; // Esto lo desactiva
                    }
                    
                }
            } else if(Vector3.Distance(pieza.transform.position, posicionCorrecta) > 0.5f || Vector3.Distance(pieza.transform.position, posicionCorrecta2) > 0.5f)
            { if (encajada == false)
                {
                pieza.transform.position = posicionInicial;
                }
            }
         }
    }
}
