using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour {

    public static double m_score;
    public AudioClip m_sound;
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
		
	}
    
    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Collision");
        if (other.gameObject.tag == "coins"){
            AudioManager.instance.PlaySound(m_sound);
            Destroy(other.gameObject);
            m_score += 50;
        }
    }

    public static double getScore()
    {
        return m_score;
    }

    public static void changeScore(double value)
    {   
        m_score += value;
    }

   
}
