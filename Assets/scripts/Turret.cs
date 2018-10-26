using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	//integers
	public int curHealth;
	public int maxHealth;

	//floats
	public float distance;
	public float wakeRange;
	public float shootInterval;
	public float bulletSpeed = 100f;
	public float bulletTimer;

	//booleans
	public bool awake = false;
	public bool lookingRight;

	//references
	public GameObject bullet;
	public Transform target;
	public Animator anim;
	public Transform shootPointLeft;
	public Transform shootPointRight;
	private AudioSource sut;

	void Awake(){
		anim = gameObject.GetComponent<Animator>();
	}

	void Start(){
		curHealth = maxHealth;
		sut = GameObject.Find("sut").GetComponent<AudioSource>();
	}

	void Update(){
		anim.SetBool("Awake", awake);
		anim.SetBool("LookingRight", lookingRight);
		RangeCheck();
		if(target.transform.position.x > transform.position.x){
			lookingRight = true;
		}
		if(target.transform.position.x < transform.position.x){
			lookingRight = false;
		}
	}

	void RangeCheck(){
		distance = Vector3.Distance(transform.position, target.transform.position);
		if(distance < wakeRange){
			awake = true;
		}
		if(distance > wakeRange){
			awake = false;
		}
	}

	public void Attack(bool attackingRight){
		bulletTimer += Time.deltaTime;

		if(bulletTimer >= shootInterval){
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize();

			if(!attackingRight){
				GameObject bulletClone;
				bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
				sut.Play();
				bulletTimer = 0;
			}

			if(attackingRight){
				GameObject bulletClone;
				bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
				sut.Play();
				bulletTimer = 0;
			}
		}
	}
}
