using UnityEngine;

public class Shooting : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Vector2 v2 = _spriteRenderer.flipX? Vector2.left : Vector2.right;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, v2, 2);

        if (hit)
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
