# 🧭 Development Guidelines

## 📁 Project Structure

* Follow the existing Unity project layout.
* Unity references assets by internal IDs, so moving or renaming files later is safe.
* Avoid deep folder nesting or redundant categories until the structure stabilizes.

## 🧱 File and Directory Naming

* Use **PascalCase** for all files and directories.
* Use underscores `_` for additional separation if needed (e.g. `EnemyAI_Boss.prefab`).
* Keep naming consistent with existing files.

## 💻 Coding and Dev Style

* Use the formatter/linter built into your IDE (Visual Studio, Rider, or VS Code).
* Follow automatic formatting - no need to manually enforce syntax style.
* **Soft rules** (prefer clarity over strictness):

  * Keep lines ≤ **80 characters** where practical.
  * Keep functions ≤ **50 lines**.
  * Prefer readability and clear structure over micro-optimizations.

---

## 🏷️ Code Annotations & TODO Labels

Use clear, consistent comment labels so that anyone can search for and track
incomplete or revisit-required parts of the project.

* `// TODO:` A missing or partially implemented feature that must be completed.
* `// FIXME:` A known **bug** that must be fixed later.
* `// TEMP:`  A **temporary workaround** or early-stage assumption that will
  need revision.
* `// OPTIMIZE:` Code that works but could be **optimized** later.
* `// REVIEW:` Code or logic that requires **design or team review** before
  finalizing.

### Notes

* Always include a short explanation after each tag — no bare TODOs.
* Group related tags under a consistent header (e.g., at the start of a function).

---

## 🧩 Recommended VS Code Extensions

To maintain a consistent workflow across the team, we recommend the following VS Code extensions:

* **[C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)**
  Official Microsoft extension for C# development. Provides IntelliSense,
  debugging, and Unity integration.

* **[Code Spell Checker](https://marketplace.visualstudio.com/items?itemName=streetsidesoftware.code-spell-checker)**
  Highlights typos in comments, strings, and documentation. Helps keep commit
  messages and code comments clean.

* **[TODO Tree](https://marketplace.visualstudio.com/items?itemName=Gruntfuggly.todo-tree)**
  Displays all `TODO`, `FIXME`, `TEMP`, etc. comments in a sidebar tree.
  Integrates perfectly with our annotation conventions.

* **[GitLens](https://marketplace.visualstudio.com/items?itemName=eamodio.gitlens)**
  Enhances Git integration: view commit history, inline blame, and author
  insights directly within the editor.

Feel free to use your preferred alternatives or suggest new ones.
