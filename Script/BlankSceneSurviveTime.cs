using UnityEngine;
using System.Collections;

public class BlankSceneSurviveTime : MonoBehaviour {

	// Use this for initialization
	private float Survive=5.0f;
	private float tmp;
	void Start () {
		tmp = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		tmp += Time.deltaTime;
		if (tmp > Survive) {
			Application.LoadLevel(0);
		}
	}
}
