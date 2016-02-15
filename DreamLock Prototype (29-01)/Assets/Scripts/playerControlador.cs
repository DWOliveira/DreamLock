using UnityEngine;
using System.Collections;

public class playerControlador : MonoBehaviour {
	[HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool salto;
	[HideInInspector] public Rigidbody2D rb2d;

    public int velocidade;
    public int forcaSalto;
	public int downJump;
	public float timeJump;
	public Transform origemTiro;
    public Transform groundCheck;
	public GameObject Tiro;


    private Animator ControlAnimacao;
	private GameObject clone;
    private bool grounded = false;

    // Use this for initialization
    void Start () {

		salto=false;
        ControlAnimacao = gameObject.GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = Vector2.zero;
		grounded = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        //Ao detetar a plataforma, ele pode saltar

        if (Input.GetButtonDown("Jump") && grounded)
        {
			ControlAnimacao.SetBool ("salto", true);
			rb2d.velocity = Vector2.zero;
			//rb2d.isKinematic = false;
			rb2d.AddForce(Vector2.up * forcaSalto);
			StartCoroutine("jumpbreak");
        }
		if (GameObject.FindGameObjectsWithTag("Tiro").Length <= 2){
			if (Input.GetButtonDown("Fire1")) {
				print ("tiro");
				clone = Instantiate(Tiro, origemTiro.position, Quaternion.identity) as GameObject;
				Destroy(clone,2f);
				} 
		}

	
		ControlAnimacao.SetFloat("velocidade", Input.GetAxis("Horizontal"));
		if (Input.GetAxis ("Horizontal") == 0f) {
			ControlAnimacao.SetBool ("parado", true);
		} else {
			ControlAnimacao.SetBool ("parado", false);
		}
	}
	

    void FixedUpdate()
    {
		if (Input.GetAxis("Horizontal") > 0 && !facingRight)
			Flip ();
		    else if (Input.GetAxis("Horizontal") < 0 && facingRight)
			Flip ();
		transform.Translate (Vector2.right * Input.GetAxis("Horizontal") * velocidade*Time.deltaTime);

        //Ao detetar a plataforma, ele pode saltar

        
        if (Input.GetKeyDown("r"))  //Caso o Jogador carregue na tecla R durante o jogo todo
        {
			Application.LoadLevel(Application.loadedLevel);  //Volta para o nível 1
        }



    }
		

	public void Flip()
	{
		facingRight = !facingRight;
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag=="Ground"){
			grounded = true;

		}

	}
	void OnCollisionExit2D(Collision2D col){
		
		if (col.gameObject.tag=="Ground"){
			grounded = false;

		}
		
	}
	void OnCollisionStay2D(Collision2D col){
		
		if (col.gameObject.tag=="Ground"){
			grounded = true;

		}
		
	}
		

	IEnumerator jumpbreak(){
		yield return new WaitForSeconds(timeJump);
		rb2d.AddForce(Vector2.down * downJump);
		ControlAnimacao.SetBool ("salto", false);
	}
}
