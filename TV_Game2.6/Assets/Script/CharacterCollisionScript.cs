using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCollisionScript : MonoBehaviour {

	public int sceneIndex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadByIndex(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}

	void OnCollisionEnter2D (Collision2D col)
	{

		if(col.gameObject.tag == "enemy") 
		{
			//Application.LoadLevel ("GameOver");
		}

		if(col.gameObject.tag == "win") 
		{
			Application.LoadLevel ("YouWinScreen");
		}

	}



}
