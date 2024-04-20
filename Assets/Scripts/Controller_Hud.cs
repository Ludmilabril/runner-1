using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver = false; // Variable booleana para determinar si el jugador pierde o no.
    public Text distanceText; // Variable del tipo Text para representar la distancia del jugador.
    public Text gameOverText; // Variable del tipo Text que se mostara cuando el jugador pierde.
    private float distance = 0; // Variable que representa la distancia del jugador.

    void Start()
    {
        gameOver = false; // Se inicializa la variable gameOver en Falso;
        distance = 0; // Se inicializa la distancia a 0;
        distanceText.text = distance.ToString(); // Se configura el texto en la interfaz.
        gameOverText.gameObject.SetActive(false); // Se desactiva el texto de gameOver.
    }

    void Update()
    {
        if (gameOver) // La funcion se ejecuta si gameOver es verdadero.
        {
            Time.timeScale = 0; // El tiempo se para.
            gameOverText.text = "Game Over \n Total Distance: " + distance.ToString("f0"); // Se muestra el texto de gameOver y la distancia total recorrida.
            gameOverText.gameObject.SetActive(true); // Se activa el texto de gameOver.
        }
        else // si gameOver es falso la distancia sigue incrementandose.
        {
            distance += Time.deltaTime;
            distanceText.text = distance.ToString("f0"); // Con el "f0" la distancia no tendrá decimales.
        }
    }
}
