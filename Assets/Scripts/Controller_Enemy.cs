using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    public static float enemyVelocity; // Se instancia una variable para definir la velocidad del enemigo.
    private Rigidbody rb; // Se instancia una variable de tipo Rigidbody para que el GameObject responda a las fisicas.

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Se obtiene el componente Rigidbody del GameObject.
    }

    void Update()
    {
        rb.AddForce(new Vector3(-enemyVelocity, 0, 0), ForceMode.Force); // Se le aplica una fuerza al enemigo.
        OutOfBounds(); // Llama a la función "OutOfBounds".
    }

    public void OutOfBounds() // Detecta si el enemigo esta fuera del mapa, si es asi lo destruye.
    {
        if (this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }
}
