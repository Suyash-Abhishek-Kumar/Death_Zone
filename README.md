# Death Zone

## 3D First-Person Shooter Prototype

**C# · Unity · Unity Physics · NavMesh · Raycasting**

Death Zone is a 3D first-person shooter prototype developed as part of a college game-development project. I served as the **primary developer** on an 8–9 member multidisciplinary team, working alongside artists and designers. After the team's second developer became unavailable, I took ownership of the game's core programming and implemented the major gameplay systems.

## 🎮 Overview

Death Zone focuses on first-person movement, combat, enemy behavior, and physics-driven gameplay in a 3D environment.

### Core Systems

- **Player Movement**
  - Walking and sprinting
  - Crouching and jumping
  - Air control
  - Velocity constraints
  - Slope-aware movement

- **Enemy AI**
  - Unity NavMesh-based navigation
  - Patrol behavior
  - Player detection
  - Pursuit/chase behavior
  - Ranged attacks

- **Combat & Gameplay**
  - Projectile system
  - Raycasting
  - Health and damage systems
  - Gameplay state logic
  - Reusable prefabs and components

## 🧠 Technical Highlights

### Physics-Based Movement

The player controller uses Unity's physics system to handle movement and momentum. Movement includes sprinting, crouching, jumping, air control, velocity constraints, and handling movement across sloped surfaces.

### Enemy Navigation & AI

Enemy movement is built around Unity's **NavMesh** system. Enemies can patrol the environment, detect the player, pursue them, and transition into ranged attacks based on gameplay state.

### Combat Systems

Combat combines Unity physics and **raycasting** with reusable projectile, health, and damage components. Separating these systems makes them easier to reuse and tune across gameplay objects.

## 👥 Team & My Contribution

The project was developed by an **8 member multidisciplinary team** consisting primarily of programmers, artists, and designers.

## 🛠 Built With

- **Unity**
- **C#**
- Unity Physics / Rigidbody
- Unity NavMesh
- Raycasting
- Git / GitHub

## 📁 Project Structure

The Unity project is organized around Unity's standard `Assets`, `Packages`, and `ProjectSettings` structure, with gameplay implemented through modular C# scripts, prefabs, scenes, and supporting assets.

## 🚀 Running the Project

1. Clone the repository.
2. Open the project using **Unity Hub**.
3. Open the project's main scene.
4. Press **Play** in the Unity Editor.

> This project is primarily intended as a development/portfolio project. A standalone build is not currently provided in the repository.

## 📌 Project Context

Developed as a college game-development project through the **Game Development Club at SRM Institute of Science and Technology**.

---

**Project:** Death Zone  
**Role:** Primary Developer / Team Lead  
**Engine:** Unity  
**Language:** C#
