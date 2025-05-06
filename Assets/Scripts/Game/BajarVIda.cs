using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BajarVIda : MonoBehaviour
{
    GameObject player;
    public VidaPersonaje personajevida;
    void Update()
    {
        if (personajevida.vida % 2 == 0 && personajevida.vida < 10)
{
    // Calcula la nueva escala basada en la vida actual
    float nuevaEscalaX = 1 - (10 - personajevida.vida) * 0.1f;
    Vector3 newScale = new Vector3(nuevaEscalaX, transform.localScale.y, transform.localScale.z);
    transform.localScale = newScale;
}
    }
}
