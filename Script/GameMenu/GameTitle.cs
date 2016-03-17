using UnityEngine;
using System.Collections;

public class GameTitle : MonoBehaviour {

	// Use this for initialization
	public GUITexture StartButton;
	public GUITexture ExitButton;

	void Awake()
	{
		PlayerPrefs.DeleteAll ();
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) &&startbuttonclick()) {
			Application.LoadLevel(1);
			//			print("click");
		}

		if (Input.GetMouseButtonDown (0) &&exitbuttonclick()) {
			Application.Quit();
			//			print("click");
		}
	}
	
	
	bool startbuttonclick()
	{
		Rect rect=StartButton.GetScreenRect();
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

	bool exitbuttonclick()
	{
		Rect rect=ExitButton.GetScreenRect();
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
}
