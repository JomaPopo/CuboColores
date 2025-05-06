using UnityEngine;

public class MoverAB : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2f;

    private Vector2 destinoActual;

    void Start()
    {
        if (puntoA != null)
            transform.position = puntoA.position;

        destinoActual = puntoB.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destinoActual, velocidad * Time.deltaTime);

        // Si llegó al destino, cambiar al otro punto
        if (Vector2.Distance(transform.position, destinoActual) < 0.01f)
        {
            destinoActual = (Vector2)(destinoActual == (Vector2)puntoA.position ? puntoB.position : puntoA.position);
        }
    }
}
