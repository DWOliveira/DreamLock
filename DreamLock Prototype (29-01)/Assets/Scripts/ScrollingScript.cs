using UnityEngine;
using System.Collections;
//teste para scrolling em parallax


public class ScrollingScript : MonoBehaviour {
	//velocidade de scroll
	public Vector2 speed = new Vector2 (2,2);

	//distancia de movimento
	public Vector2 distance = new Vector2 (-1,0);

	//movimento associado à câmara
	public bool isLinkedToCamera = false;
	
	// Update is called once per frame
	void Update () {
		//Movimento

		Vector3 movimento = new Vector3 (speed.x*distance.x, speed.y*distance.y,0);
		movimento *= Input.GetAxis("Horizontal") * Time.deltaTime;
		transform.Translate(movimento);
		if (isLinkedToCamera){
			Camera.main.transform.Translate(movimento);
		}
	}
}
