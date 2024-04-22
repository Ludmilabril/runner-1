using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;

public class Controller_ColorPowerUp : MonoBehaviour
{
    public GameObject Player;
    public Material mat;

    public void ChangeColor() //Cambiar de color al Jugador cuando agarra el power up.
    {
        Player.GetComponent<Renderer>().material.color = Color.green;
    }
    public void BackToNormal() //Volver a su color original cuando pierde el efecto.
    {
        Player.GetComponent<Renderer>().material.color = Color.blue;
    }
}
