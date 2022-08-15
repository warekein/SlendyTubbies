using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class TinkyWinky : MonoBehaviour
{
    [SerializeField] private Transform objetivo;

    private NavMeshAgent agente;
    private int tiempoVida;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        objetivo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        agente.SetDestination(objetivo.position);
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z); //Apaño para bajar a Tinky winky al nivel del suelo. No es recomendable hacer esto.
        StartCoroutine(TiempoDestruccion());

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }


    IEnumerator TiempoDestruccion()
    {
        yield return new WaitForSeconds(20);
        Destroy(this.gameObject);
    }
}