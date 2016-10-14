using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Part_Controller : MonoBehaviour {
	public List <GameObject> part;
	// Use this for initialization
	public void hideAll(){
		foreach(GameObject piece in part){
			piece.SetActive(false);
		}
	}
	public void hidePiece(int i){
		for(int j = i+1; j < part.Count; i++){
			part [j].SetActive (false);	
		}
	}
	public void activePiece(int i){
		for(int j = 0; i <= i; i++){
			part [j].SetActive (true);	
		}
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
