using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDengue : MonoBehaviour
{
    public EnemyController enemyController; // Referência ao componente EnemyController

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Picado!!!");
            other.GetComponent<PlayerStatus>().ReceberDano(5);
            Invoke("ParaAtaque", 1.5f);
        }

    }
    void ParaAtaque() 
    {
        enemyController.DesabilitaChegouAoDestino();
    }
}
