using UnityEngine;
using System.Collections;

public class PrefabLivePeriod : MonoBehaviour {

	// Use this for initialization
	public float survivetime;
	float tmp=0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		tmp += Time.deltaTime;
		if (tmp >= survivetime)
			Destroy (this.gameObject);
	}
}
