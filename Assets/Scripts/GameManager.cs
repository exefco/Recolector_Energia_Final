using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Importante para cambiar de escena

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public int nodosRestantes;
    public TMP_Text textoHUD;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        // Cuenta todos los objetos con la etiqueta "Energia"
        nodosRestantes = GameObject.FindGameObjectsWithTag("Energia").Length;
        textoHUD.text = "Energia restante: " + nodosRestantes;
    }

    public void RecolectarNodo()
    {
        nodosRestantes--;
        textoHUD.text = "Energia restante: " + nodosRestantes;

        if (nodosRestantes <= 0)
        {
            // Cambiar a la escena de victoria
            SceneManager.LoadScene("Victoria");
        }
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene("NivelPrincipal"); 
        // Usa exactamente el nombre de tu escena de juego en Build Settings
    }
}
