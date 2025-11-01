---
name: "Sub-Feature"
about: Implement a specific gameplay or system feature (e.g., Parry ability, Inventory UI).
title: "[Feature] <Sub-feature Name>"
labels: ["feature", "sub-feature"]
---

## 🎯 Overview

Briefly describe what this feature does and its gameplay/system purpose.
Example:
> Adds the **Parry** ability to the Character Ability system.
> The player can parry attacks within a short window to negate damage and trigger effects.

---

## 🔗 Related / Parent Issues

Link to parent meta-feature or other related systems.
Example:
> Parent: #12 [Feature] Character Ability System
> Related: #21 [Feature] Damage Handling

---

## ⚙️ Implementation Plan

Outline major development steps or stages.
(Use checkboxes so progress is visible.)

[ ] Design behavior and parameters.
[ ] Implement CorgiEngine integration.
[ ] Add VFX / SFX via `MMFeedbacks`.
[ ] Test interaction with dodge and damage.
[ ] Refactor shared code if needed.

---

## 🧩 Dependencies

List any issues that must be completed before starting this one.
Example: depends on #8 (Player State Handling).

[ ] #<issue_number> – Dependency 1
[ ] #<issue_number> – Dependency 2

---

## 🧠 Notes & Assumptions

Document any assumptions or temporary decisions that need future review.
Example:
> Currently assumes a fixed parry window duration (0.3s).
> Should be configurable later via data asset.

---

## 🧪 Testing / Validation

Define how to confirm that this feature works correctly.
Example:

[ ] Player can parry melee and ranged attacks.
[ ] Successful parry plays correct animation and feedback.
[ ] Parry cannot trigger during dodge or hit stun.

---

## ✅ Completion Criteria

When all items below are checked, this feature is considered complete.

[ ] Implementation done and reviewed.
[ ] All dependent systems verified to still work.
[ ] No known blocking bugs remain.
