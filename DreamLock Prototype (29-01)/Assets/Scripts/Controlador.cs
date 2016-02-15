using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controlador : MonoBehaviour {

	static public int score;
	public Text pontos;
	// Use this for initialization
	void Start () {
		score = 0;
		pontos.text = "SCORE:" + score;
	}

	// Update is called once per frame
	void FixedUpdate () {
		pontos.text = "SCORE:" + score;
	}
}
