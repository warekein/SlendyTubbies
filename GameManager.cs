using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject tinkiWinky;
    [SerializeField] Transform posicion;

    public void InvocarTinkiWinky()
    {
        Instantiate(tinkiWinky, posicion.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            InvocarTinkiWinky();
        }
    }

}
