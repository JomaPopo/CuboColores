using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class VidaPersonaje : Player
{
    public int color;
    public int vida = 10;
    private SpriteRenderer spriteRenderer;
    // public UnityEvent OnHeartTouched;
    public bool TocastePuerta;
    public UnityEvent OnTouchDoorNext;
    // public UnityEvent OnTouchDoorWin;
    public CameraShake cameraShake;

    public static event Action OnHeartTouched;
    public static event Action OnTouchDoorWin;
    void OnEnable()
    {

        GameManager.OnDiedEscene += CambioDeEscena;
    }
    void OnDisable()
    {
        GameManager.OnDiedEscene -= CambioDeEscena;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void rojo()
    {
        spriteRenderer.color = Color.red;
        color = 1;
    }

    public void azul()
    {
        spriteRenderer.color = Color.blue;
        color = 2;
    }

    public void amarillo()
    {
        spriteRenderer.color = Color.yellow;
        color = 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Amarillo"))
        {
            if (color != 3)
            {
                vida -= 1;
                cameraShake.ShakeCamera(1);
            }
        }
        else if (collision.CompareTag("Azul"))
        {
            if (color != 2)
            {
                vida -= 2;
                cameraShake.ShakeCamera(2);
            }
        }
        else if (collision.CompareTag("Rojo"))
        {
            if (color != 1)
            {
                vida -= 3;
                cameraShake.ShakeCamera(3);
            }
        }
        else if (collision.CompareTag("MUERTEVACIO"))
        {
            vida = 0;
            cameraShake.ShakeCamera(2);
        }
        else if (collision.CompareTag("Life"))
        {
            OnHeartTouched?.Invoke();
        }
        else if (collision.CompareTag("Marron1"))
        {
            OnTouchDoorNext?.Invoke();
        }
        else if (collision.CompareTag("Marron2"))
        {
            OnTouchDoorWin?.Invoke();
        }


    }

    public void CambioDeEscena()
    {
        SceneManager.LoadScene("Perdio");
    }
}