using UnityEngine;
using System.Collections;

public class SetActiveIngredients : MonoBehaviour
{

	// Use this for initialization
	void Start () 
	{
		GameObject[] products=GameObject.Find("GameController").GetComponent<MainGameController>().customers[0].GetComponent<CustomerController>().availableProducts;

		IngredientsController[] ingredients = GetComponentsInChildren<IngredientsController> ();
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
		}

		

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
