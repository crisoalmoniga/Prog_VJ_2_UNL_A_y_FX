using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuración")]
    [SerializeField] float velocidad = 5f;

    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;

    // Variable para referenciar otros componentes del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;

    // Código ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
    }

    // Código ejecutado en cada frame del juego (intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);

        // Reproducir la animación Jugador_camina si hay movimiento horizontal
        if (moverHorizontal != 0)
        {
            miAnimator.Play("Jugador_camina");
        }
        else
        {
            miAnimator.Play("Jugador");
        }
    }

    // Código ejecutado a intervalos fijos para física
    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * velocidad);
    }
}


