using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchosPlatformController : MonoBehaviour
{
   [SerializeField] private Transform leftPlatform;
   [SerializeField] private Transform rightPlatform;
   [SerializeField] private float velocity = 2f;
 

    private Vector3 leftObjetive;
    private Vector3 rightObjetive;

    private Vector3 puntoInicioIzquierda;
    private Vector3 puntoInicioDerecha;
    private bool juntando = true;
    void Start()
    {
        puntoInicioIzquierda = leftPlatform.position;
        puntoInicioDerecha = rightPlatform.position;

        float centroX = (leftPlatform.position.x + rightPlatform.position.x) / 2; //Punto medio de las dos plataformas
        leftObjetive = new Vector3(centroX, leftPlatform.position.y, leftPlatform.position.z);
        rightObjetive = new Vector3(centroX, rightPlatform.position.y, rightPlatform.position.z);
    }
    void Update()
    {
       // Mover ambas plataformas hacia el centro
       if (juntando)
        {
            leftPlatform.position = Vector3.MoveTowards(leftPlatform.position, leftObjetive, velocity * Time.deltaTime);
            rightPlatform.position = Vector3.MoveTowards(rightPlatform.position, rightObjetive, velocity * Time.deltaTime);

            if (Vector3.Distance(leftPlatform.position, leftObjetive) < 0.1f)
                juntando = false;
        }

        else 
        {
            leftPlatform.position = Vector3.MoveTowards(leftPlatform.position, puntoInicioIzquierda, velocity * Time.deltaTime);
            rightPlatform.position = Vector3.MoveTowards(rightPlatform.position, puntoInicioDerecha, velocity * Time.deltaTime);

           
            if (Vector3.Distance(leftPlatform.position, puntoInicioIzquierda) < 0.1f)
                juntando = true;

        }
    }
}
