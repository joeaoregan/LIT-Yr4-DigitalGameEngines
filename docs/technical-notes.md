# Technical notes

## Scenes

The build is organised around these scenes:

```text
Intro -> EnterName -> Menu -> Level1 -> Level2 -> Level3 -> Scores
```

The gameplay scripts now prefer scene names for progression, which is more robust when testing a reduced WebGL scene list than the original fixed build-index assumptions.

## Main systems

- `GameController` coordinates ammo, score, objectives, persistence, targets, zombies, and pause state.
- `ManageObjectives` tracks objective flags and updates the HUD.
- `ZombieSpawner` creates zombies at configured spawn points.
- `ZombieMovement` uses `NavMeshAgent` to follow the player.
- `ZombieHealth` handles damage, blood effects, death, score, and kill counts.
- `PlayerPrefs` carries score, ammo, health, zombie counts, and player name between scenes.
- Audio clips and music are controlled through Unity audio sources, mixers, and persistent music objects.

## Build considerations

The original project targeted PC and includes older Unity Standard Assets. WebGL builds require additional testing because browser pointer lock, right-click, audio loading, memory allocation, old shaders, and NavMesh layout behave differently from the desktop editor.

For the WebGL test branch, `E` is the reliable interaction key. The browser build should be rebuilt into a fresh output folder after script or project-setting changes.

## Known limitations

- Unity 2017-era project settings can produce shader and HID warnings in modern editors.
- Lighting may differ between the original editor and WebGL because lightmap data and shader support are reimported.
- The original scenes contain old, hand-authored NavMesh and spawn-point layouts.
- The project is single-player; multiplayer was considered but not implemented.
