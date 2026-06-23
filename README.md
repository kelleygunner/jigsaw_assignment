# Jigsawgram Test Task

## Overview

This repository contains the implementation of the Level Start Dialog architecture for a Jigsaw-style puzzle game.

The goal of the task was to demonstrate:

* UI architecture approach;
* MVP pattern usage;
* Dependency Injection setup;
* Extensibility points for future gameplay implementation;
* Code organization suitable for further project growth.

The current implementation focuses on the **Level Start Screen** and does not include full gameplay implementation.

---

## Unity Version

Unity 6.x

---

## Project Launch

Open the project in Unity and load the scene:

```
Assets/Game/Scenes/Main.unity
```

Press Play.

The application starts from the Bootstrap scene and opens the Home Screen.

---

## User Flow

```
Home Screen
    ↓
Level Start Screen
    ↓
(Free Start / Coins / Rewarded Ad)
```

Current implementation contains:

* Home Screen
* Level Start Screen
* Navigation between screens
* Difficulty selection
* Preview image display

Gameplay launch is intentionally left as an extension point because it is outside the scope of the test task.

---

## Project Structure

### Infrastructure

Contains low-level systems and integrations.

```
Infrastructure
├── AssetManagement
├── RemoteData
├── TextureUtilities
└── DataStorageSystem
```

Examples:

* Asset loading
* Remote content loading
* Texture helpers
* Save system

---

### Gameplay

Contains gameplay-related logic and future gameplay implementation.

```
Gameplay
├── Application
├── Contracts
├── Domain
├── Presentation
└── Composition
```

#### Application

Gameplay orchestration and use cases.

Examples:

* GameRoundController
* PuzzleGenerator
* Gameplay Flow Services

#### Contracts

Contracts used for communication with gameplay layer.

Examples:

* IStartLevelCommand

#### Domain

Core puzzle game logic.

Examples:

* PuzzleItem
* Tray
* Table
* TurnValidationRule
* PuzzleItemUvCalculator

#### Presentation

Gameplay-specific presentation logic.

Examples:

* InputController

#### Composition

Gameplay lifetime registration and installers.

Examples:

* GameplayInstaller

---

### Features

UI features organized by screens.

```
Features
├── HomeScreen
├── LevelStartScreen
├── GameScreen
└── SettingsScreen
```

Each feature follows MVP:

```
Feature
├── View
├── Presenter
└── Model
```

---

## Architecture

The project uses MVP:

```
View
 ↓
Presenter
 ↓
Model
```

Responsibilities:

### View

* Unity UI
* User input forwarding
* Visual updates

### Presenter

* UI coordination
* View subscriptions
* Model updates

### Model

* Feature state
* Business interaction
* Navigation requests

---

## Dependency Injection

Dependency Injection is used to:

* register services;
* isolate dependencies;
* simplify testing;
* support future project growth.

Composition Root is located in Bootstrap.

---

## Future Extensions

The architecture is prepared for future implementation of:

* Puzzle Gameplay
* Progress Saving
* Rewarded Ads
* Coin Economy
* Level Flow
* Remote Content Updates
* Analytics
* LiveOps Content

---

## Notes

The current repository represents the first iteration of the architecture and intentionally focuses on code organization, extensibility and maintainability rather than full gameplay implementation.
