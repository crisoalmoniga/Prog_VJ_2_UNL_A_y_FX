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

    // Variables para referenciar otros componentes del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;
    private CircleCollider2D miCollider2D;

    private int saltarMask;

    // Código ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        miCollider2D = GetComponent<CircleCollider2D>();
        saltarMask = LayerMask.GetMask("Pisos", "Plataformas");
    }

    // Código ejecutado en cada frame del juego (intervalo variable)
    void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);

        int velocidadX = (int)miRigidbody2D.velocity.x;
        miSprite.flipX = velocidadX < 0f;

        // Actualiza la animación según la velocidad en el eje X
        miAnimator.SetInteger("Velocidad", velocidadX);

        bool enAire = !EnContactoConPlataforma();
        miAnimator.SetBool("EnAire", enAire);

        Debug.Log("EnAire: " + enAire);  // Agrega esta línea para verificar el valor de EnAire
    }


    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * velocidad);
    }

    private bool EnContactoConPlataforma()
    {
        return miCollider2D.IsTouchingLayers(saltarMask);
    }
}