# <p align="center">UniDef</p>

<p align="center">UniDef is an open-source android game that you can tailor to your own liking. Have fun :)</p>

v0.08:
--------

- Enemy spawns a text that has an animation on it. The text animation triggers a function that destroys it after it's completed.
- Damage upgrade has a new function for calculating damage

v0.07:
--------

- New script: ContainerScript
- New prefabs: 2,3,4,5 drones to spawn at once
- Level system added to main gameplay
- Level is saved in the savefile
- Spawning system
- The main gameplay is now basicly endless (need to restart app for the next level)(will fix soon)

v0.06:
--------

- Added free asset for buttons (will remove later)
- Added 10 levels to upgrades, for testing. Everything works fine, will remove switch case and make a proper function to handle upgrades
- Added a gun sprite

v0.05:
--------

- Added script: Upgrade manager
- Added upgrade system
- Upgrade levels added to savefile
- Tweaked scripts to work with the upgrade system
- Upgrade system implemented, just needs some expansion and variety

v0.04:
--------

- Added scripts: Wall, DataHolder
- Added a wall, that has health and can be damaged by enemies
- High score is now saved on the device using C# binary formatter, but not yet displayed on the UI
- Script preparations for an upgrade system

v0.03:
--------

- Bugfix for laser control
- Added enemy spawning added every 5 sec for now
- Added save system created (device only)
- Added score system
- Added enemy script
- Fix for falling objects (not falling anymore, movement only by velocity)
- Changed when the "laser" object needs to be destroyed (screen width/height * 1.1)
- CanvasManager now starts the gameplay when you tap the "play" button in the main menu
- Changed the way triggers work on "laser" and "enemyDrone"

v0.02:
--------

- Added prefabs: enemy drone, laser
- Added scripts: gameplay manager, laser, player script

v0.01:
--------

- Added background texture
- Added enemy drone texture
- Added canvas manager script
