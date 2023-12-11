### **2023 Spring** - Bennet W
### *Assignment 0* - Assignment Name
Link to game: https://bennetwang.itch.io/intermediate-game-dev-assg-04


## **Debrief**
In at least 400 words, write a debrief. You must write a reflection on your assignment. In addition to specific requirements stated for the assignment, you must answer the following:

- What did you end up making?
- Which of the game’s aspects did you like about this project?
- What resources and/or comments were most helpful to you?
- What will you repeat or do differently next time?

- I made a pinball game that I don't even know how to play myself. Because it's so fast, how can I have such a fast reaction time, especially when the challenge is for the highest score, the reaction time is almost half of the normal speed.
- My theme is "too fast". What's too fast? Is it that the reaction time is short enough that the player can barely react, or that the ball will travel a long distance in a short time, or something else? Thinking about this theme is the second longest part I've spent on this project (the first is debug but I don't like it this time, why on earth would there be code that jumps to the next line without being executed in special cases huh).
- I thought of all sorts of things to implement the theme of "too fast". At first I thought of space. I almost made an astrophysics simulator (buggy), but that didn't really perform well on the theme of "too fast". Afterall I was just going for "fast" through the concept of "celestial bodies", but there was nothing in the gameplay. It doesn't really reflect the theme in the gameplay.
- I then tried increasing the mass or gravity attribute in the rigid body to see if it would provide a "too fast" feeling. Unfortunately, no amount of mass would do that, and too much gravity would make the pinball completely unplayable: the ball would fall almost vertically and not bounce around at all.
- So I thought, time. After all, time and speed are closely related (or maybe it's because I'm thinking of Made in Heaven from JoJo's Bizarre Adventure: Stone Ocean). But only time is definitely not enough, how to decide time scale to make the game more playable? I made a high score system, where as the player gets closer to the highest score, the time scale gets higher, and eventually goes beyond twice the speed and continues to rise: at that point there is practically no control over the ball at all.
- By the way, I added a trail renderer to help player be able to tracc the ball better.
- The most helpful, aside from Jack's code instructions, are the various anime I've read before. I have to say that the imagery in anime is very imaginative and expressive. Because of this, I need to think when I take inspiration from it: can this stuff really be realized through physical simulation?
- Or actually, the resource I get the most information is unity manual. I don't quite like some tutorials on youtube since they not often explain details of how codes work essentially, but user manual is always the most reliable and accurate resource.
- I'd probably consider asking Jack more questions, or consider seeking help from the code help desk next time. While there isn't much I can't do, they could save me a lot of time, and I don't seem to be very good at getting help from others.
- I shouldn't spend too much time on MANUAL next time. There were a few things that had really low relevance to the functions I was trying to implement.

## **Self Evaluation**
In addition to the debrief, the Self Evaluation is an opportunity for you to talk about your work. You must rate each aspect of your project as a 1 - 5 or Pass/Fail (where appropriate), as well as write a short 1-2 sentence elaboration to justify your score, in the following areas:


**Execution** (Did your project meet the theme you gave it?) - 5/5

*Too-fast. so fast I can't control myself, so fast that my code doesn't even execute properly!*


**Scope** (How well do you feel you scoped your game?) - 5/5


*I've basically gone through all the rigidbody2d docs and chose the solution that works best for me: the pinball is really better suited for AddForce with FroceMode2d.Impulse than a physical material.*


**Overall** - Pass


*Despite having issues I can't understand at all, presumably because I used time scale and I didn't design it visually, this game still fits the theme.*
