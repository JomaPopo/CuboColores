using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int score = 0;
    public GameIntEvent E_CoinCollected;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin")) 
        {




            E_CoinCollected.Raise(10);


        }
    }
}