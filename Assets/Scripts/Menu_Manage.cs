using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Función para iniciar el juego
    public void IniciarJuego()
    {
        SceneManager.LoadScene("NivelPrincipal"); 
        // Usa exactamente el nombre de tu escena de juego en Build Settings
    }

    // Función para salir del juego
    public void SalirJuego()
    {
        // En el editor no se nota, pero en el build sí cierra la aplicación
        Application.Quit();

        // Para pruebas en el editor, puedes añadir:
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

