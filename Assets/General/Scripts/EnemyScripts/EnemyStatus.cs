using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    int vidaAtual;
    public  static int vidaTotal = 6;
    public GameObject SmokeHit;
    public GameObject Spawner;

    void Start()
    {
        vidaAtual = vidaTotal;
        Spawner.GetComponent<Spawner>();
    }
    public void ReceberDano(int valor)
    {
        vidaAtual -= valor;
        Debug.Log($"vida atual � {vidaAtual}");
        VerificarMorte();
        SmokeHit.SetActive(true);
        Invoke("DesabilitaHit", 0.5f);

    }
    void VerificarMorte()
    {
        if(vidaAtual <= 0)
        {
            transform.GetComponent<EnemyController>().die = true;
            Spawner.GetComponent<Spawner>().mosquitosNacena--;
            Invoke("DestruirCorpo", 1.5f);
        }
    }
    void DesabilitaHit() 
    {
        SmokeHit.SetActive(false);
    }
    void DestruirCorpo() 
    {
        Destroy(gameObject);
    }
}
