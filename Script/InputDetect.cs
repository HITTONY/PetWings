using UnityEngine;
using System.Collections;

public class InputDetect : MonoBehaviour {
	// Use this for initialization
	private int gamestate;

	public GUITexture LeftButton;
	public GUITexture RightButton;
	public GUITexture FireButton;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKey (KeyCode.RightArrow))
//			P.move(0);
//		if (Input.GetKey (KeyCode.LeftArrow))
//			P.move(1);
		gamestate = GameManager.instance.Game_State;
		if (gamestate == 1) {
//			if (Input.GetKey (KeyCode.RightArrow)) {
//			if (Input.GetMouseButton (0) &&buttonclick(RightButton)) {
//				GameManager.instance.PlayerMove (0);
//			}
//			if (Input.GetMouseButton (0) &&buttonclick(LeftButton)) {
//				GameManager.instance.PlayerMove (1);
//			}
//			if (Input.GetMouseButtonDown (0) &&buttonclick(FireButton)) {
//				GameManager.instance.PlayerShoot ();
//			}
			if (Input.GetMouseButton (0) &&buttonclick(RightButton)) {
				GameManager.instance.PlayerMove (0);
			}
			if (Input.GetMouseButton (0) &&buttonclick(LeftButton)) {
				GameManager.instance.PlayerMove (1);
			}
			if (phoneclick(FireButton)) {
				GameManager.instance.PlayerShoot ();
			}
//			if (Input.GetKey(KeyCode.RightArrow)) {
//				GameManager.instance.PlayerMove (0);
//			}
//			if (Input.GetKey(KeyCode.LeftArrow)) {
//				GameManager.instance.PlayerMove (1);
//			}
//			if (Input.GetKeyDown (KeyCode.Space)) {
//				GameManager.instance.PlayerShoot ();
//			}
		}

	}

	bool buttonclick(GUITexture t)
	{
		Rect rect=t.GetScreenRect();
		Vector3 mousePos=Input.mousePosition;
		//		print (mousePos);
		if ((mousePos.x > rect.x) 
		    && (mousePos.x < rect.x + rect.width) 
		    && (mousePos.y > rect.y) 
		    && (mousePos.y < rect.y + rect.height))
			return true;
		else
			return false;
	}

	bool phoneclick(GUITexture t)
	{
		Rect rect=t.GetScreenRect();
		Vector2 touchPos = Input.GetTouch (0).position;
		if ((touchPos.x > rect.x) 
		    && (touchPos.x < rect.x + rect.width) 
		    && (touchPos.y > rect.y) 
		    && (touchPos.y < rect.y + rect.height)&&Input.GetTouch(0).phase==TouchPhase.Began)
			return true;
		else
			return false;
	}
}
