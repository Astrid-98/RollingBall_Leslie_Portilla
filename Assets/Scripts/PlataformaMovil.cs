using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    [SerializeField] Vector3 direccion;
    float timer = 0f;
    float velocidad = 0.4f;

   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccion.normalized * velocidad * Time.deltaTime);

        timer += Time.deltaTime; //timer = timer + 1 * Time.deltaTime;

        if (timer >= 5f)
        {
            direccion = -direccion;
            timer = 0; 
        }
    }
}
