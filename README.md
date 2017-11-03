# GOLF-SCORECARD

Either individually or in pairs: select an implementation language and produce a program which will generate a scorecard for a round of golf. 

In the interest of time, your program will accept input and produce output to the shell. A sample input is provided at the end of these instructions.

## Score System

There are three styles of scoring to chose from. The most basic and straightforward is *Stroke play*. *Stableford* is a points based game and *Match play* is similar to scoring in Tennis.

### Your program should implement Stroke play.

## How to score Stroke play

The particular course you play on determines the difficulty of the round. Each hole on the course is given a number that defines the number of strokes that a scratch-player would take to complete the hole, called "par" (even). The player's job is to complete the hole in a number of strokes less than or equal to the rating. 

The goal in stroke play is to have the smallest number at the end of a round.

Golf has a vocabulary to describe the performance of the player for a hole, as follows:

| Score | Golf-term | Definition              |
|-------|-----------|-------------------------|
| Par-4 | Condor    | Four strokes under par  |
| Par-3 | Albatross | Three strokes under par |
| Par-2 | Eagle     | Two stringers under par |
| Par-1 | Birdie    | One stroke under par    |
| Par   | Par       | Even; equal to par      |
| Par+1 | Bogey     | One stroke over par     |
| Par+2 | Double    | Two strokes over par    |
| Par+3 | Triple    | Three strokes over par  |

Note that if there is not a name for the score on a hole, then the value is the number of strokes; e.g., +4 on a Par 5 is 9-strokes to complete the hole.

### Here is an example of scoring stroke play in the language of the user:

Hole 7 is as Par 5. Joe got a birdie and Bill shot a Double. At Hole 8 (Par 3), Joe shot a bogey and Bill shot Par.

Who is ahead?

Joe's scores: (Par5,-1) + (Par3,+1) = 8 strokes

Bill's score: (Par5,+2) + (Par3,0) = 10 strokes

So, Joe is ahead.

## Sample input to verify your program with

Let's say that our users have a scanner that converts paper score cards into a list of tuples in this format:

{
	"player_name": [(Par#,Stroke#),(Par#,Stroke#)],
	"player2_name": [(Par#,Stroke#),(Par#,Stroke#)]
}

Here's one round of golf for Joe and Bill:
{
	"Joe Hatestacos": [("Par3","Bogey"),("Par4","Par"),("Par3","Par"),("Par5","Double"),("Par3","Bogey"),("Par3","Par"),("Par4","Bogey"),("Par5","Birdie"),("Par3","Birdie")],
	"Bill Banker": [("Par3","Bogey"),("Par4","Bogey"),("Par3","Double"),("Par5","Triple"),("Par3","Double"),("Par3","Bogey"),("Par4","Double"),("Par5","+4),("Par3","Bogey")]
}

Given this input, your program should produce an individual score for each player and determine the winner of the round. Your output should be human readable.

## How to submit an answer

Create a branch with your team name and ask us to pull in class.
