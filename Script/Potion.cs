using UnityEngine;
using System.Collections;

public class Potion : MonoBehaviour {
	
//	public AudioSource collected;
	// Use this for initialization
//	private float speed;
	private Rigidbody self;
//	private Vector3 speed;
	private Vector3 force;

	void Start () {
//		collected = this.GetComponent<AudioSource> ();
		float ranx=Random.Range(-75,75);
		float rany=Random.Range(10,300);
//		float rany = 300;
//		float ranx =75;
		force=new Vector3(ranx,rany,0);
		(this.GetComponent<Rigidbody>()).AddForce (force);
//		GameManager.instance.PotionProduced ();
		self = this.GetComponent<Rigidbody> ();

		force=new Vector3(ranx,0,0);
//		speed = 8.0f;


	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.Game_State != 1) {
//			speed=self.velocity;
			self.Sleep ();
		} else {
			if(self.IsSleeping())
			{
				self.WakeUp();
				self.AddForce(force);
//				self.velocity=speed;
			}
		}

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "BulletKill") {
//			GameManager.instance.PotionDestroy();
			Destroy (this.gameObject);
		}
		if (other.tag == "Player") {
			(other.gameObject.GetComponent<Player>()).PowerUp();
//			GameManager.instance.PotionDestroy();
			Destroy (this.gameObject);
		}
	}
}
