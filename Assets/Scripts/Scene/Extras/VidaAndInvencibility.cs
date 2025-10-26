using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaAndInvencibility : MonoBehaviour
{
    [SerializeField] private PlayerController pC;
    [SerializeField] private GameObject player;

    [SerializeField] private float secondsInvencibility;

    private bool pinchos;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!pinchos)
            {
                pinchos = true;
                pC.PerderVida();
                StartCoroutine(Inactive());
            }
      
        }

        IEnumerator Inactive()
        {
            player.SetActive(false);
            yield return new WaitForSeconds(1);
            player.SetActive(true);

            yield return new WaitForSeconds(secondsInvencibility);
            pinchos = false; 




        }
    }
}

