using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;

public class Controller_ColorPowerUp : MonoBehaviour
{
    public GameObject Player;
    public Material mat;

    public void ChangeColor()
    {
        Player.GetComponent<Renderer>().material.color = Color.green;
    }
    public void BackToNormal()
    {
        Player.GetComponent<Renderer>().material.color = Color.blue;
    }
}
