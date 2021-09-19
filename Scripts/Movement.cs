using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
	public float XAxis = -1f, TargetX = -1f, YAxis = 0, TargetY = 0, TimeFloat = 0.5f/*, LoadingFloat = 10f*/, TargetTime = 0f;
	public int CurrentBox = -1, Score = 0, HighScoreCounter = 0, LastTime = -5, SceneChecker = 0, ComingFrom;
	public bool GameOver = false, GameStarted = false, StartButtonPressed = false, RespawnScene = false, IncreaseTime = false;
	public BoxSpawner PleaseWork;
	public UnityEngine.UI.Text ScoreText, TimeText, GameOverScoreText, GameOverScoreText2, HighScore, HighScoreAnim;
	public GameObject TimeBlock, CameraVar, GameOverTopDown, UIGO, MainMenuUIGO, MainMenuUIGOAnim, MainMenuScoreOpener, StartButton;
	public AudioSource GameOverSFX, BGM;
	public string HighScoreKey = "HighScore", ScoreKey = "Score", SceneCode = "Reload", GameOpenKey = "MainMenuReload";
	// Use this for initialization
	void Start () {
		/*ComingFrom = PlayerPrefs.GetInt (GameOpenKey, 1);
		if (ComingFrom == 0) {
			MainMenuScoreOpener.SetActive (true);
		}*/
		SceneChecker = PlayerPrefs.GetInt (SceneCode, 0);
		if (SceneChecker == 0) {
			RespawnScene = false;
		}
		if (SceneChecker == 1) {
			StartButtonPressed = true;
			RespawnScene = true;
		}
		StartButtonPressed = false;
		HighScoreCounter = PlayerPrefs.GetInt(HighScoreKey, 0);
		Score = PlayerPrefs.GetInt (ScoreKey, 0);
		GameOverScoreText2.text = Score + "";
		Score = 0;
		/*if (RespawnScene) {
			StartButtonPressed = true;
		}*/
		//if (!RespawnScene) {
			HighScore.text = HighScoreCounter + "";
			HighScoreAnim.text = HighScoreCounter + "";
		//}
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeFloat <= 0f) {
			GameOver = true;
		}
		if (IncreaseTime && TimeFloat < TargetTime) {
			TimeFloat += Time.deltaTime + 0.2f;
		}
		if (IncreaseTime && TimeFloat > TargetTime) {
			TimeFloat = TargetTime;
			IncreaseTime = false;
		}
		if (GameOver) {
			//GameOverSFX.Play ();
			GameOverTopDown.gameObject.SetActive (true);
			UIGO.SetActive (false);
			if (Score > HighScoreCounter) {
				PlayerPrefs.SetInt(HighScoreKey, Score);
				PlayerPrefs.Save();
			}
			PlayerPrefs.SetInt (ScoreKey, Score);
			PlayerPrefs.Save ();
		}
		/*Destroy (LoadingScreen, 8.5f);
		LoadingFloat -= Time.deltaTime;
		if (LoadingFloat <= 0f) {
			GameStarted = true;
		}*/
		//if (GameStarted) {
			CameraVar.transform.position = new Vector3 (this.transform.position.x + 1f, CameraVar.transform.position.y, CameraVar.transform.position.z);
		//}
		if (GameOver && (this.transform.localScale.x + this.transform.localScale.y + this.transform.localScale.z) > 0.1f && TargetX == XAxis) {
			this.transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
		}
		if (GameStarted) {
			TimeFloat -= Time.deltaTime;
			TimeText.text = (int)TimeFloat + "";
		}
		if (Input.GetKeyDown (KeyCode.Alpha1) && !GameOver/* && GameStarted*/ && StartButtonPressed) {
			TargetX += 1;
			CurrentBox += 1;
			Score++;
			GameStarted = true;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2) && !GameOver/* && GameStarted*/ && StartButtonPressed) {
			TargetX += 2;
			CurrentBox += 2;
			Score++;
			GameStarted = true;
		}
		if (XAxis < TargetX) {
			XAxis += 0.1f;
			this.transform.position = new Vector3 (XAxis, YAxis, 0);
		}
		if (XAxis > TargetX) {
			XAxis = TargetX;
			this.transform.position = new Vector3 (XAxis, YAxis, 0);
		}
		if (YAxis < TargetY) {
			YAxis += 0.1f;
			this.transform.position = new Vector3 (XAxis, YAxis, 0);
		}
		if (XAxis > TargetX) {
			YAxis -= 0.1f;
			this.transform.position = new Vector3 (XAxis, YAxis, 0);
		}
		if (CurrentBox >= 0) {
			if (PleaseWork.Boxes [CurrentBox] == null) {
				GameOver = true;
				print ("Game Over by Misclick");
			}
		}
		if (CurrentBox >= 0) {
			if (PleaseWork.TimeBoxes [CurrentBox] != null && CurrentBox != LastTime) {
				LastTime = CurrentBox;
				TargetTime = TimeFloat + 3.5f;
				IncreaseTime = true;
			}
		}
		ScoreText.text = Score + "";
		GameOverScoreText.text = Score + "";
	}
	public void OnCollisionEnter(Collision cls){
		/*if (cls.gameObject.tag.Equals ("Please Die")) {
			GameOver = true;
			print ("Game Over by Void");
		}*/
	}
	public void Move1(){
		if (StartButtonPressed) {
			GameStarted = true;
			TargetX += 1;
			CurrentBox += 1;
			Score++;
		}
		if (XAxis < TargetX) {
			XAxis += 0.1f;
			this.transform.position = new Vector3 (XAxis, 0, 0);
		}
		if (XAxis > TargetX) {
			XAxis = TargetX;
			this.transform.position = new Vector3 (XAxis, 0, 0);
		}
	}
	public void Move2(){
		if (StartButtonPressed) {
			GameStarted = true;
			TargetX += 2;
			CurrentBox += 2;
			Score++;
		}
		GameStarted = true;
		if (XAxis < TargetX) {
			XAxis += 0.1f;
			this.transform.position = new Vector3 (XAxis, 0, 0);
		}
		if (XAxis > TargetX) {
			XAxis = TargetX;
			this.transform.position = new Vector3 (XAxis, 0, 0);
		}
	}
	public void MainMenu(){
		SceneManager.LoadScene ("P1P2");
	}
	public void Restart(){
		SceneManager.LoadScene ("P1P2Reloaded");
	}
	public void StartGame(){
		StartButtonPressed = true;
		UIGO.gameObject.SetActive (true);
		MainMenuUIGO.gameObject.SetActive (false);
		MainMenuUIGOAnim.gameObject.SetActive (true);
		StartButton.SetActive (false);
	}
	public void ExitGame(){
		Application.Quit ();
		PlayerPrefs.DeleteKey (GameOpenKey);
	}
}
