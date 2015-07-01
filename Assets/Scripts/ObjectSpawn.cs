using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectSpawn : MonoBehaviour {

	public GameObject inputGO;
	public GameObject text1;
	public GameObject text2;
	public GameObject text3;

	public InputField input;

	public GameObject Soccer;
	public GameObject Basketball;
	public GameObject Tennis;
	public GameObject Pool;
	public GameObject Bowling;
	public GameObject Baseball;
	Vector3 objectPosition;
	int randomNum = 0;
	public int spawnTimer = 0;
	public int spawnCounter = 0;
	public int currentRound;
	public int rounds;

	public float timer;
	public float maxTimer;


	GameObject newObject;

	//user input variables
	int correctType = 0;
	int type = 0;

	//states
	bool selectingTrials;
	bool showingObject;
	bool showingSixObjects;
	bool waitingOneSecond;

	bool objectPicked;


	void Start () {
		showingObject = false;
		selectingTrials = true;
		showingSixObjects = false;
		objectPicked = false;
		maxTimer = 2;
		waitingOneSecond = false;

		inputGO = GameObject.FindGameObjectWithTag("Input");
		input = inputGO.GetComponent<InputField>();

		text1 = GameObject.FindGameObjectWithTag("text1");
		text2 = GameObject.FindGameObjectWithTag("text2");
		text3 = GameObject.FindGameObjectWithTag("text3");
		text3.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if(selectingTrials)
		{
			if (Input.GetKeyDown ("space"))
			{
				rounds = int.Parse(input.text);
				selectingTrials = false;
				showingObject = true;

				Destroy(inputGO);
				text1.SetActive(false);
				text2.SetActive(false);
				text3.SetActive(true);
			}
		}

		//show random object for 2 seconds, then show 6 objects for 2 seconds with 1 second delay
		if(showingObject)
		{
			if(!objectPicked)
			{
			randomNum = Random.Range(1,7);
			if(randomNum == 1)
			{
				newObject = (GameObject)Instantiate( Soccer,this.gameObject.transform.position,this.gameObject.transform.rotation);
				correctType = 1;
			}
			else if(randomNum == 2)
			{
				newObject = (GameObject)Instantiate( Basketball,this.gameObject.transform.position,this.gameObject.transform.rotation);
				correctType = 2;
			}
			else if(randomNum == 3)
			{
				newObject = (GameObject)Instantiate( Tennis,this.gameObject.transform.position,this.gameObject.transform.rotation);
				correctType = 3;
			}
			else if(randomNum == 4)
			{
				newObject = (GameObject)Instantiate( Pool,this.gameObject.transform.position,this.gameObject.transform.rotation);
				correctType = 4;
			}
			else if(randomNum == 5)
			{
				newObject = (GameObject)Instantiate( Bowling,this.gameObject.transform.position,this.gameObject.transform.rotation);
				correctType = 5;
			}
			else if(randomNum == 6)
			{
				newObject = (GameObject)Instantiate( Baseball,this.gameObject.transform.position,this.gameObject.transform.rotation);
				correctType = 6;
			}
				//position the object if needed
				objectPosition = this.gameObject.transform.position;
				objectPosition.y += 2;
				newObject.gameObject.transform.position = objectPosition;

				timer = 0;
				objectPicked = true;
			}
			//show for two seconds
			if(objectPicked)
			{
				if(timer > maxTimer)
				{
					timer = 0;
					showingObject = false;
					showingSixObjects = true;
					waitingOneSecond  =true;
					maxTimer = 1;
					objectPicked = false;
					text3.SetActive(false);
				}
				timer += Time.deltaTime;
			}


		}

		if(showingSixObjects)
		{
			if(waitingOneSecond)
			{
				Destroy(newObject);
				if(timer > maxTimer)
				{
					timer = 0;
					waitingOneSecond = false;
					maxTimer = 2;
					objectPicked = false;
				}
				timer += Time.deltaTime;
			}

			if(!waitingOneSecond)
			{

				if(!objectPicked)
				{

					randomNum = Random.Range(1,7);
					if(randomNum == 1)
					{
						newObject = (GameObject)Instantiate( Soccer,this.gameObject.transform.position,this.gameObject.transform.rotation);
						type = 1;
					}
					else if(randomNum == 2)
					{
						newObject = (GameObject)Instantiate( Basketball,this.gameObject.transform.position,this.gameObject.transform.rotation);
						type = 2;
					}
					else if(randomNum == 3)
					{
						newObject = (GameObject)Instantiate( Tennis,this.gameObject.transform.position,this.gameObject.transform.rotation);
						type = 3;
					}
					else if(randomNum == 4)
					{
						newObject = (GameObject)Instantiate( Pool,this.gameObject.transform.position,this.gameObject.transform.rotation);
						type = 4;
					}
					else if(randomNum == 5)
					{
						newObject = (GameObject)Instantiate( Bowling,this.gameObject.transform.position,this.gameObject.transform.rotation);
						type = 5;
					}
					else if(randomNum == 6)
					{
						newObject = (GameObject)Instantiate( Baseball,this.gameObject.transform.position,this.gameObject.transform.rotation);
						type = 6;
					}
					//position the object if needed
					objectPosition = this.gameObject.transform.position;
					objectPosition.y += 2;
					newObject.gameObject.transform.position = objectPosition;

					timer = 0;
					objectPicked = true;

				}

				//wait two seconds, allow for user to hit space, then go back to waiting one second
				if(objectPicked)
				{
					if(timer > maxTimer)
					{
						timer = 0;
						waitingOneSecond = true;
						maxTimer = 1;
						type = 0;
					}
					timer += Time.deltaTime;

					//handle user input
					if (Input.GetKeyDown ("space"))
					{
						if(type == correctType)
						{
							print("correct1");
						}
						else
						{
							print("wrong!");
						}
					}
				}
			}
		}
	}

	void OnGUI()
	{

		
	}

}
