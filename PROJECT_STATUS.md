# Cult of the Mine — Project Status

## Current Version

Prototype 0.1

## Current Phase

Core Mining + Resource + EXP/Level + Floor + Economy Foundation

---

## Project Setup

* Unity 2D project created
* Git repository initialized
* Unity .gitignore configured
* Initial commit created
* GitHub remote configured
* Main branch configured
* Initial project pushed to GitHub

---

# Completed — Mining System

* Mining Area created
* Mining Area supports configurable dimensions
* Mines spawn inside the Mining Area
* Mine count is configurable through FloorData
* Mine positions are randomized
* Minimum distance between mines is enforced
* Maximum spawn attempts are configurable
* MineData ScriptableObject system created
* Stone Mine created
* Coal Mine created
* Mine HP implemented
* Mine Hardness implemented
* Automatic mining damage implemented
* Damage radius implemented
* Mines inside the damage radius receive damage
* Mines are destroyed when HP reaches zero
* Player automatically targets the nearest mine
* Player automatically moves toward the target
* Continuous mining loop implemented
* New mine cycle starts after all active mines are destroyed
* Damage text feedback implemented

---

# Completed — Ore System

* OreData ScriptableObject created
* Ore resources implemented
* Stone Ore implemented
* Coal Ore implemented
* OreInventory created
* Destroyed mines grant their configured Ore
* Ore quantity is independent from EXP
* Ore amounts are displayed through the UI
* Ore terminology established for mined resources
* OreInventory change events implemented for live UI updates

### Terminology

**Ore**

* Raw resource obtained from mines.

**Bar**

* Processed resource created from Ore through crafting.

---

# Completed — EXP & Level System

* Mine EXP implemented
* Each destroyed mine grants a fixed EXP amount
* EXP is granted once per destroyed mine
* Ore quantity does not multiply EXP
* Player EXP system implemented
* Player Level system implemented
* Level currently acts as a progression indicator
* Level does not currently provide gameplay bonuses
* EXP requirement increases with each level
* EXP curve is configurable

### Current Level Purpose

Player Level currently exists mainly to show progression.

Future systems may use Level for:

* Unlocks
* Upgrades
* Prestige
* Long-term progression

---

# Completed — Mine Distribution

Each floor can define:

* Mine types
* Relative spawn weights
* Mine count

Example:

* Stone: 80
* Coal: 20

Weights are relative and do not need to total 100.

---

# Completed — Floor System

* FloorData ScriptableObject created
* FloorManager created
* Four test floors created
* Each floor can define its own mine types
* Each floor can define its own mine count
* Each floor can define its own mine weights
* Floor switching implemented
* Player teleports to active floor
* Current mines are cleared when changing floors
* Fresh mine set is generated when entering a floor
* Previous floor mine state is not preserved
* Returning to a floor generates a completely new mine set
* Floor 1 → Floor 2 → Floor 3 → Floor 4 tested
* Returning to previous floors tested
* Floor unlock progression implemented
* Floor unlock requirements implemented
* Floor progress cannot exceed its required value
* Only unlocked floors are displayed
* Up / Down floor navigation implemented
* AUTO floor progression implemented
* AUTO can be manually enabled and disabled
* Manual floor selection disables AUTO
* Duplicate spawning during automatic floor transitions fixed

### Floor Unlock Requirements

* Floor 1 → 3 clears → Floor 2
* Floor 2 → 6 clears → Floor 3
* Floor 3 → 9 clears → Floor 4
* Floor 4 → 12 clears

Progress stops at the required value.

---

# Completed — Crafting System

* BarData ScriptableObject created
* Stone Bar created
* Coal Bar created
* BarInventory created
* BarInventory Add / Remove system implemented
* CraftingRecipe created
* CraftingSystem created
* Ore is consumed during crafting
* Bars are created from Ore
* Crafting supports multiple recipes
* Crafting UI supports multiple Bars
* Crafting UI updates when Ore changes
* Crafting button availability updates according to Ore amount

Current flow:

```text
Ore
↓
Crafting Recipe
↓
Bar
```

---

# Completed — Currency System

* CurrencyInventory created
* Currency is identified through a currency ID
* Currency system is designed to support multiple future currencies
* Currency Add / Get system implemented
* Currency change events implemented
* Currency UI created
* Currency amounts update automatically

Current example:

```text
gold
```

Future currencies can be added without replacing the inventory system.

---

# Completed — Bar Selling System

* BarSellSystem created
* Bars can be sold for Currency
* BarInventory Remove system integrated
* CurrencyInventory receives the sale value
* Multiple Bars can be configured for selling
* Bar selling UI created
* Bar selling UI displays current Bar amount
* Sell button becomes unavailable when Bar amount is zero
* Bar UI updates automatically when inventory changes

Current economy loop:

```text
Mine
↓
Ore
↓
OreInventory
↓
Crafting
↓
Bar
↓
BarInventory
↓
Sell
↓
CurrencyInventory
↓
Currency UI
```

---

# Completed — Mobile UI

* Portrait mobile layout established
* Canvas designed for 1080 × 1920
* Basic mining UI created
* Ore Panel created
* Ore amounts displayed
* Player Level displayed
* EXP progress displayed
* Floor selection menu created
* Only unlocked floors appear in the Floor Menu
* Floor navigation buttons created
* Floor progress requirement displayed
* AUTO button created
* AUTO visual state implemented
* Manual floor selection disables AUTO
* Crafting UI created
* Bar selling UI created
* Currency UI created

---

# Current Gameplay Foundation

```text
Player
↓
Nearest Mine
↓
Automatic Movement
↓
Automatic Mining
↓
Area Damage
↓
Mine Destroyed
├──→ Ore
└──→ Fixed EXP
      ↓
    Level
↓
Mine Cycle Complete
↓
Floor Progress
↓
Floor Unlock
↓
AUTO / Manual Floor Selection
↓
Fresh Mine Cycle
↓
Ore Inventory
↓
Crafting
↓
Bar Inventory
↓
Selling
↓
Currency Inventory
```

---

# Current Goal

The core mining loop, floor progression and basic economy foundation are working.

The next major system is the **Upgrade System**.

---

# Next Priority

1. Define UpgradeData
2. Define upgrade types
3. Define upgrade levels
4. Define upgrade costs
5. Connect upgrades to existing gameplay systems
6. Create UpgradeSystem
7. Create Upgrade UI
8. Test upgrade progression

---

# Not Yet Included

* Upgrades
* Tasks
* Prestige
* Prestige Points
* Offline progression
* Save system
* Large mines
* Resource multiplier mechanics
* Advanced UI
* Audio
* VFX
* Mobile optimization
