using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Attack");

            Vector2 v2 = _spriteRenderer.flipX ? Vector2.left : Vector2.right;
            Vector2 attackVector2 = new Vector2(transform.position.x, transform.position.y + 1f);

            RaycastHit2D hit = Physics2D.Raycast( attackVector2, v2, 2f, LayerMask.GetMask("Enemy"));

            if (hit)
            {
                Instantiate(_coin, new Vector2(hit.transform.position.x, hit.transform.position.y + 0.6f), Quaternion.identity);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
