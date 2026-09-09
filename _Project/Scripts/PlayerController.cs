using UnityEngine;
using TMPro; // Requerido para controlar el texto de interfaz de usuario (UI) de Unity 6

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float speed = 8f; 
    private float horizontalInput;

    [Header("Salto")]
    [SerializeField] private float jumpForce = 12f; 
    [SerializeField] private Transform groundCheck; 
    [SerializeField] private float groundCheckRadius = 0.2f; 
    [SerializeField] private LayerMask groundLayer; 
    private bool isGrounded;

    [Header("Límite de Caída (Vacío)")]
    [SerializeField] private float fallLimit = -10f; 

    [Header("Interfaz de Usuario")]
    [SerializeField] private TextMeshProUGUI textoMonedas;
    private int monedasRecogidas = 0;
    private Rigidbody2D rb;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        startPosition = transform.position; 
        
        ActualizarTextoMonedas();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (transform.position.y < fallLimit)
        {
            Respawn();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    private void Respawn()
    {
        transform.position = startPosition; 
        rb.linearVelocity = Vector2.zero;   
    }

    public void RecogerMoneda()
    {
        monedasRecogidas++;
        ActualizarTextoMonedas();
    }

    private void ActualizarTextoMonedas()
    {
        if (textoMonedas != null)
        {
            textoMonedas.text = "Monedas: " + monedasRecogidas;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}