using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    [SerializeField] Vector3 direccionM; //direccion movimiento
    [SerializeField] Vector3 direccionR; //direccion rotacion

    int velocidadR = 90; //90 frames
    float timer = 0;
    int velocidadM = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direccionM * velocidadR * Time.deltaTime, Space.World);
        transform.Translate(direccionM.normalized * velocidadM * Time.deltaTime, Space.World);

        timer += Time.deltaTime;
        if (timer >= 3)
        {
            direccionM = -direccionM;
            timer = 0;
        }
    }
}
