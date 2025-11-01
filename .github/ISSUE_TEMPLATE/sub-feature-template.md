---
name: "Sub-Feature"
about: Implement a specific gameplay or system feature with clearly defined deliverables and test plan.
title: "[Feature] <Feature Name>"
labels: ["feature", "sub-feature"]
---

## 🎯 Overview

Describe what this feature is trying to achieve and its purpose.

Example:

> Implement the **Parry** ability for the player character. Successful parries cancel incoming damage and provide feedback.

---

## 📦 Deliverables / Requirements

List concrete items that must be implemented for the feature to be considered complete.
Each deliverable should be measurable or demonstrable.

Example:

- [ ] Parry ability triggers on correct input.
- [ ] Damage prevention works during the parry window.
- [ ] Feedback is displayed when parry is successful (log, particle, or `MMFeedback`).
- [ ] Demo scene created showing parry functionality.

---

## 🧪 Test / Validation Plan

Define how the feature will be validated or tested.

Link to a dedicated **Test Issue** that implements the test cases.

> Test Issue: #<issue_number>

- [ ] Verify player can parry melee attacks.
- [ ] Confirm damage is prevented during parry window.
- [ ] Feedback triggers on success.
- [ ] Edge cases: multiple consecutive attacks, attack timing at window edges.

**Note:** The feature issue can be closed once deliverables are done,
even if tests are incomplete. Test coverage will be assessed at the milestone
level.

---

## 🔗 Dependencies (Optional)

List any other features/issues that must be completed first.

Example:

- #12 [Feature] Character Ability Base
- #15 [Feature] Enemy Attack Behavior

---

## 📝 Notes (Optional)

Additional context, design decisions, or temporary assumptions.
Example:
> Parry window currently hard-coded to 0.3 seconds. Will revisit for tuning later.
