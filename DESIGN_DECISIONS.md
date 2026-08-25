# Cult of the Mine — Design Decisions

## Core Mining Loop

### Player Targeting

Status: Approved

Player automatically moves toward the nearest mine.

Movement is primarily visual and automatic.

The player does not manually move during the core mining loop.

---

## Mining Attack

Status: Approved

Player uses an automatic mining tool.

The tool deals damage at a fixed attack interval.

Current values are configurable and may change during balancing.

Example:

* Mining Power: 10
* Attack Interval: 1 second
* Damage Radius: Configurable

---

## Mining Radius

Status: Approved

All mines inside the mining tool's damage radius receive damage when the tool attacks.

Player movement target and damage targets are separate.

The Player can visually move toward one mine while nearby mines also receive damage.

---

# Mining Area

Status: Approved

Each floor has its own Mining Area.

Mines are spawned at random positions inside the active Mining Area.

Mines maintain a configurable minimum distance from each other.

Current prototype values:

* Minimum Spawn Distance: 1.2
* Maximum Spawn Attempts: 100

---

# Mine Spawn

Status: Approved

Each mining cycle normally contains 10 mines.

The actual mine count is configurable through FloorData.

All mines in the cycle spawn simultaneously.

The system is not hardcoded to 10 so future floors can use different counts.

---

# Mine Distribution

Status: Approved

Each floor defines which mine types can spawn and their relative spawn weights.

Example:

* Stone: 80
* Coal: 20

Weights are relative and do not need to total 100.

The actual probability is calculated from the total weight.

---

# Mine Cycle

Status: Approved

When all active mines are destroyed:

1. The completed cycle is registered.
2. Floor progression is updated.
3. If necessary, the next floor is unlocked.
4. AUTO progression may move to the next floor.
5. A new mine set is generated.
6. Mining continues automatically.

When changing floors, the current mine cycle is discarded.

A floor transition must create exactly one new mine cycle.

Duplicate spawning is not allowed.

---

# Ore System

Status: Approved

Mines provide **Ore** when destroyed.

Ore is the raw resource used by the economy.

Example:

```text
Stone Mine
→ +1 Stone Ore

Coal Mine
→ +1 Coal Ore
```

Ore quantity can vary independently from EXP.

Example:

```text
Mine
→ 3 Stone Ore
→ 1 EXP
```

Ore quantity does not determine EXP.

### Ore Inventory

The inventory system is named **OreInventory**.

The previous generic `ResourceInventory` terminology is no longer used.

OreInventory tracks raw Ore amounts and provides change events for UI updates.

---

# Bar System

Status: Implemented

**Bar** is the processed form of Ore.

The economy flow is:

```text
Mine
↓
Ore
↓
Crafting
↓
Bar
```

Bar types are represented by `BarData`.

Bars are stored in `BarInventory`.

BarInventory supports:

* Add
* Remove
* GetAmount
* Change events

---

# Crafting System

Status: Implemented

Crafting converts Ore into Bars through `CraftingRecipe`.

A recipe defines:

* Input Ore
* Input amount
* Output Bar
* Output amount

The `CraftingSystem` validates the required Ore, removes the Ore and adds the resulting Bar.

Current flow:

```text
OreInventory
↓
CraftingRecipe
↓
CraftingSystem
↓
BarInventory
```

Crafting UI supports multiple recipes and updates when Ore amounts change.

Exact economy balancing remains subject to gameplay testing.

---

# Currency System

Status: Implemented

The game's general currency system is named **CurrencyInventory**.

The previous `GoldInventory` terminology is no longer used.

Currencies are identified using a currency ID.

Current example:

```text
gold
```

The system is intentionally generic so future currencies can be added without replacing the inventory architecture.

CurrencyInventory supports:

* Add
* GetAmount
* Currency change events

---

# Bar Selling System

Status: Implemented

Bars can be sold through `BarSellSystem`.

The selling flow is:

```text
BarInventory
↓
BarSellSystem
↓
CurrencyInventory
```

Selling a Bar:

1. Checks the available Bar amount.
2. Removes the requested Bar quantity.
3. Adds the configured currency value.
4. Updates the relevant UI through inventory change events.

The Bar selling UI supports multiple Bar types.

---

# Economy

Status: Approved Foundation

Current economy:

```text
Mine
↓
Ore
↓
Craft
↓
Bar
↓
Sell
↓
Currency
```

