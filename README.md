# Hexagonal Chess Online

Hexagonal Chess on ASP.NET Core 2.2

Play now at https://HexagonalChess.Online/

To see pieces, click **Settings**, and think up a game ID or get one your 2 friends want to use. 

To play two-player, first set yourself as a third color and remove their pieces to limbo spots.

During your turn, you can move pieces around. If you want to reset to the start of your turn,
click **Oops**. When you've made your move, click **That's mahmove**.

## Game Rules

To win, cause a checkmate that stands when the 
target's turn begins, or get your king down the center spot.

Click any piece to see spots that can be impacted by any of its moves.

When the king and queen are touching, they can start a turn with an optional position swap.
This looks odd at first, as they appear in red. It means they could optionally swap.
It also means the queen may appear to reach an enormous number of spots. 
The queen can, after the optional spot swap with the king. 

## Quirks you must deal with until I fix them

You can move your pieces anywhere at any time. Don't do it during other player turns.

It's up to you to assure the turn you choose is valid.

To attack a piece, ask your opponent to remove it from the board.

To swap king and queen, move one piece to a neutral spot first.

The "waiting for white to move" detail is probably wrong. You just have to know it's your turn, perhaps because your opponent told you.

## Differences from meatspace rules

You can play the same game as you might play face-to-face, because the Possible Move Indicators are not _enforced_.

You can't add pieces (such as two-queen in the Olympia variant, or extra pawns in limbo as a handicap).

The Possible Move Indicator doesn't show special pawn configurations (mob or acrobat). 

Reaching the opposite side of the board with a pawn has no special outcome.

A piece can kamakazi an opponent piece in the portal, both pieces go into limbo, but a regeneration could result for the attacker color. Not sure if this differs from typical meatspace rules. We just prefer this approach.

# Join us

This code has been prepared by the Git Blox Bois. We welcome new players and contributors. 
This repository contains the server code. You can also see the browser code here:
https://github.com/oinke/hexchess-www

The Git Blox Bois are an international anarchist hacker collective that opposes the patriarchy
and encourages gender and sexual minorities to contribute and play. You might find us here:
https://hangouts.google.com/group/wxGfxZPxbj2pOy0M2
