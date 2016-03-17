using UnityEngine;
using System.Collections;

public class Open_Black_Move : MonoBehaviour {

	public float speed=5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (new Vector3 (0,speed*Time.deltaTime,0));
	}
}
