using UnityEngine;

public class BasketDetector : MonoBehaviour
{
    [SerializeField] private int scoreValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        // Solo cuenta si el objeto tiene DuckMovement (es un pato)
        if (other.CompareTag("Duck"))
        {
            GameManager.Instance.AddScore(scoreValue);
            Destroy(other.gameObject);
        }
    }
}