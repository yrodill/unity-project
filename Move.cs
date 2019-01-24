using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public string status = "sick";
    public float m_speed = 100.0f;
    public Sprite m_frontSprite;
    public Sprite m_backSprite;
    public Sprite m_sideSprite;
    public SpriteRenderer m_renderer;
    public Rigidbody2D m_rigid;
    private Vector2 velocity;
    private string objet;
    

    // Use this for initialization
    void Start () {
        m_renderer = GetComponent<SpriteRenderer>();
        m_rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	/*void Update ()
    {
        m_renderer = GetComponent<SpriteRenderer>();
        m_rigid = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.LeftArrow))
        {   
            gameObject.transform.Translate(new Vector3(-m_speed * Time.deltaTime, 0, 0));
            m_renderer.sprite = m_sideSprite;
            m_renderer.flipX = true;
             
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(new Vector3(m_speed * Time.deltaTime, 0, 0));
            m_renderer.sprite = m_sideSprite;
            m_renderer.flipX = false;


        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(new Vector3(0, m_speed * Time.deltaTime, 0));
            m_renderer.sprite = m_backSprite;

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(new Vector3(0, -m_speed * Time.deltaTime, 0));
            m_renderer.sprite = m_frontSprite;

        }
    }*/

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

        else if (Input.GetKeyDown(KeyCode.Space) && PlayerXP.getScore() >= 50 && status != "sain" && GetComponent<SpriteRenderer>().sprite == m_backSprite && objet == "pnj")
        {

            PlayerXP.changeScore(-50);
            status = "sain";
            m_renderer.color = Color.white;
        }

        else if (Input.GetKeyDown(KeyCode.Space)  && GetComponent<SpriteRenderer>().sprite == m_sideSprite && objet == "secret bush")
        {
            PlayerXP.changeScore(500);
            print("Secret bush found : money is falling from the sky !");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag == "dark grass")
        {
            m_speed = 70.0f;
            status = "sick";
            m_renderer.color = Color.green;
        }
        else if(collision.gameObject.tag == "pnj" || collision.gameObject.tag == "secret bush")
        {
            objet = collision.gameObject.tag;
            FixedUpdate();
               
    
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

            m_speed = 100.0f;
 
    }

}
