using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CareerLevelSetup : MonoBehaviour {
	
	///*************************************************************************///
	/// Use this class to set different missions for each level.
	/// when you click/tap on any level button, these values automatically get saved 
	/// inside playerPrefs and then get read when the game starts.
	///*************************************************************************///

	public GameObject label;				//reference to child gameObject
	public int levelID;						//unique level identifier. Starts from 1.

	public int levelPrize = 150;			//prize (money) given to player if level is finished successfully
	public int careerGoalBallance = 1500;	//mission goal
	public int careerAvailableTime = 300;	//mission time
	public bool  canUseCandy = true;		//are we allowed to use candy
	public int[] availableProducts;			//array of indexes of available products. starts from 1.

	//added
	public int[] availableSideRequests;	
	public int[] availableCustomers;
	//

	void Start (){
		
		if(CareerMapManager.userLevelAdvance >= levelID - 1) {
			//this level is open
			GetComponent<BoxCollider>().enabled = true;
			label.GetComponent<TextMesh>().text = levelID.ToString();
			GetComponent<Renderer>().material.color = new Color(1,1,1,1);
		} else {
			//level is locked
			GetComponent<BoxCollider>().enabled = false;
			label.GetComponent<TextMesh>().text = "Locked";
			GetComponent<Renderer>().material.color = new Color(1,1,1,0.5f);
		}
	}

}