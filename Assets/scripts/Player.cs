using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	//floats
	public float maxSpeed = 3;
	public float speed = 50f;
	public float jumpPower = 250f;

	//booleans
	public bool grounded;
	public bool candoublejump;
	public bool direction;

	//stats
	public int qurHealth;
	public int maxHealth = 5;

	//references
	private Rigidbody2D rb2d;
	private Animator anim;
	private AudioSource ngajol;
	private AudioSource dar;

	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		ngajol = GameObject.Find("jump").GetComponent<AudioSource>();
		dar = GameObject.Find("dmg").GetComponent<AudioSource>();
		maxHealth = 5;
		qurHealth = maxHealth;
		direction = true;
	}

	void Update () {
		anim.SetBool("grounded", grounded);
		anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
	
		if(Input.GetAxis("Horizontal") < 0f){
			direction = false;
			transform.localScale = new Vector3(-1, 1, 1);
		}

		if(Input.GetAxis("Horizontal") > 0f){
			direction = true;
			transform.localScale = new Vector3(1, 1, 1);
		}

		if(Input.GetButtonDown("Jump")){
			if (grounded) {
				rb2d.AddForce (Vector2.up * jumpPower);
				ngajol.Play();
				candoublejump = true;
			}
			else{
				if(candoublejump){
					candoublejump = false;
					rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
					ngajol.Play();
					rb2d.AddForce(Vector2.up * jumpPower);
				}
			}
		}

		if(qurHealth > maxHealth){
			qurHealth = maxHealth;
		}

		if(qurHealth <= 0){
			Die();
		}

		if(transform.position.y < -5f){
			Die();
		}

	}

	void FixedUpdate(){
		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f;

		float h = Input.GetAxis("Horizontal");

		//fake friction / easing the x speed of our player
		if(grounded){
			rb2d.velocity = easeVelocity;
		}

		//moving the player
		rb2d.AddForce((Vector2.right * speed) * h);

		//limiting the speed of the player
		if(rb2d.velocity.x > maxSpeed){
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}

		if(rb2d.velocity.x < -maxSpeed){
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
	}

	void Die(){
		//restart
		//Application.LoadLevel(Application.loadedLevel);
		SceneManager.LoadScene("mtg");
	}

	public void Damage(int dmg){
		gameObject.GetComponent<Animation>().Play("player_damaged");
		qurHealth -= dmg;
		dar.Play();
	}

	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir){

		float timer = 0;

		while(knockDur > timer){

			timer += Time.deltaTime;

			if(direction == true){
				rb2d.velocity = new Vector2(0, 0);
				speed = 0f;
				rb2d.AddForce(new Vector3(knockbackDir.x + -150, knockbackDir.y + knockbackPwr, transform.position.z));
			}

			if(direction == false){
				rb2d.velocity = new Vector2 (0, 0);
				speed = 0f;
				rb2d.AddForce(new Vector3(knockbackDir.x + 150, knockbackDir.y + knockbackPwr, transform.position.z));
			}
		}
		yield return 0;
	}
}
