using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoriaManager : MonoBehaviour
{
    // 👉 Función para reiniciar el nivel principal
    public void ReiniciarNivel()
    {
        SceneManager.LoadScene("NivelPrincipal"); 
        // Usa exactamente el nombre de tu escena de juego en Build Settings
    }

    // 👉 Función opcional para volver al menú principal

    public void VolverMenu()
    {
        SceneManager.LoadScene("MenuPrincipal"); 
        // Usa el nombre de tu escena de menú si la tienes
    }
}

