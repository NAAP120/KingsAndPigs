using System;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;
    private GatherInput m_gatherImput;
    private Transform m_transform;
    private Animator m_animator; 

    [SerializeField] private float speed;
    private int direction = 1;
    private int IdSpeed;
    [SerializeField] private float jumpForce;
    void Start()
    {
        m_gatherImput = GetComponent<GatherInput>();
        m_transform = GetComponent<Transform>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        IdSpeed = Animator.StringToHash("Speed");
    }

    private void Update()
    {
        SetAnimatorValues();
    }
    private void SetAnimatorValues()
    {
         m_animator.SetFloat(IdSpeed, MathF.Abs(m_rigidbody2D.linearVelocityX));
    }
    void FixedUpdate()
    {
        Move();
        Jump(); 
    }

    private void Move()
    {
        Flip();
        m_rigidbody2D.linearVelocity = new Vector2(speed * m_gatherImput.valueX, m_rigidbody2D.linearVelocity.y);
    }

    private void Flip()
    {
        if(m_gatherImput.valueX * direction < 0)
        {
            m_transform.localScale = new Vector3(-m_transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }
     private void Jump()
    {
        if (m_gatherImput.IsJumping)
    {
        m_rigidbody2D.linearVelocity = new Vector2(m_rigidbody2D.linearVelocity.x,jumpForce);
    }
    m_gatherImput.IsJumping = false;
    }
}
