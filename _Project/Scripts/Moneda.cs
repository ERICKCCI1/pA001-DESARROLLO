using UnityEngine;

public class Moneda : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController jugador = collision.GetComponent<PlayerController>();
        
        if (jugador != null)
        {
            jugador.RecogerMoneda(); 
            Destroy(gameObject);   
        }
    }
}