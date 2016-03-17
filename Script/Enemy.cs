using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

//	public int health;
	public int EnemySpecies;//1小蜜蜂,2甲虫,3黄蜂,4不可摧毁但可以挡子弹

//	public bool movable;

	private int health;
	private int potionnumber;

	public GameObject explode;
	public GameObject potion;
	public GameObject Enemy_Bullet;

	private float shootTimeMax;
	private float movechangeTime;

	float movechangedeltime=0.0f;
	float deltime = 0.0f;
//	public AudioSource gethurtsound;

	// Use this for initialization
	void Start () {
//		health = 100;
//		gethurtsound = this.GetComponent<AudioSource> ();
//		movable = false;
		setData (EnemySpecies);
		shootTimeMax = 3.5f;
		movechangeTime = 1f;
	}

	void setData(int species)
	{
		if (species != 4) {
			this.health = species * 2;
			this.potionnumber = species * 3;
		} else {
			this.potionnumber = 0;
			this.health = 1;
		}
	}

	public void GetHurt()
	{
//		gethurtsound.Play ();
		if (this.EnemySpecies != 4) {
			this.health--;
		}
		if (health == 0) {
			GameManager.instance.EnemyDestroyed();
			Instantiate(explode,this.transform.position,this.transform.rotation);
			DropPotion(potionnumber);
			Destroy(this.gameObject);
		}
	}

	public void DropPotion(int number)
	{
		for (int i=1; i<=number; i++) {
			Instantiate(potion,this.transform.position,this.transform.rotation);
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			(other.gameObject.GetComponent<Player>()).GetHurt();
		}
	}

	public void shoot()
	{
		//		Instantiate (bulletprefeb,transform.position,transform.rotation);
		float pos_x = this.transform.position.x;
		float pos_y = this.transform.position.y;
		float pos_z = this.transform.position.z;
		
		Instantiate(Enemy_Bullet,new Vector3(pos_x,pos_y-0.35f,pos_z),this.transform.rotation);
	}

	public void move(int EnemySpecies)
	{
		switch(EnemySpecies){
		case 1:
			int x=Random.Range(0,2);
			if(x==1)
				this.GetComponent<Rigidbody> ().velocity = new Vector3(1,0,0);
			else
				this.GetComponent<Rigidbody> ().velocity = new Vector3(-1,0,0);
			break;
		case 2:
			int y=Random.Range(0,2);
			if(y==1)
				this.GetComponent<Rigidbody> ().velocity = new Vector3(-1f,-0.5f,0);
			else
				this.GetComponent<Rigidbody> ().velocity = new Vector3(1f,-0.5f,0);
			break;
		case 3:
			int z=Random.Range(0,2);
			if(z==1)
				this.GetComponent<Rigidbody> ().velocity = new Vector3(-0.5f,-0.5f,0);
			else
				this.GetComponent<Rigidbody> ().velocity = new Vector3(0.5f,-0.5f,0);
			break;

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.Game_State==1&&this.EnemySpecies!=4) {
			deltime += Time.deltaTime;
			movechangedeltime +=Time.deltaTime;
			if (deltime > shootTimeMax) {
				this.shoot ();
				deltime = 0.0f;
			}
			if(movechangedeltime>movechangeTime)
			{
				move (EnemySpecies);
				movechangedeltime=0.0f;
			}
		}
	}
}
