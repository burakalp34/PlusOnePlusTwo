using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {
	public GameObject Empty, Full, TimeS, TimeM, TimeB, FullWithTime;
	public int BoxCounter = 100, Type = 0, XAxis = 0, CurrentBox = 0, Destroyer = 0, TimeSpawner;
	public GameObject[] Boxes, TimeBoxes;
	public float Counter = 0.5f;
	public bool Tester = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (BoxCounter > 0) {
			Type = Random.Range (0, 2);
			TimeSpawner = Random.Range (1, 25);
			if (Type == 1 && CurrentBox > 0 && Boxes [CurrentBox - 1] != null) {
				/*GameObject go = Instantiate (Empty, new Vector3 (XAxis, 0, 0), Quaternion.identity);
				Boxes [CurrentBox] = go;*/
				if (Boxes [CurrentBox - 1] == null) {
					print ("Hello 911? I am at X " + XAxis + " but I shouldn't be here!");
				}
			} /*else if (Type == 1 && CurrentBox == 0) {
				GameObject go = Instantiate(Empty, new Vector3(XAxis, 0, 0), Quaternion.identity);
				Boxes [CurrentBox] = go;
			}*/
			else {
				if (TimeSpawner > 20 && TimeSpawner <= 24) {
					GameObject go = Instantiate (FullWithTime, new Vector3 (XAxis, 0, 0), Quaternion.identity);
					Boxes [CurrentBox] = go;
					TimeBoxes [CurrentBox] = go;
				}
				if (TimeSpawner <= 20) {
					GameObject go = Instantiate (Full, new Vector3 (XAxis, 0, 0), Quaternion.identity);
					Boxes [CurrentBox] = go;
				}
			}
			CurrentBox += 1;
			BoxCounter -= 1;
			XAxis += 1;
		}
	}
}
