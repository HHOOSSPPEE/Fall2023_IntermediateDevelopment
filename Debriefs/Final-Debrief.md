### **2023 Spring** - Randy M
### *Assignment 6* - Untitled
Link to game: https://drive.google.com/file/d/1ZEBeMo3rfH8gw04v33WfBOftJUeFGIqg/view?usp=drive_link (Itch page is not up yet)



## **Debrief**
Here is where I would write my 400 word debrief. Within my debrief, I make sure to answer all the required questions.

A game where you have to get to the button before time runs out.
WASD or Arrow Keys-Movement
SPACEBAR- Travel Ability

I thought my final game was easy; that is for my first glance at the game I aimed to copy, everything seemed simple and feasible. Practical and within the scope of two weeks even. However, that thought quickly came to a halt.  A week in and all I achieved was player movements. And even that was a little janky.  

The player movement held one basic rule: while on the move, you can not switch directions until collision with a wall. Simple right? In its inception, a few simple lines of code should have done the trick but a week was spent on debugging alone. There was an occurring issue of friction on the players collision against wall tiles, which at times hindered keyboard inputs. I would press LEFT and still remain in the same position. Try as I may, I could not understand why. As far as I could tell, the scenes were set up correctly and the code was right. Jack’s verification was an indication. The one motivation for my assurance in the scenes correctness however, were the GameObject sustaining themselves; that is they all contained required attachments to make my scripts work: rigid body2D, box collider 2D, raycasts, “low friction” physics material... I had it all. Least to my expectations however, my game needed one less; a box collider. 

You see, the player's box collider's position would change slightly every time the player moved. I often checked my scene’s while playtesting, but this bug fooled me. I was offered many solutions, some of which urged me to rewrite my code from scratch. In fear of this one advice specifically, I thought hard for one minute and hold and behold, the answer to my week-long trouble was a circle collider2D.

Now to complicate matters a little further, I needed to implement my theme of “travel” in this game to make it my own. Before the game’s conception, I had an idea of breaking the laws and physics in movement with a special travel button. Whereas the game movements would normally remain rigid, this button would be loose and more free. The idea here was this: If the game did not allow for quick directional change ups, this button would. On key press, it would launch a slow motion sequence allowing the player to discern where they wanted to go. Now this ability did not come cheap. Whenever you pressed it, you lost more time than you normally would- a nice punitive effect for disrupting the original games flow. 
 
The game I took up was lovely at its core. All you had to do was get to a button before time ran out. That's it. There were no obstacles with an intent and purpose of chasing and stopping you, just time and I loved that my implementation did not take away from that.



## **Self Evaluation**

**Execution** (Did your project meet the theme you gave it?) - 5

*5. Yes my project met theme of travel. *


**Scope** (How well do you feel you scoped your game?) - 4


*5. The game was completed within the scope of 2 weeks. Although things felt dire in the first*


**Overall** - Pass


*5: All guidelines for the project was met. If all guidelines for the project was met then the assignment passes.*
