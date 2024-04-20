using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam; // Cámara de la escena.
    private float length, startPos; // Longitud y posición inicial del objeto en el eje x. 
    public float parallaxEffect; // Efecto de movimiento del objeto. 

    void Start() // Obtener la posición inicial del objeto y la longitud del sprite del objeto.
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() // Movimiento horizontal del objeto.
    {
        transform.position = new Vector3(transform.position.x - parallaxEffect, transform.position.y, transform.position.z);
        if (transform.localPosition.x < -20)
        {
            transform.localPosition = new Vector3(20, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
