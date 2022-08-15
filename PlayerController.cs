using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController character;
    private Vector3 movimiento;
    [SerializeField] private float velocidadActual;
    [SerializeField] private float sensibilidadRaton;
    [SerializeField] private Transform player;
    [SerializeField] private Camera camaraJugador;

    private float xRotacion = 0f;
    private void Awake()
    {
        character = GetComponent<CharacterController>();

    }

    private void Update()
    {
        MovimientoPeronaje();
        MovimientoCamara();
    }

    public Vector3 MovimientoPeronaje()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        movimiento = transform.right * movX + transform.forward * movZ;
        character.SimpleMove(movimiento * velocidadActual);

        return movimiento;
    }


    private void MovimientoCamara()
    {
        float ratonX = Input.GetAxis("Mouse X") * sensibilidadRaton;
        float ratonY = Input.GetAxis("Mouse Y") * sensibilidadRaton;

        xRotacion -= ratonY;
        xRotacion = Mathf.Clamp(xRotacion, -90f, 90f);

        camaraJugador.transform.localRotation = Quaternion.Euler(xRotacion, 0, 0);

        player.Rotate(Vector3.up * ratonX);

    }
}
