# Survival Game

A Unity 6 (URP) survival game inspired by Ark and Subnautica. Features player movement, inventory, crafting, backpack, status bars (health/food/water/breath), swimming, and a debug command console.

## Stack
- **Engine**: Unity 6000.4.7f1 (Universal Render Pipeline)
- **Language**: C#
- **Render Pipeline**: URP

## Project Structure
- `Assets/Resources/Scripts/Player/` — PlayerCamera, PlayerMovement, StatusManager, ItemAction
- `Assets/Resources/Scripts/Inventory/` — InventoryManager, HotbarNavigation, InventorySlotUI
- `Assets/Resources/Scripts/UI/crafting/` — crafting (toggle), CraftingManager, recipe UI
- `Assets/Resources/Scripts/UI/inventory/` — BackpackToggle, BackpackManager
- `Assets/Resources/Scripts/UI/Debug/` — CommandConsoleToggle, CommandMenu, ItemList
- `Assets/Resources/Scripts/Data/` — ItemData, Item, InventorySlot, craftingData, Harvestable, etc.
- `Assets/Resources/Scripts/Water/` — Water, Breath

## Running the Project
Open in Unity 6000.4.7f1 or later. The Unity Editor cannot run inside Replit — use this repo for source control and script editing only.

## Key Controls
| Key | Action |
|-----|--------|
| WASD | Move |
| Shift | Sprint |
| Space | Jump / swim up |
| E | Open backpack / drink water |
| C | Open crafting |
| F1 | Open debug console |
| Escape | Close any open menu |
| Q | Drop hotbar slot 0 |
| LMB | Pick up item |

## User Preferences
- Keep existing project structure and Unity conventions.
- Do not restructure or migrate the project without asking.
