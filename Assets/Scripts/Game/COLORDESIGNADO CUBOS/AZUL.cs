using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AZUL : MonoBehaviour
{
    SpriteRenderer _compSpriteRenderer;
    private void Awake()
    {
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void CambiarAlColor()
    {
        _compSpriteRenderer.color = Color.blue;
    }
}
