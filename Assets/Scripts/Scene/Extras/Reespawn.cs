using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reespawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform destino;
    [SerializeField] private Rigidbody rbPlayer;

    [SerializeField] private PlayerController player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rbPlayer.velocity = Vector3.zero;
           other.transform.position = destino.position;

            player.PerderVida();
        }
    }

}
