using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
//	public bool movable;
//	public BoardData B;
	public int Potion;
	private int health=8;
	public int FirePower;
	public float speed;
	public GameObject bulletprefeb;
	public AudioSource shotsound;
	public AudioSource gethurtsound;
	public AudioSource collectpotion;
	private Animator P_Anim;
	float tmp;
	bool ifinvicible;

//	private float InvicibleTime;
//	public GameObject go;
//	void Awake()
//	{
//		DontDestroyOnLoad (transform.gameObject);
//	}


	void Start () {
//		movable = false;
//		Potion = 0;
//		health = 5;
		speed = 6.0f;
		shotsound = (this.GetComponents<AudioSource> ())[0];
		gethurtsound = (this.GetComponents<AudioSource> ())[1];
		collectpotion = (this.GetComponents<AudioSource> ())[2];
//		FirePower = 1;
		P_Anim = this.GetComponent<Animator> ();
//		InvicibleTime = 2.0f;
		tmp = 0.0f;
		ifinvicible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ifinvicible) {
			tmp+=Time.deltaTime;
//			print (tmp);
			if(tmp>2.0f)
			{
				P_Anim.SetBool("GetHurt",false);
				P_Anim.SetBool("Recover",true);
				tmp=0.0f;
				ifinvicible=false;
			}
		}
//		print (health);
	}

	public int getHealth ()
	{
		return this.health;
	}

	public void setHealth (int h)
	{
		this.health = h;
	}

	public void PowerUp()
	{
		collectpotion.Play ();
		this.Potion++;
//		B.DisplayPotion (Potion);
		GameManager.instance.DisplayPotion (Potion);
		if (this.Potion==((FirePower)*30)&&this.Potion<=60) {
//			B.DisplayPowerUp ();
			GameManager.instance.DisplayPowerUp();
			this.FirePower++;
		}
	}

	public void shoot()
	{
//		Instantiate (bulletprefeb,transform.position,transform.rotation);
		float pos_x = this.transform.position.x;
		float pos_y = this.transform.position.y;
		float pos_z = this.transform.position.z;

		switch (this.FirePower) {
			case 1:
			{
			Instantiate(bulletprefeb,new Vector3(pos_x,pos_y+0.35f,pos_z),this.transform.rotation);
				break;
			}
			case 2:
			{
			Instantiate(bulletprefeb,new Vector3(pos_x-0.15f,pos_y+0.35f,pos_z),this.transform.rotation);
			Instantiate(bulletprefeb,new Vector3(pos_x+0.15f,pos_y+0.35f,pos_z),this.transform.rotation);
				break;
			}
			case 3:
			{
				Instantiate(bulletprefeb,new Vector3(pos_x-0.45f,pos_y+0.35f,pos_z),this.transform.rotation);
				Instantiate(bulletprefeb,new Vector3(pos_x-0.15f,pos_y+0.35f,pos_z),this.transform.rotation);
				Instantiate(bulletprefeb,new Vector3(pos_x+0.15f,pos_y+0.35f,pos_z),this.transform.rotation);
				Instantiate(bulletprefeb,new Vector3(pos_x+0.45f,pos_y+0.35f,pos_z),this.transform.rotation);
				break;
			}
		}
//		if(this.FirePower==1)
//			Instantiate(bulletprefeb,this.transform.position,this.transform.rotation);

		shotsound.Play ();
	}

	public void move(int direction)
	{
		if(direction==0)
		{
			if(transform.position.x<9f)
			this.transform.Translate(new Vector3(speed*Time.deltaTime,0,0));
		}
		else
		{
			if(transform.position.x>-9f)
			this.transform.Translate(new Vector3(-speed*Time.deltaTime,0,0));
		}
	}

//	void InvinvibleTime()
//	{
//		tmp += Time.deltaTime;
//		if (tmp > 2.0f) {
//			P_Anim.SetBool("GetHurt",false);
//			tmp=0.0f;
//		}
//	}

	public void GetHurt()
	{
		//		gethurtsound.Play ();
		if (!ifinvicible) {
			health--;
			if(health==0)
			{
				GameManager.instance.DisplayLife(health);
				gethurtsound.Play();
				GameManager.instance.GameOver();
				return;
			}
			GameManager.instance.DisplayLife(health);
			gethurtsound.Play();
			ifinvicible = true;
		}
//		InvinvibleTime ();

//		if (health == 0) {
//			Instantiate(explode,this.transform.position,this.transform.rotation);
//			Destroy(this.gameObject);
//		}
		P_Anim.SetBool ("GetHurt",true);
		P_Anim.SetBool ("Recover",false);
//		P_Anim.SetBool ("GetHurt",false);

//		P_Anim.SetFloat ("InvincibleTime", tmp);
	}
}
