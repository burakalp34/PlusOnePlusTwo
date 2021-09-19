using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChecker : MonoBehaviour {
	public string SceneCode = "Reload", ComingSceneCode = "MainMenuReload";
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt (SceneCode, 1);
		PlayerPrefs.SetInt (ComingSceneCode, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
