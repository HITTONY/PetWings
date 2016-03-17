using UnityEngine;
using System.Collections;

public class Boss1 : MonoBehaviour {

	// Use this for initialization
	private Transform Axis;
	private float eularspeed;
	private Vector3 speed;

	private int health;
	private int potionnumber;
	private int explodenumber;

	private AudioSource BossShoot;

	public GameObject explode;
	public GameObject potion;
	public GameObject Bullet_left;
	public GameObject Bullet_center;
	public GameObject Bullet_right;

	private float shootTimeMax;
	float deltime = 0.0f;

	void Start () {
		Axis=GameObject.FindGameObjectWithTag("Axis").transform;
		eularspeed=-2f;
		setData (30,30,10);
		shootTimeMax = 2.0f;
		BossShoot = this.GetComponent<AudioSource> ();
		speed = new Vector3 (2, 0, 0);
//		RotateBalls ();
	}

	void setData(int h,int p,int e)
	{
		this.health = h;
		this.potionnumber = p;
		this.explodenumber = e;
	}

	public void GetHurt()
	{
		//		gethurtsound.Play ();
		this.health--;
		if (health == 0) {
//			GameObject[] go=GameObject.FindGameObjectsWithTag("Ball");
//			for(int i=0;i<go.GetLength(0);i++)
//			{
//				Destroy(go[i]);
//			}
//			Destroy (GameObject.Find("FishMouth"));
//			Instantiate(explode,this.transform.position,this.transform.rotation);
			GameManager.instance.BossDestroyed();
			DropPotion(potionnumber);
			Createxplode(this.explodenumber);
			Destroy(this.gameObject);
		}
	}

	public void DropPotion(int number)
	{
		for (int i=1; i<=number; i++) {
			Instantiate(potion,this.transform.position,this.transform.rotation);
		}
	}

	void Createxplode(int number)
	{
		for (int i=1; i<=number; i++) {
			float ranx=Random.Range(-5,5);
			float rany=Random.Range(-5,5);
			Vector3 offset=new Vector3(ranx,rany,0);
			Instantiate(explode,this.transform.position+offset,this.transform.rotation);
		}
	}

	void RotateBalls()
	{
		Vector3 old = Axis.localEulerAngles;
		float x, y, z;
		x = old.x;
		y = old.y;
		z = old.z+eularspeed;
		Axis.localEulerAngles = new Vector3 (x, y, z);
//		Axis.GetComponent<Rigidbody> ().AddTorque(0,2,0);
	}

	public void shoot()
	{
		//		Instantiate (bulletprefeb,transform.position,transform.rotation);
		float pos_x = this.transform.position.x;
		float pos_y = this.transform.position.y;
		float pos_z = this.transform.position.z;
		BossShoot.Play ();
		
		Instantiate(Bullet_center,new Vector3(pos_x,pos_y-1.3f,pos_z),this.transform.rotation);
		Instantiate(Bullet_left,new Vector3(pos_x-0.5f,pos_y-1.3f,pos_z),this.transform.rotation);
		Instantiate(Bullet_right,new Vector3(pos_x+0.5f,pos_y-1.3f,pos_z),this.transform.rotation);
//		left.GetComponent<Rigidbody> ().AddForce (new Vector3(75,0,0));
//		right.GetComponent<Rigidbody> ().AddForce (new Vector3(-75,0,0));
//		left.
	}
	

	// Update is called once per frame
	void Update () {
		RotateBalls ();
		this.transform.position += speed * Time.deltaTime;
		if (GameManager.instance.Game_State==1) {
			deltime += Time.deltaTime;
			if (deltime > shootTimeMax) {
				this.shoot ();
				deltime = 0.0f;
			}
		}
	}
}
