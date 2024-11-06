using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaCamaras : MonoBehaviour
{
    [SerializeField] private GameObject camaraApagar;
    [SerializeField] private GameObject camaraEncender;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // camaraApagar poner en off
            camaraApagar.SetActive(false);

            // camaraEncender ponerla a true
            camaraEncender.SetActive(true);
        }
        else 
        {
            camaraApagar.SetActive(true);
            camaraEncender.SetActive(false);
        }

    }
}