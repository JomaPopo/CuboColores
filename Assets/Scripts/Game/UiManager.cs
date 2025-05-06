using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public Player punto;
    private float tiempoTranscurrido;

    [Header("Referencias UI")]
    public TextMeshProUGUI puntos;
    public TextMeshProUGUI textoTemporizador;

    void Start()
    {
        tiempoTranscurrido = 0f;
    }

    void Update()
    {
        UpdateScore();
        UpdateTime();
    }

    public void UpdateTime()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (textoTemporizador != null)
            textoTemporizador.text = "Time: " + tiempoTranscurrido.ToString("F2");
    }

    public void UpdateScore()
    {
        if (puntos != null)
            puntos.text = "Coins: " + punto.score.ToString();
    }
}
