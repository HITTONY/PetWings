using UnityEngine;
using System.Collections;

public class Enemy_Bullet : MonoBehaviour {

	public float speed;
	public Vector3 force;
	// Use this for initialization
	void Start () {
		speed = 3.0f;
		this.GetComponent<Rigidbody> ().AddForce (force);
	}

	// Update is called once per frame
	void Update () {
		if(GameManager.instance.Game_State==1)
			this.transform.Translate (0, -Time.deltaTime * speed, 0);
	}
	
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "BulletKill")
			Destroy (this.gameObject);
		if (other.tag == "Player") {
			(other.gameObject.GetComponent<Player>()).GetHurt();
			Destroy (this.gameObject);
		}
	}
}
