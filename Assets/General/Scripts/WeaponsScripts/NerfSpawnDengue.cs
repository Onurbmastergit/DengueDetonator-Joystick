using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfSpawnDengue : MonoBehaviour
{
    public GameObject aguaParada;
    public GameObject aguaDengue;
    public AudioSource CheckSound;
    

    public GameObject manager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Criadouro") && other.GetComponent<Spawner>().nerfado == false) 
        {
            Debug.Log("Parabens vc conseguiu nerfar o spawn");
            CheckSound.Play();
            other.GetComponent<Spawner>().nerfado = true;
            other.GetComponent<Spawner>().enabledSpawn = false;
           aguaParada.SetActive(true);
           aguaDengue.SetActive(false);
            
           Spawner.criadouroDaDengue--;
            if (manager.GetComponent<AnimationScript>().enabledHand == false && manager.GetComponent<AnimationScript>().numHands == 2)
            {
                manager.GetComponent<AnimationScript>().sandLimit--;
                
            }
           
        }
    }
}
