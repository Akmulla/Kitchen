using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

	//***************************************************************************//
	// This class manages pause and unpause states.
	//***************************************************************************//
	public static bool  soundEnabled;
	public static bool  isPaused;
	private float savedTimeScale;
	public GameObject pausePlane;

	enum Page {
		PLAY, PAUSE
	}
	private Page currentPage = Page.PLAY;


	void Awake (){		
		soundEnabled = true;
		isPaused = false;
		
		Time.timeScale = 1.0f;
		
		if(pausePlane)
	    	pausePlane.SetActive(false); 
	}


	void Update (){
		//touch control
		touchManager();
		
		//optional pause
		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyUp(KeyCode.Escape)) {
			//PAUSE THE GAME
			switch (currentPage) {
	            case Page.PLAY: 
					PauseGame(); 
					break;
	            case Page.PAUSE: 
					UnPauseGame(); 
					break;
	            default: 
					currentPage = Page.PLAY;
					break;
	        }
		}

		//debug restart
		if(Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevelName);
		}
	}


	void touchManager (){
		if(Input.GetMouseButtonUp(0)) {
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hitInfo)) {
				string objectHitName = hitInfo.transform.gameObject.name;
				switch(objectHitName) {
					case "PauseBtn":
					
						//pause is not allowed when game is finished
						if(MainGameController.gameIsFinished)
							return;
							
						switch (currentPage) {
				            case Page.PLAY: 
								PauseGame(); 
								break;
				            case Page.PAUSE: 
								UnPauseGame(); 
								break;
				            default: 
								currentPage = Page.PLAY;
								break;
				        }
						break;
					
					case "Btn-Resume":
						switch (currentPage) {
				            case Page.PLAY: 
								PauseGame(); 
								break;
				            case Page.PAUSE: 
								UnPauseGame(); 
								break;
				            default: 
								currentPage = Page.PLAY;
								break;
				        }
						break;
						
					case "Btn-Menu":
						UnPauseGame();
						Application.LoadLevel("Menu-c#");
						break;
						
					case "Btn-Restart":
						UnPauseGame();
						Application.LoadLevel(Application.loadedLevelName);
						break;
						
					case "End-Menu":
						Application.LoadLevel("Menu-c#");
						break;
						
					case "End-Restart":
						Application.LoadLevel(Application.loadedLevelName);
						break;

					//added
					case "End-LevelSelection":
						Application.LoadLevel ("LevelSelection-c#");
						break;
				}
			}
		}
	}


	void PauseGame (){
		print("Game in Paused...");
		isPaused = true;
		savedTimeScale = Time.timeScale;
	    Time.timeScale = 0;
	    AudioListener.volume = 0;
	    if(pausePlane)
	    	pausePlane.SetActive(true);
	    currentPage = Page.PAUSE;
	}


	void UnPauseGame (){
		print("Unpause");
	    isPaused = false;
	    Time.timeScale = savedTimeScale;
	    AudioListener.volume = 1.0f;
		if(pausePlane)
	    	pausePlane.SetActive(false);   
	    currentPage = Page.PLAY;
	}

}