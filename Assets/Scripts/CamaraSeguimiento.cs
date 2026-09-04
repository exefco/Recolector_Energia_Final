using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = jugador.position + offset;
    }
}

