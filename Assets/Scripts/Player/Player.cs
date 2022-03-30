using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody2D m_Rd2D;
    private Vector2 m_Movement;
    
    void Awake()
    {
        m_Rd2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        m_Movement.x = Input.GetAxisRaw("Horizontal");
        m_Movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        m_Rd2D.MovePosition(m_Rd2D.position + (m_Movement * moveSpeed * Time.fixedDeltaTime));
    }
}
