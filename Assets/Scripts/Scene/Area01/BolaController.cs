using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaController : MonoBehaviour
{
    private enum DireccionMovimiento { DerechaIzquierda, AdelanteAtras }
    [SerializeField] private DireccionMovimiento direccion;
    [SerializeField] private PlayerController pC;

    [SerializeField] private GameObject player;


    private bool explotion = false;

    public float velocidad = 2f;

        private Vector3 direccionMov;

        void Start()
        {
            switch (direccion)
            {
                case DireccionMovimiento.DerechaIzquierda:
                    direccionMov = Vector3.right;
                    break;
                case DireccionMovimiento.AdelanteAtras:
                    direccionMov = Vector3.forward;
                    break;
            }
        }
        void Update()
        {
            transform.position += direccionMov * velocidad * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Caja"))
            {
                direccionMov *= -1;
            }

            if (collision.gameObject.CompareTag("Player"))
            {
                if (!explotion)
                {
                    explotion = true;
                    StartCoroutine(Inactive());
                    pC.PerderVida();
                }
                
            }
        }

    IEnumerator Inactive()
    {
        player.SetActive(false);
        yield return new WaitForSeconds(1);
        player.SetActive(true);

        yield return new WaitForSeconds(2);
        explotion = false;
    }
}



