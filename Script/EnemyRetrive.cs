using UnityEngine;
using System.Collections;

public class EnemyRetrive : MonoBehaviour {

	// Use this for initialization
	public int location;//1，上2,下3,左4,右
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy") {
			switch (location)
			{
			case 1:
				other.gameObject.transform.position-=new Vector3(0,11,0);break;
			case 2:
				other.gameObject.transform.position-=new Vector3(0,-11,0);break;
			case 3:
				other.gameObject.transform.position-=new Vector3(-19f,0,0);break;
			case 4:
				other.gameObject.transform.position-=new Vector3(19f,0,0);break;
			}
		}
	}
}
