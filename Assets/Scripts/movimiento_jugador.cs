using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class MovimientoJugador : MonoBehaviour
{
    public float velocidadBase = 5f;
    public float multiplicadorCorrer = 5f;
    public float fuerzaSalto = 6f;

    // Ajusta esta capa en el Inspector para que el salto solo funcione sobre el suelo.
    [SerializeField] private LayerMask capaSuelo = ~0;

    private Rigidbody rb;
    private Collider colisionador;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        colisionador = GetComponent<Collider>();

        if (colisionador == null)
            colisionador = GetComponentInChildren<Collider>();

        // Se evita la rotación del cuerpo para que el salto se comporte de forma estable.
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Vector3 movimiento = Vector3.zero;

        // 1. Detectar si se está corriendo (W + Shift)
        bool corriendo = Keyboard.current.wKey.isPressed && Keyboard.current.leftShiftKey.isPressed;
        float velocidadActual = corriendo ? velocidadBase * multiplicadorCorrer : velocidadBase;

        // 2. Movimiento direccional
        if (Keyboard.current.wKey.isPressed)
            movimiento.z += 1;
        if (Keyboard.current.sKey.isPressed)
            movimiento.z -= 1;
        if (Keyboard.current.aKey.isPressed)
            movimiento.x -= 1;
        if (Keyboard.current.dKey.isPressed)
            movimiento.x += 1;

        // Normalizar para evitar mayor velocidad al moverse en diagonal.
        movimiento = movimiento.normalized;

        // 3. Aplicar el movimiento horizontal con el Rigidbody para que el salto interactúe bien con la física.
        Vector3 velocidadMovimiento = new Vector3(movimiento.x * velocidadActual, rb.linearVelocity.y, movimiento.z * velocidadActual);
        rb.linearVelocity = velocidadMovimiento;

        // 4. Comprobar salto con la tecla Espacio y solo si estamos apoyados en el suelo.
        if (Keyboard.current.spaceKey.wasPressedThisFrame && EstaEnSuelo())
        {
            // Se asigna una velocidad vertical para que el jugador salte.
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, fuerzaSalto, rb.linearVelocity.z);
        }
    }

    private bool EstaEnSuelo()
    {
        if (colisionador == null)
            return false;

        // Se lanza un rayo hacia abajo desde la base del personaje para detectar el suelo.
        float distanciaComprobacion = colisionador.bounds.extents.y + 0.15f;
        Vector3 origen = transform.position + Vector3.up * 0.1f;

        return Physics.Raycast(origen, Vector3.down, distanciaComprobacion, capaSuelo);
    }
}
