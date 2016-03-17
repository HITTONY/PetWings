using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	private float survivetime;
//	public AudioSource explodesound;
	float tmp=0;
	// Use this for initialization
	void Start () {
		survivetime = 0.5f;
//		explodesound=this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.Game_State == 1) {
			tmp += Time.deltaTime;
			if (tmp >= survivetime)
				Destroy (this.gameObject);
		}
	}
}
