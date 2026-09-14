# Development history

## Starting point

This project began as a college Digital Game Engines assignment: a first-person 3D zombie shooter built in Unity. The original design goal was to explore a game that could work with keyboard and mouse, gamepad, and potentially Oculus Rift hardware.

The project evolved through frequent playable snapshots. Early work included JavaScript tutorial scripts, which were gradually replaced with C# as the game systems became more complex.

## Major changes

- Built the first-person controller, shooting range, security building, zombies, and basic objectives.
- Replaced older JavaScript gameplay scripts with C# equivalents.
- Added the Game Controller and HUD prefab so score, ammo, objectives, health, and zombie counts could be reused across scenes.
- Split the underground journey into separate passageway and laboratory sections as the level design grew.
- Added NavMesh-driven zombie spawning and movement for Levels 2 and 3.
- Added chainsaw and crowbar weapons, headshots, blood effects, animated objectives, and score feedback.
- Added 3D audio, a persistent music manager, wall speakers, and shootable music controls.
- Added optional Oculus Rift and world-space UI experiments.

## The final structure

The final game is divided into three locations:

1. **Level 1:** security building, shooting range, storage room, and dormitory.
2. **Level 2:** underground passageways leading toward the laboratory.
3. **Level 3:** great hall, laboratory entrance, and the rescue sequence.

The repository preserves the original development timeline separately from the modern WebGL test work. This keeps the historical project state available while allowing later compatibility experiments to live on branches.
