---
name: "Meta-Feature"
about: Track a multi-part gameplay or system feature composed of sub-features.
title: "[Feature] <System or Major Feature Name>"
labels: ["feature", "meta-feature"]
---

## 🎯 Overview

Describe the overall purpose and scope of this system.
Example:
> The Character Ability System defines how the player moves, attacks, dodges, and interacts with the environment.
> It must be flexible enough to support new abilities added later.

---

## 📦 Sub-Features

List individual issues that belong to this meta-feature.
Mark them as completed when the linked issue is closed.

- [ ] #<issue_number> – Sub-feature 1
- [ ] #<issue_number> – Sub-feature 2
- [ ] #<issue_number> – Sub-feature 3

(Add or remove as needed.)

---

## 🔗 Dependencies

List other meta-features or milestones that must be completed before this one.
Example: depends on `#12 [Feature] Inventory System`.

- [ ] #<issue_number> – Dependency 1
- [ ] #<issue_number> – Dependency 2

---

## 🧩 Integration Notes

Describe how this feature connects with others (data sharing, gameplay logic, asset dependencies, etc.).
Example:
> The Skill Grid System depends on Character Ability hooks to trigger player actions.

---

## 🧠 Research / References

(Optional) Include links to relevant docs, engine manuals, or design notes.

- [Design Doc](https://github.com/JerryAZR/RogueVaniaDocs)
- [CorgiEngine Reference](<link>)
- [Other Resources](<link>)

---

## 🗓️ Milestone

Which milestone does this meta-feature belong to?

> Example: `Milestone 1 – Core Systems`
