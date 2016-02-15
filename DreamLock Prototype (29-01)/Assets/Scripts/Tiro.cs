using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {
	private int rotacao = 0;
	public playerControlador heroi;
	public float velocidadetiro;
	private Rigidbody2D rb;

   

    // Use this for initialization
    void Awake () {
		heroi = GameObject.Find("heroi").GetComponent<playerControlador>();
	}
	
	// Update is called once per frame
	void Start () {


		rb= GetComponent<Rigidbody2D>();
		if(!heroi.facingRight){
			rb.AddForce(Vector2.left * velocidadetiro);	
		}else{
			rb.AddForce(Vector2.right * velocidadetiro);
		}

		//transform.Rotate(Vector3.forward * -rotacao);
		//transform.Translate(Vector3.forward * Time.deltaTime * velocidadetiro);


		//transform.position = new Vector2(transform.position.x+Time.deltaTime*velocidadetiro,transform.position.y);

	}

}
