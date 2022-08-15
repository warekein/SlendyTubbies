using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Natilla : MonoBehaviour
{
    public delegate void SumaNatilla(int natilla);
    public static event SumaNatilla sumaNatilla;

    private UIManager uIManager;

    private void Awake()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            if (sumaNatilla != null)
            {
                SumarNatilla();
                Destroy(this.gameObject);
            }
            
        }
    }

    private void SumarNatilla()
    {
        sumaNatilla(1);
    }
}
