using UnityEngine;
using UnityEngine.Events;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached = new UnityEvent();
    
    public event UnityAction Reached
    {
        add => _reached.AddListener(value);
        remove => _reached.RemoveListener(value);
    }
    public bool IsReached { get; private set; }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsReached)
            return;
        
        if (other.TryGetComponent(out Player player))
        {
            IsReached = true;
            _reached.Invoke();
        }
    }
}
