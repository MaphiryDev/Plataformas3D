using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BajarVida : MonoBehaviour
{
    [SerializeField] private PlayerController pC;
    [SerializeField] private GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pC.PerderVida();
            StartCoroutine(Inactive());
        }

        IEnumerator Inactive()
        {
            player.SetActive(false);
            yield return new WaitForSeconds(1);
            player.SetActive(true);


        }
    }
}
