using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonCombat : MonoBehaviour
{
    public bool raquete;
    public bool spray;
    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Dengue") && spray == true)
       {
         other.GetComponent<EnemyStatus>().ReceberDano(EnemyStatus.vidaTotal);
         Debug.Log("Spray");
       }
       if(other.CompareTag("Dengue") && raquete == true)
       {
          Debug.Log("Raquete");
          other.GetComponent<EnemyStatus>().ReceberDano(2);
         
       }
    }
}
