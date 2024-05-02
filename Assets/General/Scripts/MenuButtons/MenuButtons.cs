using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
public AudioSource StartSound;
void Update()
{
    if(Input.GetKeyDown(KeyCode.Joystick1Button0))
    {
        StartButton();
    }
}
public void StartButton()
{
    StartSound.Play();
    Invoke("LoadGameTest" , 2f);
}
void LoadGameTest()
{
     SceneManager.LoadScene("GameTest");
}
public void BackToTheMenu()
{
    SceneManager.LoadScene("Menu");
}

}
