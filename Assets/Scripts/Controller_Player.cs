using UnityEngine;
using UnityEngine.Device;

public class Controller_Player : MonoBehaviour
{
    private Rigidbody rb; // Permite utilizar las físicas.
    public float jumpForce = 10; // La fuerza con la que el Jugador saltará.
    private float initialSize;  // El tamaño inicial del jugador.
    private int i = 0; 
    private bool floored; // Permite identificar si el jugador esta en el piso o no.
    private bool immune = false; // 
    private float immuneDuration; // 
    private float PowerUpTimer; // Temporizador para el efecto del PowerUp.
    private Collider playerCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Accede al componente "Rigidbody" del jugador.
        initialSize = rb.transform.localScale.y; // Se obtiene el tamaño inicial del jugador.
        playerCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (immune)
        {
            PowerUpTimer -= Time.deltaTime;
            if (PowerUpTimer <= 0)
            {
                EndPowerUp();
            }
        }
        GetInput(); 
    }
    public void EndPowerUp()
    {
        immune = false;
        CollisionsOff(false);
        GetComponent<Controller_ColorPowerUp>().BackToNormal();
    }
   
    private void CollisionsOff(bool ignore)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Collider enemyCollider = enemy.GetComponent<Collider>();
            if (enemyCollider != null)
            {
                Physics.IgnoreCollision(playerCollider, enemyCollider, ignore);
            }
        }
    }
    public void Immunity(float duration)
    {
        if (!immune)
        {
            immune = true;
            immuneDuration = duration;
            PowerUpTimer = duration;
            CollisionsOff(true); // Ignorar colisiones con enemigos mientras el PowerUp está activo.
            GetComponent<Controller_ColorPowerUp>().ChangeColor();
        }
    }
    private void GetInput() // Funcion que permite al jugador agacharse y saltar.
    {
        Jump();
        Duck();
    }

    private void Jump() // Con la letra "W" el jugador salta.
    {
        if (floored)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    private void Duck() // Con la letra "S" el jugador, si esta en el piso, reducira su tamaño, si no solo bajara.
    {
        if (floored)
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (i == 0)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z);
                    i++;
                }
            }
            else
            {
                if (rb.transform.localScale.y != initialSize)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z);
                    i = 0;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    public void OnCollisionEnter(Collision collision) // Establece las colisiones con los enemigos y si el jugador esta en el piso.
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Controller_Hud.gameOver = true;
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = true;
        }
    }

    private void OnCollisionExit(Collision collision) // Revisa si el jugador no esta colisionando con el piso.
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = false;
        }
    }
}
