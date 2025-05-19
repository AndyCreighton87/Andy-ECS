## Entity Component System (ECS)

# Overview

This project is an early attempt at creating a custom Entity Component System (ECS) in C#. The aim was to build a modular and efficient architecture for game development, where entities are composed of components, and behavior is defined by systems.

# Features

Basic ECS structure with separate entities, components, and systems.

Entities are composed of multiple components, making them highly modular.

Systems operate on entities that have the required components.

# How It Works

Entities are essentially IDs that serve as a container for components.

Components are plain data containers (e.g., PositionComponent, HealthComponent).

Systems contain logic and operate on entities that match their required components.


## Technical Details

Components are stored separately from entities, enabling fast access and efficient memory usage.

Systems are designed to only interact with entities that have the required components.

The project is in an early state, with basic functionality established but plenty of room for improvement.

## Future Improvements

Optimize component storage and lookup for performance.

Implement a more advanced system for managing component dependencies.

Add a proper initialization and destruction lifecycle for entities and systems.

Job System.

## License

This project is licensed under the MIT License.

#Acknowledgments

Inspired by the ECS architecture used in game engines such as Unity's DOTS.
