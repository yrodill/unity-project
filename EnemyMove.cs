using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {


    public string status = "sick";
    public float m_speed = 100.0f;
    public Sprite m_frontSprite;
    public Sprite m_backSprite;
    public Sprite m_sideSprite;
    public SpriteRenderer m_renderer;
    public Rigidbody2D m_rigid;
    private Vector2 velocity;
    // Use this for initialization
    void Start () {
        m_renderer = GetComponent<SpriteRenderer>();
        m_rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity = new Vector2(-1, 0);
            m_rigid.MovePosition(m_rigid.position + (m_speed * velocity) * Time.fixedDeltaTime);
            m_renderer.sprite = m_sideSprite;
            m_renderer.flipX = true;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity = new Vector2(1, 0);
            m_rigid.MovePosition(m_rigid.position + (m_speed * velocity) * Time.fixedDeltaTime);
            m_renderer.sprite = m_sideSprite;
            m_renderer.flipX = false;


        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity = new Vector2(0, 1);
            m_rigid.MovePosition(m_rigid.position + (m_speed * velocity) * Time.fixedDeltaTime);
            m_renderer.sprite = m_backSprite;

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity = new Vector2(0, -1);
            m_rigid.MovePosition(m_rigid.position + (m_speed * velocity) * Time.fixedDeltaTime);
            m_renderer.sprite = m_frontSprite;

        }
    }
    }
