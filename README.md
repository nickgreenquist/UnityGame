# UnityGame
reacton time game

rules of the game - The rules of the game are simple. The user is prompted to enter how many trials they wish to complete.
Then, the game will show the target object, and then 6 objects. The user is prompted to hit the spacebar if and when they 
see the target object

how the project is organized - The project is organized simply. There are 6 prefab objects. They are spawned inside the script.
The one script is attached to the background game object because that is centered so any spawning objects are spawned right in
front of the camera. The project also uses Unity's new UI system which I have not used before until now, and it make organizing
the UI so much easier. 

how the code works - The code is pretty straightforward. There are a large amount of GameObject variables that are either
hooked up in Unity or found in the script. The Update function contains multiple states that are created with bools. 
Determining which state the game is in, different things will happen (which UI texts are being shown, which objects are being 
shown, wait periods). The code also uses the Time feature of Unity to make sure the waits are in seconds and not locked 
to the framerate. Each state doesn't progress until the timer is reached. 

how the scoring works - Scoring is determined by -10 points for a wrong guess, and up to 20 points minus your reaction time
scaled to a factor of 10. So, you can earn anywhere from 0 to 20 points depending on how fast you are. There is a 
performance text that is displayed at the end of the game based on how high your score is. 

interesting things - This was my first time using the new Unity UI and I think it makes the UI so much cleaner. 