Future economy:

```text
Currency
↓
Upgrades
```

Potential future uses of resources and currency:

* Upgrades
* Tasks
* Additional crafting
* Other progression systems

Exact prices and conversion values are not finalized.

---

# Experience System

## Mine EXP

Status: Approved

Every destroyed mine grants a fixed amount of EXP.

EXP is granted once per destroyed mine.

Ore quantity does not multiply EXP.

Example:

```text
Normal Mine
→ 1 Ore
→ 5 EXP

Large Mine
→ 3 Ore
→ 5 EXP
```

Resource multipliers also do not multiply EXP.

---

# Player Level

Status: Approved

The Player has a Level and EXP progression system.

For the current version, Level primarily represents progression.

Level currently does not provide:

* Mining Power
* Ore bonuses
* Floor unlocks
* Upgrade points
* Gameplay bonuses

Future systems may use Player Level.

Possible future uses:

* Progression requirements
* Unlocks
* Upgrades
* Prestige requirements

---

# EXP Curve

Status: Approved — Formula Not Finalized

Each new level requires more EXP than the previous level.

The formula must remain simple and easily changeable.

The exact formula will be determined through gameplay testing.

---

# Floor System

Status: Approved

The game always has one active floor.

The player can manually select any unlocked floor.

Each floor has its own:

* Mine types
* Mine weights
* Mine count
* Mining Area

---

# Floor Unlock Progression

Status: Approved

A new floor requires completed mining cycles on the previous floor.

Requirement:

```text
Required Clears = Floor Number × 3
```

Therefore:

```text
Floor 1 → 3 clears → Unlock Floor 2
Floor 2 → 6 clears → Unlock Floor 3
Floor 3 → 9 clears → Unlock Floor 4
Floor 4 → 12 clears
```

Progress cannot exceed its requirement.

The progression value represents **unlock progress**, not total historical clears.

---

# Floor Reset

Status: Approved

Floor mine states are NOT preserved when leaving a floor.

Returning to a floor always generates a fresh mine cycle.

This avoids unnecessary temporary state management.

---

# Floor Navigation

Status: Approved

The player has:

* Floor Menu button
* Up button
* Down button
* AUTO button

Only unlocked floors are available.

Manual floor selection immediately disables AUTO.

Up / Down navigation can only move between unlocked floors.

---

# AUTO Floor Progression

Status: Approved

AUTO can be enabled or disabled manually.

When AUTO is enabled:

1. The player continues mining the current floor.
2. Required progression is completed.
3. The next floor becomes available.
4. AUTO moves the player to the next unlocked floor.
5. A fresh mine set is spawned.

If multiple floors are already unlocked:

```text
Floor 1
↓
Floor 2
↓
Floor 3
↓
Floor 4
```

AUTO can continue through them sequentially.

Manual floor selection disables AUTO.

Enabling AUTO does not refresh or reset the current floor.

---

# UI

Status: Approved — Basic Prototype

Target layout:

* Portrait
* 1080 × 1920

Current UI includes:

* Ore Panel
* Ore amounts
* Player Level
* EXP progress
* Floor Menu
* Floor navigation
* AUTO button
* Mining feedback
* Crafting UI
* Bar selling UI
* Currency UI

UI should remain simple until the underlying gameplay systems are stable.

---

# Future Upgrade System

Status: Not Implemented

The next major gameplay system will be the Upgrade System.

Initial architecture should support configurable upgrades without hardcoding individual upgrade logic.

Potential upgrade categories:

* Mining Power
* Attack Interval
* Damage Radius
* Movement Speed
* Ore bonuses
* Other mining-related improvements

Upgrade costs will use the Currency system.

Exact upgrade values and progression are not finalized.

---

# Future Prestige

Status: Concept Approved

Prestige is a future long-term progression system.

Possible concept:

```text
Player Progress
↓
Prestige Reset
↓
Permanent Prestige Points
↓
Long-Term Bonuses
```

Prestige does not currently exist in the prototype.

The current Level and economy systems should remain flexible enough to support a future Prestige system.

---

# Design Principles

The project should prioritize:

1. Playable core loop
2. Simple systems
3. Data-driven configuration
4. Clear separation of responsibilities
5. Easy future expansion
6. Minimal unnecessary engineering
7. Test each system before adding the next major system

New systems should not be added to the MVP unless they are required for the core gameplay loop.
