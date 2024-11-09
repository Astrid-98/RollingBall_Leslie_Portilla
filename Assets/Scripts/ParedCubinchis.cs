using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedCubinchis : MonoBehaviour
{
    private bool iniciarTimer;
    [SerializeField] private float timer;
    [SerializeField] private Rigidbody[] rbs; // El corchete es Array

    // 1. Crear un timer para que empiece a contar una vez iniciado
    // 2. Hacer que el timer cuente hasta 2 segundos.
    // 3. Una vez que el timer haya contado 2 segundos, volver el timeScale a 1.

    private void Update()
    {
        if (iniciarTimer == true)
        {
            timer += 1 * Time.unscaledDeltaTime; // UnscaledDeltaTime: deltaTime PERO no es afectado por la escala del tiempo
            if (timer >= 2f)
            {
                Time.timeScale = 1;

                //Recorro el array de rbs para reestablecer la gravedad
                for (int cubos = 0; cubos < rbs.Length; cubos++) // i = cubos
                {
                    rbs[cubos].useGravity = true;

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0.2f;
            iniciarTimer = true;
        }
    }
}
