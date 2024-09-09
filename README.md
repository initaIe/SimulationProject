# Simulation Console Application
This is a console-based simulation where various entities interact with their environment.
## Overview
Static Objects: Includes obstacles such as rocks, trees, and other immovable objects that entities must navigate around.<br>
Food: Resources such as grass, meat, and other edible items that certain entities consume for survival.<br>
Herbivores: Animals like pigs, sheep, and other plant-eaters that forage for food.<br>
Predators: wolves and other predators animals that hunt herbivores for sustenance.<br>
The simulation uses the A pathfinding algorithm* to allow animals to intelligently navigate the environment toward their targets, whether it's finding food or hunting prey.
### Key Features
A Pathfinding*: Entities use the A* algorithm to find the most efficient path to their destination, whether it be food or other entities.
Interactions:
Herbivores: Search for and consume food (e.g., grass).
Predators: Hunt and attack herbivores.
Static Obstacles: Trees, rocks, and other barriers that affect movement and pathfinding.
### Entities
Static Objects: Rocks, trees, etc.<br>
Food: Grass, meat, pizza, etc.<br>
Herbivores: Pigs, sheep, etc.<br>
Carnivores: Wolves, eagles, etc.<br>
If the entity has a goal and a path to it, it moves towards it, if not, it makes a random movement.
### Pathfinding
The A* algorithm is employed to guide the animals toward their goals, avoiding obstacles and finding the shortest path to food or prey.
### Installation
For installation use git clone, and for output you need to use a console that supports emoji output.