using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody PlayerBola;
    [SerializeField] Vector3 direccionF;
    [SerializeField] int fuerza;
    float h;
    float v;

    // Start is called before the first frame update
    void Start()
    {
        PlayerBola = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //MOVIMIENTO WASD Y FLECHAS
        float h = Input.GetAxisRaw("Horizontal"); // A y D para horizontal
        float v = Input.GetAxisRaw("Vertical"); // W y S para vertical
        Vector3 movimiento = new Vector3(h, 0, v).normalized;

        PlayerBola.AddForce(movimiento * fuerza, ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.Space)) // al precionar Space aplica salto
        {
            PlayerBola.AddForce(direccionF * fuerza, ForceMode.Impulse);
        }

       
    }
    private void FixedUpdate()
    {
        //PlayerBola.AddForce(Vector3.forward * 3, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            Destroy(other.gameObject);
        }
    }
}
