using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int score = 0; // Puntos del jugador
    //public UnityEvent OnCoinCollected; // Evento que se activa al recolectar una moneda
    public static event Action OnCoinCollected;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin")) // Verificar si ha colisionado con una moneda
        {




            OnCoinCollected?.Invoke();


        }
    }
}