### **2023 Spring** - Bennet W
### *Assignment 0* - Assignment Name
Link to game: https://bennetwang.itch.io/interm-gd-assg-1


## **Debrief**
In at least 400 words, write a debrief. You must write a reflection on your assignment. In addition to specific requirements stated for the assignment, you must answer the following:

- What did you end up making?
- Which of the game’s aspects did you like about this project?
- What resources and/or comments were most helpful to you?
- What will you repeat or do differently next time?

- What I ended up making was basically a testing ground for the code. I seemed to put too much emphasis on implementing the mechanics at the expense of the theme. While I think I got it right on the code level, there are undoubtedly major flaws in the game design.
- I like the two mechanics that caused me pain and struggle: "Memory" and "Hunger". Memory reminds me of a mage and hunger reminds me of a vampire. Hey, how about being a vampire mage? So I went so far as to make the vampire's ability to turn into bats, rats, and other animals into a spell. In the game, you can release a spell to change into a bat and gain the ability to fly, and use it to overcome some things you can't do in human form. Meanwhile, vampires have to suck blood, of course, but the act of sucking blood requires the cooperation of both the player and the enemy to accomplish. This was kind of a challenge. I couldn't have the enemy hanging in mid-air after the player had finished sucking blood (what's not to do if the player is a mage anyway), so I introduced an event system and a bunch of cotroutines, and added a SetTrigger method in the script to call the animator's trigger to synchronize the player's and the enemy's actions.
- The fact that this project forces the implementation of the mechanism is kind of good and kind of bad. I really, really regret not picking two mechanisms that could have been combined better, and it's actually the combination of them and the theme that really gives me a headache. the theme always needs some narrative or visual design. Going back to the mechanics, I just noticed that it seems like my classmates always prefer to work on the visuals and go for simpler code implementations, and this project actually requires a higher level of code implementation than the previous four assignments.
- I feel that my code could have been simpler and that the system was not unnecessarily complex. Because it seems that I always overscope and cause serious progress management problems. At the same time, I was working on a solo project anyway, and a lot of the effort for readability didn't feel necessary to me. After all, this is only a two-week project, and I work on it almost every day, and I have a naming scheme that I think I'm still pretty good at. This line of thinking might help me with my final project, after all, I only have two weeks of events on my final project as well (though the good news is that the tool class I got can actually stay with me all the time).
- Jack once made the point that I don't have to spend too much effort on visuals. "It looks like shit but it works." This point was helpful, but I suspect I was overly influenced by it on this project. My visuals really are like shit . All the various things I had prepared for the visual realization didn't actually work, which made me feel like I didn't actually have much ability to manage progress. Maybe I should really plan everything out next time before I actually start working on it next time, and seriously consider the necessity of any behavior that adds workload midway through the process.
- MOST IMPORTANTLY, I really should learn progress management.

## **Self Evaluation**
In addition to the debrief, the Self Evaluation is an opportunity for you to talk about your work. You must rate each aspect of your project as a 1 - 5 or Pass/Fail (where appropriate), as well as write a short 1-2 sentence elaboration to justify your score, in the following areas:


**Execution** (Did your project meet the theme you gave it?) - 2/5

*I seems more emphasize on the mechanic.*


**Scope** (How well do you feel you scoped your game?) - 5/5


*Really scoped, over-scoped I believe.*


**Overall** - Pass


*Mechanics are implemented. Looks like shit but it works.*
