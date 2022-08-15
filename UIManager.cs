using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text textoNatillas;
    [SerializeField] GameObject contenedorTextos;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject imagenJumpScapre;
    [SerializeField] private GameObject textoVictoria;
    private int totalNatillas;

    private void Start()
    {
        totalNatillas = 0;
        Natilla.sumaNatilla += SumarUnaNatilla;
    }
    public void SumarUnaNatilla(int natilla)
    {
        contenedorTextos.SetActive(true);
        totalNatillas ++;
        textoNatillas.text = totalNatillas.ToString();
        EventosNatillas();
        Invoke(nameof(DesactivaTextoNatillas), 1.5f);
    }

    private void DesactivaTextoNatillas()
    {
        contenedorTextos.SetActive(false);
    }

    private void EventosNatillas()
    {
        switch (totalNatillas)
        {
            case 3:
            case 5:
            case 8:
            case 9:
                gameManager.InvocarTinkiWinky();
                break;
            case 4:
            case 7:
                imagenJumpScapre.SetActive(true);
                Invoke(nameof(DesactivarImagenJumpScare), 0.1f);
                break;
            case 10:
                textoVictoria.SetActive(true);
                Invoke(nameof(VolverAJugar), 3f);
                break;

        }
     
    }

    private void DesactivarImagenJumpScare()
    {
        imagenJumpScapre.SetActive(false);
    }

    private void VolverAJugar()
    {
        SceneManager.LoadScene(0);
    }
  

}

