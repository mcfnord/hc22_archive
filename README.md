# Hexagonal Chess Online

Hexagonal Chess on ASP.NET Core 2.2

Play now at https://HexagonalChess.Online/

To see pieces, click *Settings*, and think up a game ID or get one your 2 friends want to use. 

To play two-player, set yourself as a third color and remove their pieces to limbo spots.

You can move your pieces all over at any time. Don't do it during other player turns.
During your turn, you can move pieces around. If you want to reset to the start of your turn,
click *Oops*. When you've made your move, click *That's mahmove*.

## Quirks you must deal with until I fix them

To attack a piece, ask your opponent to remove it from the board.

To swap king and queen, move one piece to a neutral spot first.

The "waiting for white to move" detail is probably wrong. You just have to know it's your turn, perhaps because your opponent told you.

## Game Rules

Click any piece to see spots that can be impacted by any of its moves.

It's up to you to assure the turn you choose is valid.

To win, checkmate an opponent, or get your king down the center spot.

If you capture

When the king and queen are touching, they can start a turn with an optional position swap.
This looks odd at first, as they appear in red. It means they could optionally swap.
It also means the queen may appear to reach an enormous number of spots. 
The queen can, after the optional spot swap with the king. 

## Differences from meatspace rules

You can play the same game as you might play face-to-face, because the Possible Move Indicators are not _enforced_.

You can't add pieces (such as two-queen in the Olympia variant, or extra pawns in limbo as a handicap).

The Possible Move Indicator doesn't show special pawn configurations (mob or acrobat). 

Reaching the opposite side of the board with a pawn has no special outcome.

A piece can kamakazi an opponent piece in the portal, both pieces go into limbo, but a regeneration could result for the attacker color. Not sure if this differs from typical meatspace rules.

# Join us

This code has been prepared by the Git Blox Bois. We welcome new players and contributors. 
This repository contains the server code. You can also see the browser code here:
https://github.com/oinke/hexchess-www

The Git Blox Bois are an international anarchist hacker collective that opposes the patriarchy
and encourages gender and sexual minorities to contribute and play.
