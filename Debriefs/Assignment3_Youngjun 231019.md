### **2023 Spring** - Youngjun Lee
### *Assignment 3* - Main Menu
Link to game: https://yl9929.itch.io/eyes-without-a-face


## **Debrief**
Here is where I would write my 400 word debrief. Within my debrief, I make sure to answer all the required questions.

For this assignment, the goal was to make a main menu for a fake game, more explicitly, making UI. 
When we making UIs, the common cliche is taking Persona 5 as a reference. 
"Though, anyone who thinks UI has to look boring has obviously never played Persona 5" (GMTK). 
Luckily, I could choose "cliche" as the theme of this project. 
At the same time, did not want to make this project a single use. 
Thus, I used the source from my Intermediate Game Design assignment. 
"Eyes Without a Face" was a horror movie that I had to remake into a game. 
First, I thought that the iconic color of black, white, and red from Persona 5 could be used for emphasizing the scary atmosphere. 
My design is also based on black and white, but with an emphasis on red, especially in the scary parts, to make it more scary than cool. 
Second, I watched the transition animation of Persona 5's menu and I found that the UI and animations around it would change to match the rotation of a vertical line in the center of the screen, and eventually, when the line rotated a full 360 degrees, a new menu would appear. 
So I added the vertical line by the texts, slightly curve it to make it look like the string from the phone the woman's holding. 
When the player clicks "options" button, the vertical line rotates and changes the woman's appearance. 
After that, the line pushes the woman to the right corner to leave a space for the new menu. 
All the rotating animations were created by hand, but it looked as intended. 

For the main functions, there are five interactive buttons on the screen: continue, new game, options, quit, and a small icon in the top right corner. 
The continue button will show the error window. 
Clicking the new game button shows a screenshot (or concept art) of the game. 
The options button is everything I mentioned earlier. 
The option menu includes resolution dropdown, full screen button, and volume slider. 
Resolution dropdown includes all the 16:9 resolutions up to the player's current screen. 
The Quit button will end the game. 
The icon is my personal logo created in the Visual Communicaiton class. 
It shows my name when the player click it. 
(This assignment is combination of three different classes!)

There were some problems during development. 
The resolution dropdown was the most buggy one. 
I recreated it several times until it worked as intended. 
Moreover, it didn't work at all when I first uploaded to itch.io. 
It was very weird since it worked fine on the unity editor. 
After some debugging, I found that the problem was the code that detects current screen resolution. 
Because it couldn't detect WebGL's current resolution so everything was blank. 
So I manually added some resolution on top of that. 
However, after all, the resolution dropdown didn't affect the resolution of the screen, which made me frustrated. 
All the projects I published on itch.io has the resolution problem, so I'm urge to fix them. 

## **Self Evaluation**

**Execution** (Did your project meet the theme you gave it?) - 4/5

*My elaboration*
One of my friend, Alex, immediately call the name of Persona 5 when he saw my project, so I thought it met the theme of cliche, but Jocelyn points that she didn't saw the reference from the game. 
Perhaps I need to make it more obvious or use some iconic animations from the game. 


**Scope** (How well do you feel you scoped your game?) - 4/5

*My elaboration*
Despite some functions not working, the main menu was created as intended. 


**Overall** - Pass
