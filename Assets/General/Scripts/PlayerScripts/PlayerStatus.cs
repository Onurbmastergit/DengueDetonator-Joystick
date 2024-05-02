using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int vidaAtual;
    public int vidaTotal;
    public GameObject barLifeLimit;
    public GameObject HitImagem;
    public GameObject FaceHit1;
    public GameObject FaceHit2;
    public GameObject FaceHit3;
    public GameObject GameOverHud;
    public GameObject GameHud;
    public GameObject GameWinHud;
    public GameObject HandPlayer;
    public AudioSource TakeDamage;
    public AudioSource ScreamMan;

    private Image barLifeImage;

    void Start()
    {
        vidaAtual = vidaTotal;
        barLifeImage = barLifeLimit.GetComponent<Image>();
        GameHud.SetActive(true);
        GameOverHud.SetActive(false);
    }
    void Update()
    {
        AtualizarBarraVida();
        if(Spawner.criadouroDaDengue == 0)
        {
            GameWinHud.SetActive(true);
            HandPlayer.SetActive(false);
        }
    }

    public void ReceberDano(int valor)
    {
        TakeDamage.Play();
        vidaAtual -= valor;
        VerificarMorte();
        AtualizarBarraVida();
        HitImagem.SetActive(true);
        FaceHit1.SetActive(false);
        FaceHit2.SetActive(true);
        FaceHit3.SetActive(false);
        Invoke("DesabilitarHitImagem", 0.5f);
    }

    void VerificarMorte()
    {
        if (vidaAtual <= 0)
        {
            ScreamMan.Play();
           GameHud.SetActive(false);
           GameOverHud.SetActive(true);
           HandPlayer.SetActive(false);
        }
    }

    void DesabilitarHitImagem()
    {
        HitImagem.SetActive(false);
        FaceHit1.SetActive(false);
        FaceHit2.SetActive(false);
        FaceHit3.SetActive(true);
        Invoke("BackToFirstFace", 0.7f);
    }

    void AtualizarBarraVida()
    {
        if (barLifeImage != null)
        {
            float fillAmount = (float)vidaAtual / vidaTotal;
            barLifeImage.fillAmount = fillAmount;
        }
    }
    void BackToFirstFace()
    {
        FaceHit1.SetActive(true);
        FaceHit2.SetActive(false);
        FaceHit3.SetActive(false);
    }
}