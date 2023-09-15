using UnityEngine;
using UnityEngine.SceneManagement;

public class Trampa : MonoBehaviour
{
    // Nombre de la escena actual (asegúrate de que coincida con el nombre de la escena)
    private string nivelActual;
    private void Start()
    {
        // Obtener el nombre de la escena actual y almacenarlo en nivelActual
        nivelActual = SceneManager.GetActiveScene().name;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {
            // Devuelve al jugador al inicio del nivel
            SceneManager.LoadScene(nivelActual);
        }
    }
}
