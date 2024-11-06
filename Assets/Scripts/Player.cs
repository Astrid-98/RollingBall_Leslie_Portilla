using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    // Puntuacion
    int puntuacion;
    TMP_Text textoPuntuacion;

    private Rigidbody PlayerBola;
    [SerializeField] Vector3 direccionF; // Direccion del salto
    [SerializeField] int fuerzaSalto;
    float h;
    float v;

    [SerializeField] private float fuerzaMovimiento;
    [SerializeField] private float distanciaRaycast;

    int vidas = 10;
    Vector3 posicionInicial;

    // Start is called before the first frame update
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
            if (detectaSuelo() == true)// mira a ver si detecta el suelo
            {
                PlayerBola.AddForce(direccionF * fuerzaSalto, ForceMode.Impulse);
            }
            
        }
    }
    private void FixedUpdate()
    {
        PlayerBola.AddForce(Vector3.forward * 3, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Trampa"))
        {
            Destroy(other.gameObject);
            if (vidas > 0)
            {
                vidas--;
            } 
        }
        else if (other.gameObject.CompareTag("Checkpoint"))
        {
            transform.position = posicionInicial;
        }
        //Puntuacion
        //puntuacion += 10;
        //textoPuntuacion.SetText("Vidas: " + puntuacion);
    }
    private bool detectaSuelo()
    {
        bool resultado =  Physics.Raycast(transform.position, Vector3.down, distanciaRaycast); //Vector3.down es lo mismo que Vector3(0, -1, 0)
        Debug.DrawRay(transform.position, Vector3.down, Color.red, 2f);
        return resultado;
    }

}
