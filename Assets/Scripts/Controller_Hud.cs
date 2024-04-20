using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver = false; // Variable booleana para determinar si el jugador pierde o no.
    public Text distanceText; // Variable del tipo Text para representar la distancia del jugador.
    public Text gameOverText; // Variable del tipo Text que se mostara cuando el jugador pierde.
    private float distance = 0; // Variable que representa la distancia del jugador.
    public Parallax parallax00, parallax01;
    public Parallax parallax02, parallax03;
    public Parallax parallax04, parallax05;
    public Parallax parallax06, parallax07;
    public Parallax parallax08, parallax09;


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

            if (parallax00 && parallax01 && parallax02 && parallax03 && parallax04 != null)
            {
                parallax00.StopParallax(); // El parallax deja de moverse.
                parallax01.StopParallax();
                parallax02.StopParallax();
                parallax03.StopParallax();
                parallax04.StopParallax();
                parallax05.StopParallax();
                parallax06.StopParallax();
                parallax07.StopParallax();
                parallax08.StopParallax();
                parallax09.StopParallax();
            }
        }
        else // si gameOver es falso la distancia sigue incrementandose.
        {
            distance += Time.deltaTime;
            distanceText.text = distance.ToString("f0"); // Con el "f0" la distancia no tendrá decimales.
        }
    }
}
