using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo
    public Transform spawnPoint; // Ponto de spawn do inimigo
    public TextMeshProUGUI numCriadouro;
    public float spawnInterval = 3f; // Intervalo de spawn em segundos
    public bool enabledSpawn = true ;
    public bool nerfado = false ;

    public static int mosquitosTotais;
    public int mosquitosNacena;
    public int limitSpwan;
    public static int criadouroDaDengue = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        numCriadouro.GetComponent<Text>(); 
        mosquitosNacena = 0;
        criadouroDaDengue++;       
    }
    void Update()
    {
        numCriadouro.text = criadouroDaDengue.ToString();
        mosquitosTotais = mosquitosTotais + mosquitosNacena;
        if(mosquitosNacena == limitSpwan)
        {
            enabledSpawn = false;
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
          if (enabledSpawn)
            {
                // Instancia um inimigo no ponto de spawn
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                mosquitosNacena++;
            }
            // Espera o intervalo de spawn antes de instanciar o próximo inimigo
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}