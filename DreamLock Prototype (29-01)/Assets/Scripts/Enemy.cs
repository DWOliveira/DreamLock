using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//Variáveis
	public float attackDamage = 0.15f;
	public float timeBetweenAttacks = 0.5f;
	public int HP;
	public playerHealth playerHP;
	public playerControlador heroi;

	float timer;
	bool playerInRange;

	// Use this for initialization
	void Start () {
		playerHP = GameObject.Find("VisibleHP").GetComponent<playerHealth>();
		heroi = GameObject.Find("heroi").GetComponent<playerControlador>();
		HP = 3;
	}
	
	// Update is called once per frame
	void Update () {

		//contar o tempo desde que o Jogo começou.
		timer += Time.deltaTime;

		// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
		if(timer >= timeBetweenAttacks && playerInRange && HP > 0)
		{
			// ... attack.
			Attack ();
		}

		if (HP == 0){
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.tag == "Player")
		{
			playerInRange = true;
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Tiro"){
			HP = HP - 1;
			Destroy (col.gameObject);
		}
	}

	void OnTriggerExit2D (Collider2D col){


		if (col.tag == "Player")
		{
			playerInRange = false;
		}
	}
	void Attack ()
	{
		// Reset the timer.
		timer = 0f;

		// If the player has health to lose...
		if(playerHP.currentHealth > 0f)
		{
			// ... damage the player.
			playerHP.TakeDamage (attackDamage);
			heroi.rb2d.AddForce(Vector2.left * 300);
			StartCoroutine("AttackWait");
		}
	}


	IEnumerator AttackWait(){
		yield return new WaitForSeconds(timeBetweenAttacks);
		heroi.rb2d.velocity = Vector2.zero;
	}
}
