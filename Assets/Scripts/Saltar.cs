using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuraci�n")]
    [SerializeField] private float fuerzaSalto = 5f;

    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    private bool saltando = false;

    // Variable para referenciar otros componentes del objeto
    private Rigidbody2D miRigidbody2D;

    // C�digo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // C�digo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            puedoSaltar = false;
            saltando = true;
        }
    }

    private void FixedUpdate()
    {
        if (saltando)
        {
            miRigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltando = false; // Se asegura de que el impulso solo se aplique una vez
        }
    }

    // C�digo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        puedoSaltar = true;
    }
}
