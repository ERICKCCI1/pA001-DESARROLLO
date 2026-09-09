using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Objetivo")]
    [SerializeField] private Transform target; 

    [Header("Configuración")]
    [SerializeField] private float smoothing = 5f; 
    [SerializeField] private Vector3 offset = new Vector3(0f, 1f, -10f); 

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}