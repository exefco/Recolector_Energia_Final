using UnityEngine;

public class NodoEnergia : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Avisar al GameManager
            GameManager.instancia.RecolectarNodo();

            // Buscar la luz asociada y destruirla
            Transform luz = transform.Find("luz_destroy");
            if (luz != null)
            {
                Destroy(luz.gameObject);
            }

            // Destruir el nodo
            Destroy(gameObject);
        }
    }
}


