PLAY GAME

The "Bullet Hell - Current Build" folder contains the current build for the game and is all that is needed to run the game. 
The game is run by opening the "BulletHell_CPTS587.exe" file from the "Bullet Hell - Current Build" folder. 
Please note all necessary modules, including the latest version of Monogame, must be installed. 


GAMEPLAY

Currently only character movement is implemented.
The bosses are very condensed (the preview is not meant to be the full 4 minutes in length). 
All ship types are represented in the playthrough (grunts A and B, mid boss, final boss).
Use the arrow keys to move Up, Down, Left, and Right. Combinations of arrow keys can be used to move diagonally. 
Use the Escape key to exit the game. 
The Tab key will cycle between normal and slow movement speeds for the player ship. 


SOURCE CODE

Source code for the game can be accessed by opening "BulletHell_CPTS587.sln" using Visual Studio 2022 or a similar program. 


KNOWN ISSUE:
No known bugs, however in some cases the project will not run due to the following error: 
"error NETSDK1004: Assets file 'project.assets.json' not found. Run a NuGet package restore to generate this file."

This error is encountered due to Windows protecting a file when it is downloaded directly from Git. 
This is a Windows security issue and not a bug in the program. 
To Fix:
Navigate to the ".config" folder.
Right-click on the "dotnet-tools.json" file.
Select "Properties" from the menu.
Navigate to the "General" tab. 
At the bottom of the "General" tab, check the "Unblock" checkbox.
Click the "Apply" button. 

A screenshot of the above menu can be found saved in the file "Windows Security Fix.png"

Another issue we have is loading the SpriteFont(content.Load<SpriteFont>). Even if we have the sprit font in the content folder (Arial.spritefont),
program not able to load it properly. To fix this:
1. Double click Content.mgcb from the contnet folder
2. Add new item and give it a unique fileName
3. Choose SpriteFont Description (.spriteFOnt)
4. Hit Create and save it
5. Copy the fileName and update the file name in Arial = content.Load<SpriteFont>("fileName"); (Code line #111 in Game1.cs class)
