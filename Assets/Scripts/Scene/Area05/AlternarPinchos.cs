using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternarPinchos : MonoBehaviour
{
    [SerializeField] private GameObject[] pinchosDerecha, pinchosIzquierda;

    private enum Lado { Derecha, Izquierda }

    private Lado lado;

    void Start()
    {
        lado = Lado.Derecha;
        StartCoroutine(Alternar());
    }

    IEnumerator Alternar()
    {
        while (true)
        {
            if (lado == Lado.Derecha)
            {
                SetActiveArray(pinchosDerecha, true);
                SetActiveArray(pinchosIzquierda, false);

            }
            else
            {
                // Activar izquierda, desactivar derecha
                SetActiveArray(pinchosDerecha, false);
                SetActiveArray(pinchosIzquierda, true);

            }

            yield return new WaitForSeconds(3f);

            SetActiveArray(pinchosDerecha, false);
            SetActiveArray(pinchosIzquierda, false);
            yield return new WaitForSeconds(0.8f);

            lado = (lado == Lado.Derecha) ? Lado.Izquierda : Lado.Derecha;
        }
    }

    private void SetActiveArray(GameObject[] array, bool estado)
    {
        foreach (GameObject obj in array)
        {
            obj.SetActive(estado);
        }
    }
}

