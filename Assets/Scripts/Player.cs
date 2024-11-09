using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using static UnityEngine.Rendering.VolumeComponent;

public class Player : MonoBehaviour
{
    [Header("TextoUI")]
    //VIDAS
    [SerializeField] int vidas;
    [SerializeField] TMP_Text textoVidas;

    // PUNTUACION
    [SerializeField] int monedas;
    [SerializeField] TMP_Text textoMonedas;

    private Rigidbody PlayerBola;
    [SerializeField] Vector3 direccionF; // Direccion del salto
    float h;
    float v;
    [SerializeField] int fuerzaSalto;
    [SerializeField] private float fuerzaMovimiento;
    [SerializeField] private float distanciaRaycast;

    Vector3 posicionInicial;

    void Start()
    {
        PlayerBola = GetComponent<Rigidbody>();

        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //MOVIMIENTO WASD Y FLECHAS
        float h = Input.GetAxisRaw("Horizontal"); // A y D para horizontal
        float v = Input.GetAxisRaw("Vertical"); // W y S para vertical
        Vector3 movimiento = new Vector3(h, 0, v).normalized;

        PlayerBola.AddForce(movimiento * fuerzaMovimiento, ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.Space)) // al precionar Space aplica salto
        {
            if (detectaSuelo())// mira a ver si detecta el suelo
            {
                PlayerBola.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            }

        }
        
    }
    private void FixedUpdate()
    {
        PlayerBola.AddForce(Vector3.forward * fuerzaMovimiento, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Monedas"))
        {
            monedas++;
            textoMonedas.SetText("Monedas: " + monedas);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Checkpoint"))
        {
            transform.position = posicionInicial;
            PlayerBola.velocity = Vector3.zero;
            PlayerBola.angularVelocity = Vector3.zero;
            
        }
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Trampa"))
        {
            vidas --;
            textoVidas.SetText("Vidas: " + vidas);
            if (vidas <= 0)
            {
                ReiniciarJuego();
            }
        }
    }
    private bool detectaSuelo()
    {
        bool resultado = Physics.Raycast(transform.position, Vector3.down, distanciaRaycast); //Vector3.down es lo mismo que Vector3(0, -1, 0)
        Debug.DrawRay(transform.position, Vector3.down * distanciaRaycast, Color.red, 0.5f);
        return resultado;
    }
    private void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
