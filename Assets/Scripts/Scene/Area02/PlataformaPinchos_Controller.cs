using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaPinchos_Controller : MonoBehaviour
{
    [SerializeField] private PlayerController pC;
    [SerializeField] private GameObject player;
    private bool quitaVida; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!quitaVida)
            {
                pC.PerderVida();
                StartCoroutine(Inactive());
                quitaVida = true;
            }
        }
    }

    IEnumerator Inactive()
    {
        player.SetActive(false);
        yield return new WaitForSeconds(1);
        player.SetActive(true);

        yield return new WaitForSeconds(2);
        quitaVida = false;
    }
}
