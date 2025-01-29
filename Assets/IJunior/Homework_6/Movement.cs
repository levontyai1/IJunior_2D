using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Homework_6
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private float _horizontalValue;
        
        private bool _isJumping;
        private bool _isGrounded;
        
        private const float JumpPower = 100f;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _horizontalValue = Input.GetAxisRaw("Horizontal");
            
            if (Input.GetButtonDown("Jump"))
                _isJumping = true;
            else if (Input.GetButtonUp("Jump"))
                _isJumping = false;
            
            _animator.SetFloat("Vertical", _rigidbody2D.linearVelocityY);
        }

        private void FixedUpdate()
        {
            GroundCheck();
            Move(_horizontalValue, _isJumping);
        }

        void GroundCheck()
        {
            _isGrounded = false;
            
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f, LayerMask.GetMask("Ground"));
            if (colliders.Length > 0)
                _isGrounded = true;
            
            _animator.SetBool("IsJumping", !_isGrounded);
        }

        void Move(float dir, bool jumpFlag)
        {
            if (_isGrounded && jumpFlag)
            {
                jumpFlag = false;
                _rigidbody2D.AddForce(new Vector2(0f, JumpPower));
            }
            
            if (dir < 0)
                _spriteRenderer.flipX = true;
            else if (dir > 0)
                _spriteRenderer.flipX = false;
            
            _animator.SetFloat("Horizontal", Mathf.Abs(dir));
            _rigidbody2D.linearVelocity = new Vector2(dir * _speed, _rigidbody2D.linearVelocityY);
        }
    }
}