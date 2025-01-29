using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private float _long;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _startPosition;
    
    private Vector3 _finish;
    private bool _isFinish;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startPosition = GetComponent<Transform>().position;
        _finish = new Vector3(_startPosition.x + _long, _startPosition.y, 0);
    }

    private void Update()
    {
        if (!_isFinish)
        {
            _spriteRenderer.flipX = false;
            _rigidbody2D.linearVelocityX = 1f;
            if (transform.position.x >= _finish.x) _isFinish = true;
        }
        else
        {
            _spriteRenderer.flipX = true;
            _rigidbody2D.linearVelocityX = -1f;
            if (transform.position.x <= _startPosition.x) _isFinish = false;
        }
    }
}
