using UnityEngine;
using System.Collections;

public class Menu_PetWing_Texture : MonoBehaviour {

	// Use this for initialization

//	private float periodtime;
//	private float tmp;
	private float speed;

	void Start () {
//		periodtime=2.0f;
//		tmp = -1.0f;
		speed = 0.5f;
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Collider")
			this.speed = -this.speed;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
//		if (tmp < 0.0f)
//			this.transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
//		if(tmp>0.0f)
//			this.transform.Translate (new Vector3 (0, -speed * Time.deltaTime, 0));
//		tmp += Time.deltaTime;
//		if (tmp > 1.0f)
//			tmp = -1.0f;
	}
}
