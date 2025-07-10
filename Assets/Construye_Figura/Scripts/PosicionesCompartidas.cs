using System.Collections.Generic;
using UnityEngine;

public static class PosicionesCompartidas
{
    private static HashSet<Vector3> posicionesOcupadas = new HashSet<Vector3>();

    public static bool EstaOcupada(Vector3 posicion, float margen = 0.01f)
    {
        foreach (var p in posicionesOcupadas)
        {
            if (Vector3.Distance(p, posicion) < margen)
                return true;
        }
        return false;
    }

    public static void Ocupar(Vector3 posicion)
    {
        posicionesOcupadas.Add(posicion);
    }
}

