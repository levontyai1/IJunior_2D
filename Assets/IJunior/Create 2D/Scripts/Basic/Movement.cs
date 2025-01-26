using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool("Move", true);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool("Move", true);
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            return;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetTrigger("Jump");
            return;
        }

        _animator.SetBool("Move", false);
    }
}
