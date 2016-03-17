using UnityEngine;
using System.Collections;

public class BoardData : MonoBehaviour {

	public Player P;
	private int PlayerHealth;
	private int PlayerPotions;
//	private string PlayerStage;
	private int PlayerPower;
	private GameObject LifeBoard;
	public GameObject Hearts;

	public GUIText PotionNumbers;

//	public GameObject PowerUps;
//	private AudioSource A_PU;
//	private float poweruplasttime=0.0f;
//
//	private float GetReadytime;
//	private float GetReadymaxtime;
//	public GameObject Get_Ready;
//	private AudioSource A_GR;

//	public GameObject PotionOne;
//	public GameObject PotionTen;
//	public GameObject PotionHun;
//
//	private SpriteRenderer SR1;
//	private SpriteRenderer SR2;
//	private SpriteRenderer SR3;

//	public Sprite[] sp=new Sprite[10];

	// Use this for initialization
	void Start () {
		LifeBoard = GameObject.Find ("LifeBoard");
		DisplayLife (PlayerHealth);
//		GetReadymaxtime = 1.0f;
//		PowerUps = GameObject.Find ("PowerUp");
		DisplayPotion (PlayerPotions);
//		SR1 = PotionOne.GetComponent<SpriteRenderer> ();
//		SR2 = PotionTen.GetComponent<SpriteRenderer> ();
//		SR3 = PotionHun.GetComponent<SpriteRenderer> ();
//		A_PU = this.GetComponents<AudioSource> ()[0];
//		A_GR = this.GetComponents<AudioSource> ()[1];

	}

	public void  initialize(int P_Health,int P_Potion,int P_Power)
	{
		this.PlayerHealth = P_Health;
		this.PlayerPotions = P_Potion;
//		this.PlayerStage = P_Stage;
		this.PlayerPower = P_Power;
	}

	public void DisplayLife(int life)
	{
		Vector3 LifeBoard_pos = LifeBoard.transform.position;
		GameObject[]  go=GameObject.FindGameObjectsWithTag ("Heart");
		for (int i=0; i<go.Length; i++) {
			Destroy(go[i]);
		}
//		print (LifeBoard_pos);
//		print (life);
		for (int i=1; i<=life; i++) {
			Instantiate(Hearts,LifeBoard_pos+new Vector3((float)(0.2+0.5*i),0,0),this.transform.rotation);
		}
	}

//	public void DisplayPowerUp()
//	{
//		PowerUps.SetActive (true);
//		A_PU.Play ();
//	}
//
//	public void GetReady()
//	{
//		Get_Ready.SetActive (true);
//		A_GR.Play ();
//	}
	public void DisplayPotion(int potion)
	{
//		GameObject spirit=GameObject
//		print (potion);
		PotionNumbers.text = potion.ToString();


	}

	
	// Update is called once per frame
	void Update () {
//		PlayerHealth = (P.GetComponent<Player> ()).getHealth ();
//		print (PlayerHealth);
//		if (PowerUps.activeSelf == true) {
//			poweruplasttime += Time.deltaTime;
//			if(poweruplasttime>1.5f)
//			{
//				poweruplasttime=0.0f;
//				PowerUps.SetActive(false);
//			}
//		}
//		if (Get_Ready.activeSelf == true) {
//			GetReadytime +=Time.deltaTime;
//			if(GetReadytime>GetReadymaxtime){
//				GetReadytime=0.0f;
//				Get_Ready.SetActive(false);
//			}
//		}
	}
}
