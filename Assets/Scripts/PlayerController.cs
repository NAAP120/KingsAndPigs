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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    }

    private void Move()
    {
        Flip();
        m_rigidbody2D.linearVelocity = new Vector2(speed * m_gatherImput.valueX, m_rigidbody2D.linearVelocityY);
    }

    private void Flip()
    {
        if(m_gatherImput.valueX * direction < 0)
        {
            m_transform.localScale = new Vector3(-m_transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }
}
