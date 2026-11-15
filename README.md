# C# Console Turn-Based RPG (v1.0)

A modular, text-based turn-based RPG built in C# (.NET) featuring tactical combat, magic spells, leveling progression, and persistent JSON save states.

## Features
* **Turn-Based Combat System:** Attack, defend, cast spells, or rest to recover HP and MP.
* **Magic & Mana System:** Unlockable spells (Fireball, Ice Bolt, Heal, Lightning Strike, etc.) with MP cost validation and health clamping.
* **Progression & Enemies:** Gain XP, level up stats, and fight cloned enemy templates with critical hit mechanics.
* **Persistent Save System:** Automatically saves and loads player stats and enemy data using JSON serialization (`System.Text.Json`).

## Architecture
The codebase is structured using Separation of Concerns across three core modules:
* `Program.cs` — Main game loop, combat flow, and user input validation (`TryParse`).
* `Functions.cs` — Core gameplay mechanics (`PlayerAttack`, `EnemyAttack`, `Defence`, `Rest`, `LevelUp`, and spell casting).
* `Storage.cs` — Data models (`Player`, `Enemy`, `Spell`) and JSON file persistence.

## Tech Stack
* **Language:** C# (.NET)
* **Data Storage:** JSON (`System.Text.Json`)
* **Concepts:** Object-Oriented Programming (OOP), Dictionaries & Lists, Object Cloning, Input Validation.

## How to Run
1. Clone or download this repository.
2. Open the project folder in **Visual Studio** or **VS Code**.
3. Run the application via the IDE or execute `dotnet run` in the terminal.
