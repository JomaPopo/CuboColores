using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;



public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool pause;

    public VidaPersonaje personajevida;
    public string nombreDeLaEscena;
    public Player AddScore;
    public int puntos;
    public int LIFEEE;
    //public UnityEvent OnDiedEscene;
    public static event Action OnDiedEscene;


    void OnEnable()
    {

        VidaPersonaje.OnHeartTouched += AumentarVida;
        VidaPersonaje.OnTouchDoorWin += GanasteFinal;
        Player.OnCoinCollected += AddPoints;
    }
    void OnDisable()
    {
        VidaPersonaje.OnHeartTouched -= AumentarVida;
        VidaPersonaje.OnTouchDoorWin -= GanasteFinal;
        Player.OnCoinCollected -= AddPoints;
    }


    private void Start()
    {
        personajevida = personajevida.GetComponent<VidaPersonaje>();
    }

    void Update()
    {
        CambiarMuerto();

    }

    public void pausa()
    {
        pause = !pause;
        if (pause)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }





    public void AddPoints()
    {

        AddScore.score = AddScore.score + puntos;
        Debug.Log("Puntos: " + AddScore.score);

    }


    public void AumentarVida()
    {
        personajevida.vida = personajevida.vida + LIFEEE;
        Debug.Log("Vida actual: " + personajevida.vida);


    }

    public void CambiarMuerto()
    {
        if (personajevida.vida <= 0)
        {
            OnDiedEscene?.Invoke();
        }

    }

    public void GanasteCausa()
    {

        SceneManager.LoadScene("game2");
    }
    public void GanasteFinal()
    {
        SceneManager.LoadScene("Gano");
    }
}