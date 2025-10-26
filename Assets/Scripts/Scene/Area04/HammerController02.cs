using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private Rigidbody rbPlayer;

    private Quaternion rotationA;
     private Quaternion rotationB;

    private bool derecha = true;
    void Start()
    {

        Quaternion rotationInicial = transform.rotation;
        rotationA = rotationInicial * Quaternion.Euler(0, 0, 0); //Rota 45 a la derecha
        rotationB = rotationInicial * Quaternion.Euler(0, 0, -90); //Rota 45 a la izquierda
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion objetivoActual = derecha ? rotationA : rotationB;

        // Rotar hacia el objetivo actual suavemente
        transform.rotation = Quaternion.RotateTowards(transform.rotation, objetivoActual, velocity * Time.deltaTime);

        // Verificar si ya llegamos al objetivo para cambiar de dirección
        if (Quaternion.Angle(transform.rotation, objetivoActual) < 0.1f)
        {
            derecha = !derecha;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision);

            rbPlayer.velocity = Vector3.zero;

            float distanciaDerecha = Vector3.Distance(collision.transform.position, right.position);
            float distanciaIzquierda = Vector3.Distance(collision.transform.position, left.position);

            Vector3 direction;

            if (distanciaDerecha < distanciaIzquierda)
            {
                direction = -transform.right;

            }
            else
            {
                direction = transform.right;
            }

            rbPlayer.AddForce(direction * 15f, ForceMode.Impulse);
        }
    }

}
