using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int Game_State;//0，刚开始 1，开始 2，武器升级暂停 3游戏结束(失败或成功)

	public Player P;
	public BoardData B;
	public static GameManager instance;

	public GameObject Get_Ready;
	public GameObject Power_Up;
	public GameObject Game_Over;
	public GameObject Open;
	public GameObject Quit;

	private float pausetime;
	private float pausemaxtime;

	private float getreadytime;
	private float getreadymaxtime;

	private int ObjectNumber;
	private int EnemyNumber;
//	private int PotionNumber;

//	private float checktime;

//	private float gameovertime;
//	private float gameovermaxtime;


	
	void Awake()
	{
		bool b=PlayerPrefs.HasKey("iffirst");
		if (b == false) {
			PlayerPrefs.SetInt ("iffirst", 1);
			PlayerPrefs.SetInt ("FirePower",1);
			PlayerPrefs.SetInt ("Health", 8);
			PlayerPrefs.SetInt ("Potion",0);
//			PlayerPrefs.SetInt ("CurrentLevel",1);
		}
		PlayerPrefs.SetInt ("CurrentLevel", Application.loadedLevel);
		P.setHealth (PlayerPrefs.GetInt("Health"));
		P.Potion =(PlayerPrefs.GetInt("Potion"));
		P.FirePower =(PlayerPrefs.GetInt("FirePower"));

		instance = this;
//		DontDestroyOnLoad (transform.gameObject);
	}
	// Use this for initialization

	public void loadnextlevel()
	{
		PlayerPrefs.SetInt ("FirePower",P.FirePower);
		PlayerPrefs.SetInt ("Health", P.getHealth());
		PlayerPrefs.SetInt ("Potion",P.Potion);
		int current=(PlayerPrefs.GetInt("CurrentLevel"))+1;
		PlayerPrefs.SetInt ("CurrentLevel",current);
//		print ("Load"+PlayerPrefs.GetInt("CurrentLevel"));
		Application.LoadLevel(PlayerPrefs.GetInt("CurrentLevel"));
	}


//	int getremainedobjectnumber()
//	{
//		this.ObjectNumber=this.EnemyNumber+this.PotionNumber;
//		return ObjectNumber;
//	}

	int getenemynumber()
	{
		int ENumber = ((GameObject.FindGameObjectsWithTag ("Enemy"))).GetLength (0);
//			+ ((GameObject.FindGameObjectsWithTag ("Boss"))).GetLength (0);
		return ENumber;
	}
//	int getpotionnumber()
//	{
//		this.PotionNumber =(GameObject.FindGameObjectsWithTag ("Potion")).GetLength (0);
//		return this.PotionNumber;
//	}



	void Start () {
//		checktime = 0.0f;
		Instantiate (Open, new Vector3 (0, 0, 0), this.transform.rotation);
		this.EnemyNumber=getenemynumber ();
//		getpotionnumber ();
//		getremainedobjectnumber ();
//		print (EnemyNumber);
		Game_State = 0;
		GetReady ();
//		B.GetReady ();
		pausemaxtime = 1.0f;
		getreadymaxtime = 1.0f;
//		gameovermaxtime = 5.0f;
		B.initialize (P.getHealth (), P.Potion, P.FirePower);
//		B.DisplayLife (P.getHealth ());
//		B.DisplayPotion (P.Potion);

	}

	public void pass()
	{
//		if (this.EnemyNumber == 0) {
//			print (EnemyNumber);
//			print ("0");
		Instantiate (Quit, new Vector3 (0, -10.5f, 0), this.transform.rotation);
//		}
			//			print (PlayerPrefs.GetInt("CurrentLevel"));
	}

	public void EnemyDestroyed()
	{
		EnemyNumber--;
//		print (EnemyNumber);
		if(this.EnemyNumber==0)
			pass ();
//		pass ();

	}

	public void BossDestroyed()
	{
		pass();
	}

//	public void PotionDestroy()
//	{
//		PotionNumber--;
////		pass ();
//	}

//	public void PotionProduced()
//	{
//		PotionNumber++;
//	}

	public void GetReady()
	{
		Instantiate(Get_Ready,new Vector3(0,0,0),this.transform.rotation);
	}

	public void DisplayPotion(int Potion)
	{
		B.DisplayPotion (Potion);
	}

	public void DisplayLife(int life)
	{
		B.DisplayLife (life);
	}
		
	public void DisplayPowerUp()
	{
		Instantiate(Power_Up,new Vector3(0,0,0),this.transform.rotation);
		this.Game_State = 2;
	}

	public void MakeMovable()
	{
		this.Game_State = 1;
	}

	public void PlayerMove(int dir)
	{
		P.move (dir);
	}
	public void PlayerShoot()
	{
		P.shoot ();
	}

	public void GameOver()
	{
		this.Game_State = 3;
		Destroy(P.gameObject);
		Instantiate(Game_Over,new Vector3(0,0,0),this.transform.rotation);
		PlayerPrefs.DeleteKey ("iffirst");
		Application.LoadLevel (0);
	}
	
	// Update is called once per frame
	void Update () {
//		print (((GameObject.FindGameObjectsWithTag ("Enemy"))).GetLength (0)+","+((GameObject.FindGameObjectsWithTag ("Boss"))).GetLength (0));
		if (this.Game_State == 2) {
			pausetime += Time.deltaTime;
			if(pausetime>pausemaxtime)
			{
				this.Game_State=1;
				pausetime=0;
			}
		}
		if (this.Game_State == 0) {
			getreadytime += Time.deltaTime;
			if(getreadytime>getreadymaxtime)
			{
				this.Game_State=1;
				getreadytime=0;
			}
		}
	}
}
