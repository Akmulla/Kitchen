using UnityEngine;
using System.Collections;

public class SetActiveSideRequests : MonoBehaviour {
	public GameObject coffeeMaker;
	// Use this for initialization
	void Start () 
	{
		coffeeMaker.SetActive (false);
		//GameObject[] sideRequests=GameObject.Find("GameController").GetComponent<MainGameController>().customers[0].GetComponent<CustomerController>().availableSideReqs;
		SideRequestsController[] sideRequests = GetComponentsInChildren<SideRequestsController> ();
		int sideRequestsCount = sideRequests.Length;
		for (int i = 0; i < sideRequestsCount; i++)
		{
			sideRequests [i].gameObject.SetActive (false);
		}

		if (PlayerPrefs.GetString ("gameMode") == "CAREER")
		{
			int totalAvailableSideRequests = PlayerPrefs.GetInt("availableSideRequests");
			for (int i = 0; i < totalAvailableSideRequests; i++)
			{
				int sideRequestNumber=PlayerPrefs.GetInt( "careerSideRequest_"+i.ToString());
				//sideRequestNumber--;
				for (int k=0;k<sideRequestsCount;k++)
				{
					if (sideRequestNumber == 4)
						coffeeMaker.SetActive (true);
					if (sideRequests [k].sideReqID == sideRequestNumber)
						sideRequests [k].gameObject.SetActive (true);
				}
			}
		}
		/*GameObject[] sideRequests=GameObject.Find("GameController").GetComponent<MainGameController>().customers[0].GetComponent<CustomerController>().availableSideReqs;

		SideRequestsController[] sideRequests = GetComponentsInChildren<SideRequestsController> ();
		int ingredientCount = ingredients.Length;
		for (int i = 0; i < ingredientCount; i++)
		{
			ingredients [i].gameObject.SetActive (false);
			//for(int j=0;j<ingredients[i].
		}

		if (PlayerPrefs.GetString ("gameMode") == "CAREER")
		{
			int totalAvailableProducts = PlayerPrefs.GetInt("availableProducts");
			for (int i = 0; i < totalAvailableProducts; i++)
			{
				int productNumber=PlayerPrefs.GetInt( "careerProduct_"+i.ToString());
				productNumber--;
				int[] ingredientsInProduct=products [productNumber].GetComponent<ProductManager> ().ingredientsIDs;
				int ingredientsInProductCount = ingredientsInProduct.Length;
				for (int j = 0; j < ingredientsInProductCount; j++)
				{
					for (int k=0;k<ingredientCount;k++)
					{
						if (ingredients [k].factoryID == ingredientsInProduct [j])
							ingredients [k].gameObject.SetActive (true);
					}
				}
			}
		}*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
