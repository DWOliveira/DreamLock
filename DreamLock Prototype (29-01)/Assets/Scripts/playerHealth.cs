using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerHealth : MonoBehaviour {
	//Variaveis
	public float startingHealth = 1.0f;
	public float currentHealth;
	public Image healthSlider;
	public float waitTime = 30.0f;

	bool damaged;
	bool isDead;


	// Use this for initialization
	void Awake () {
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		damaged = false;
	}

	public void TakeDamage (float amount)
	{
		// Se houver interação, o dano será verdadeiro
		damaged = true;

		// Reduz a vida atual pela quantidade pedida pelo Inimigo.
		currentHealth -= amount;

		// Altera o tamanho da Barra Vital pelo número de vida atual.
		healthSlider.fillAmount = currentHealth;

		// Se o jogador tiver perdido a vida toda e se a sinalização que não morreu estiver ativa...
		if (currentHealth <= 0 && !isDead)
		{
			//... o nível reinicia.
			Death();

		}

	}

	void Death(){
		isDead = true;
		Application.LoadLevel(Application.loadedLevel);
	}

}