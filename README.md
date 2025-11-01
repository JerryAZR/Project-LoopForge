# Project LoopForge

**Project LoopForge** is a single-player prototype that explores a modular,
programmable skill system within a roguelike action framework.

Players construct their own abilities using **Trigger** and **Action** blocks,
forming reactive or active skill chains that define their combat style.

This system emphasizes creativity, experimentation, and the satisfaction of
building powerful loops - hence the name *LoopForge*.

While this version focuses purely on single-player gameplay and game loop
design, future iterations may evolve toward multiplayer support with new
architectural foundations. The current goal is to validate core mechanics,
pacing, and balance before expanding further.

---

## Why the name "LoopForge"?

The name reflects two key ideas behind the project:

- **Loop** - representing the interconnected trigger-action chains that define player skills.
- **Forge** - symbolizing the player's ability to craft and refine their own systems of combat and interaction.

Together, *LoopForge* stands for *forging loops of gameplay*, both mechanically and metaphorically.

---

## Related Documentation

See the [Development Guidelines](Docs/DevGuidelines.md) for
implementation-related notes.

Detailed design discussions, dev notes, and architecture documents are hosted separately:

- **Game Design Docs Repository:** [RogueVaniaDocs (GitHub)](https://github.com/JerryAZR/RogueVaniaDocs)
- **Online Docs Page:** [RogueVaniaDocs Website](https://jerryazr.github.io/RogueVaniaDocs/)

---

## Status

This is an early-stage prototype under active design and development.
Contributions are currently limited to internal collaborators.

---

## Git LFS (Large File Storage)

This project uses [Git LFS](https://git-lfs.com/) to manage large binary assets
(e.g., textures, models, audio files).

- You only need to install LFS once per machine:

```bash
git lfs install
```

- The project adopts a **lazy tracking policy** - non-text files are tracked via
LFS *only when necessary* (e.g., when GitHub warns about large file sizes).

If you clone this repository **without Git LFS**, large assets will appear as
small placeholder text files.
To fetch the actual files, simply install Git LFS and run:

```bash
git lfs pull
```
