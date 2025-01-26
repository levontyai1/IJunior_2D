using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _hit;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out Block block))
        {
            _hit?.Invoke();
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
