using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float spinSpeed;
    private Vector3 direccion = new Vector3(0, 1, 0);

    private void Update()
    {
        transform.Rotate(direccion, spinSpeed * Time.deltaTime);
    }

}
