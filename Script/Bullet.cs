using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
	public GameObject hurtmark;
	// Use this for initialization
	void Start () {
		speed = 8.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.instance.Game_State==1)
			this.transform.Translate (0, Time.deltaTime * speed, 0);
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "BulletKill")
			Destroy (this.gameObject);
		else if (other.tag == "Enemy") {
			Instantiate(hurtmark,this.transform.position,this.transform.rotation);
			(other.gameObject.GetComponent<Enemy>()).GetHurt();
			Destroy (this.gameObject);
		}
		else if (other.tag == "Boss") {
			Instantiate(hurtmark,this.transform.position,this.transform.rotation);
			(other.gameObject.GetComponent<Boss1>()).GetHurt();
			Destroy (this.gameObject);
		}
	}
}
