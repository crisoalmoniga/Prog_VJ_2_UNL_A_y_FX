using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuraci�n")]
    [SerializeField] float velocidad = 5f;

    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;

    // Variables para referenciar otros componentes del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;

    // C�digo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
    }

    // C�digo ejecutado en cada frame del juego (intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);

        // Actualiza la animaci�n seg�n la velocidad en el eje X
        miAnimator.SetInteger("Velocidad", (int)Mathf.Abs(miRigidbody2D.velocity.x));

        // Voltea el sprite seg�n la direcci�n del movimiento
        if (moverHorizontal > 0)
        {
            miSprite.flipX = false;  // Mira a la derecha
        }
        else if (moverHorizontal < 0)
        {
            miSprite.flipX = true;   // Mira a la izquierda
        }
    }

    // C�digo ejecutado a intervalos fijos para f�sica
    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * velocidad);
    }
}
