# BowlingGameApplication

--------------------------------------------------------------------------------------------------------
Requirements:
--------------------------------------------------------------------------------------------------------
Write a C# console application that takes a regular 10 frame bowling game and spits out the final score.

Use ‘/’ for spares.       <<I also added ‘x’ to indicate strikes.>>

Prompt me so that I may write in another game after each game or an 
option to close out of the application after I viewed my score(s).

--------------------------------------------------------------------------------------------------------
Approach:
--------------------------------------------------------------------------------------------------------
I wasn't sure exactly how scoring for bowing worked at first so I had spend some time researching that.

Once feeling comfortable I was excited to find that there is a Bowling Kata for TDD sharpening.
Rather than jump right in I decided to  work through the excercise a few times till I felt comfortbale
with the features. The resoures on youtube were very helpfull with navigating the IDE and utalizing 
the built in testing tools. 

Prior to this, I would write test modules, but I had to fully compile to run them. This certainly changes
how I am writing code from now on.

--------------------------------------------------------------------------------------------------------
Challanges:
--------------------------------------------------------------------------------------------------------
The console application program was my primary challange as I decided to code this part with little to
no references.

"Hindsight is 20/20"

 I feel that I made some odd choices with the design of this.
 the worst one in my opinion was that when I was building my validation loop to check if the user input
 made sense, I ended up writing it with a while loop that would not breakout untill I finished getting 
 all the frame scores. This caused forced redundancy, as I needed to write a sub validation for each 
 case, rather than just calling a function.
 
 

 
