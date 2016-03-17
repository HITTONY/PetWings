using UnityEngine;
using System.Collections;

public class hurtmark : MonoBehaviour {

	private float survivetime;
	float tmp=0;
	// Use this for initialization
	void Start () {
		survivetime = 0.5f;
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
