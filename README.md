# GE2_Assignment
Assignment for Games Engines 2 Module created in Unity. Inspired by the Metroid Series

## Space Battles:
This assignment will consist of various scenes and battles inspired by the Metroid video game series. It will be developed in Unity and all battles will take place between ships with autonomous behaviours.

---

## Inspiration:
The inspiration for this assignment comes from the Metroid series of video games. One battle that will occur will be between the heroine Samus Aran who will encounter the G.F.S Tyr, a Galactic Federation command ship that has been overrun by the possessed members of its former crew.
The second battle will be between Samus and Space Pirates while she is in pursuit of their leader Ridley.

The storyboards for this assignment can be found here: https://imgur.com/a/EegkQBB

---

## Story:
The story begins with bounty hunter Samus Aran escaping the Orpheon. The Orpheon is a Space Pirate frigate ship which had sent out a distress signal which Samus recieved. Upon investigating the ship, Samus was attacked by Ridley, her arch enemy and leader of the Space Pirates. 

Samus' escape leads her to head towards the planet Phendrana to hunt down Ridley. Along her journey, Samus encounters the G.F.S Tyr, a previously allied ship that has become hostile as a result of its former crew becoming possessed. Samus is forced to disable the ship's engines in order to prevent the crew from potentially doing any damage to the Galactic Federation. 

Samus encounters a group of space pirates upon apparoaching Phendrana who attack her on sight. She is forced to battle these pirates in order to reach her goal of bringing Ridley to justice. 

---

## Technical Description
For the EscapeStation scene, a simple script called FleeHangar was created that navigates Samus' ship to a designated waypoint away from the station. This code was based on the Flee script that has been previously shown in class. While Samus flies away from the SpaceStation, it was intended to cause the station to explode as it was destroyed. This was omitted due to difficulties with getting the explosion pack that was utilised for the assignment to work correctly. 

For the scene AttackPossessedShip, a custom finite State machine was utilised for handling the movement of Samus' ship along a predetermined path, changing states when her ship comes in close proximity with a target that must be attacked. This code can be found in the PlayerState script. This script has limitations such as a lack of ship banking. This script was written by myself using this video as a reference:  https://youtu.be/YdERlPfwUb0

For the SpaceBattle scene, a finite state machine was utilised to handle to behaviours of both Samus and the attacking pirate ships. This finite state machine was based on the code that was created in class with some modifications. These modifications were made to faciliate an extra behaviour that was intended to allow for conditions to be met which would end the scene. This did not work fully as intended due to bugs. 

It was intended to include trail renderers for the ships along with explosions for when objects were destroyed in this assignment however these features were omitted due to time constraints and difficulties implementing the feature respectively. 

Scripts for handling scene transitions and ui elements were also created by myself. 

---

## Credits:
Space Pirate Ships: https://assetstore.unity.com/packages/3d/vehicles/space/free-sf-fighter-11711

Explosion Assets: https://assetstore.unity.com/packages/vfx/particles/fire-explosions/fx-explosion-pack-30102

Samus Gunship: "Gunship Metroid" (https://skfb.ly/6WQUM) by TNTPredarno is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

G.F.S. Tyr: https://3dwarehouse.sketchup.com/model/24211ad0-bae4-4745-8e90-e5834ef5202d/GFS-Tyr-Metroid

Frigate Orpheon: "00 Exterior Docking Hangar" (https://skfb.ly/6XIwS) by kwstasg is licensed under Creative Commons Attribution-NonCommercial (http://creativecommons.org/licenses/by-nc/4.0/).

---

Video:

[![Game Engines 2 Assignment](http://img.youtube.com/vi/k79-v8o0gBo/0.jpg)](https://www.youtube.com/embed/k79-v8o0gBo)
