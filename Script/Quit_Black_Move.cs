using UnityEngine;
using System.Collections;

public class Quit_Black_Move : MonoBehaviour {

	public float speed=5.0f;

//	public Quit_Black_Move instance;
//	// Use this for initialization
//	void Awake()
//	{
//		instance=this;
//	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.position;
		if (pos.y < 3)
			this.transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
		else {
			GameManager.instance.loadnextlevel();
		}
	}
}
