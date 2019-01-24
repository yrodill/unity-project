using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UpdateScore : MonoBehaviour {

    public PlayerXP m_xp ;
    public Text m_txt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        string score = PlayerXP.getScore().ToString();
        m_txt.text = "Gils : " + score;
	}
}
