using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;

    [SerializeField] private float wheelSpeed = 2f;

    [SerializeField] private float spinSpeed = 1f;

    private int waypointsIndex = 0; //Controla en que punto estoy 

    private Vector3 direccion = new Vector3(1, 0, 0);


    private void Update()
    {
        MovePlatform();
        transform.Rotate(direccion, spinSpeed * Time.deltaTime);

    }

    void MovePlatform () 
    { 
        if (Vector3.Distance(transform.position, waypoints[waypointsIndex].transform.position) < 0.1f) 
        {
            waypointsIndex++;

            if (waypointsIndex >= waypoints.Length) 
            {
                waypointsIndex = 0;
            }

        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsIndex].transform.position, wheelSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
