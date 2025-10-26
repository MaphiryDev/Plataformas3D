using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muelle_Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private float forceUp;
    [SerializeField] private float forceForward;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.AddForce(Vector3.up * forceUp, ForceMode.Impulse);
            player.AddForce(Vector3.forward * forceForward);
        }
    }
}
