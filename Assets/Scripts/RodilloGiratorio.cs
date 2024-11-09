using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodilloGiratorio : MonoBehaviour
{
    [SerializeField] private Vector3 direccionR;
    [SerializeField] private float fuerzaR;
    private Rigidbody rodilloGiratorio;

    void Start()
    {
        GetComponent<Rigidbody>().AddTorque(direccionR * fuerzaR, ForceMode.VelocityChange);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
       
    }
}
