using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecharge : MonoBehaviour
{
    public bool spray;
    public bool areia;
    public bool repelente;

    public AudioSource PickUp;
    public AudioSource HealthPickUp;
    public Transform mainCameraTransform;

    void Update()
    {
        transform.LookAt(mainCameraTransform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && spray == true) 
        {
            if (other.GetComponent<AnimationScript>().sprayLimit < 0)
            {
                other.GetComponent<AnimationScript>().sprayLimit += 2;
            }
            other.GetComponent<AnimationScript>().sprayLimit++;
            PickUp.Play();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player") && areia == true)
        {
            if (other.GetComponent<AnimationScript>().sandLimit  < 0) 
            {
                other.GetComponent<AnimationScript>().sandLimit +=2;
            }
            other.GetComponent<AnimationScript>().sandLimit++;
            PickUp.Play();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player") && repelente == true)
        {

            other.GetComponent<PlayerStatus>().vidaAtual += 10;
            HealthPickUp.Play();
            Destroy(gameObject);
        }
    }
}
