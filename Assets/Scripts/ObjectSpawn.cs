using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectSpawn : MonoBehaviour {

	public GameObject inputGO;
	public GameObject text1;
	public GameObject text2;
	public GameObject text3;
	public GameObject text4;
	public GameObject gameover;
	public Text scoreText;
	public Text average;
	public Text performance;

	public InputField input;

	public GameObject Soccer;
	public GameObject Basketball;
	public GameObject Tennis;
	public GameObject Pool;
	public GameObject Bowling;
	public GameObject Baseball;
	Vector3 objectPosition;
	int randomNum = 0;


	public int currentRound;
	public int rounds;
	public int numObject;
	public int rerolls;
	public bool reRoll;

	public float timer;
	public float maxTimer;
	public float score;
	public float averageReactionTime;
	public int numCorrectAnswers;


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

	bool userHit;

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
		text4 = GameObject.FindGameObjectWithTag("text4");
		gameover= GameObject.FindGameObjectWithTag("gameover");

		text4.SetActive(false);
		text3.SetActive(false);
		gameover.SetActive(false);

		numObject = 1;
		currentRound = 1;
		rounds = 2;

		score = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//game over
		if(currentRound > rounds)
		{
			text1.SetActive(false);
			text2.SetActive(false);
			text3.SetActive(false);
			text4.SetActive(false);
			gameover.SetActive(true);
			showingObject = false;
			showingSixObjects = false;

			int scoreInt = (int)(score * 10);
			scoreText.text = "Score: " + scoreInt.ToString();
			average.text = "Average Reaction Time: " + (averageReactionTime/numCorrectAnswers).ToString();
		}

		//game start
		if(selectingTrials)
		{
			if (Input.GetKeyDown ("space"))
			{
				rounds = int.Parse(input.text);
				rerolls = rounds / 4;
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
			text4.SetActive(false);
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
			text4.SetActive(true);
			if(numObject >= 6)
			{
				numObject = 0;
				showingObject = true;
				showingSixObjects = false;
				objectPicked = false;
				maxTimer = 2;
				text3.SetActive(true);
				currentRound++;
			}

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

					//okay lets weight the chance of the actual target showing up based on the number of trials selected

					//reroll for every 3 trials selected
					if(type == correctType)
					{
						if(rerolls < rounds / 3)
						{
							reRoll = true;
							rerolls++;
						}
					}

					//position the object if needed
					objectPosition = this.gameObject.transform.position;
					objectPosition.y += 2;
					newObject.gameObject.transform.position = objectPosition;

					if(!reRoll)
					{
						timer = 0;
						objectPicked = true;
						rerolls = 0;
						reRoll = false;
					}

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
						numObject++;
						userHit = false;
					}
					timer += Time.deltaTime;

					//handle user input
					if (Input.GetKeyDown ("space") && !userHit)
					{
						userHit = true;
						if(type == correctType)
						{
							print("correct1");
							score+= maxTimer - timer;
							averageReactionTime += timer;
							numCorrectAnswers++;
							print (score);
						}
						else
						{
							print("wrong!");
							score -= 1;
							print (score);
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
