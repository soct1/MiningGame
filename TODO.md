# Cult of the Mine — TODO

## Prototype 0.1 — Core Mining

* [x] Create Mining Area
* [x] Create Mine representation
* [x] Create MineData
* [x] Create Player
* [x] Spawn mines
* [x] Prevent mines from spawning too close together
* [x] Create nearest mine targeting
* [x] Move Player automatically
* [x] Create automatic mining attack
* [x] Implement damage radius
* [x] Implement mine HP
* [x] Implement Hardness calculation
* [x] Destroy mine when HP reaches zero
* [x] Spawn new mine cycle when current cycle is completed
* [x] Complete continuous mining loop
* [x] Add damage text feedback
* [x] Add basic mining UI

## Resource & Progression

* [x] Create OreData
* [x] Create Ore resource system
* [x] Give Ore when a mine is destroyed
* [x] Create OreInventory
* [x] Display Ore amounts in UI
* [x] Add fixed EXP per destroyed mine
* [x] Create Player EXP system
* [x] Create Player Level system
* [x] Implement configurable EXP curve
* [x] Display Player Level
* [x] Display EXP progress

## Floor System

* [x] Create FloorData
* [x] Create FloorManager
* [x] Support multiple floors
* [x] Configure different mine types per floor
* [x] Configure mine spawn count per floor
* [x] Implement weighted mine spawning
* [x] Implement floor switching
* [x] Clear current floor mines when changing floor
* [x] Spawn a fresh mine set when entering a floor
* [x] Teleport Player to active floor
* [x] Create Floor selection UI
* [x] Show only unlocked floors
* [x] Implement floor unlock progression
* [x] Require Floor × 3 completed mining cycles to unlock next floor
* [x] Prevent completed floor progress from exceeding requirement
* [x] Test Floor 1 → Floor 2 → Floor 3 → Floor 4
* [x] Test returning to previously visited floors
* [x] Confirm floor state resets on re-entry
* [x] Implement Floor Up / Down navigation
* [x] Implement automatic floor progression
* [x] Implement AUTO enable / disable
* [x] Disable AUTO when manually selecting a floor
* [x] Prevent duplicate mine spawning during automatic floor transitions

## Economy

* [x] Define Ore resources
* [x] Create BarData
* [x] Create BarInventory
* [x] Define CraftingRecipe
* [x] Create CraftingSystem
* [x] Convert Ore into Bars
* [x] Create multi-Bar Crafting UI
* [x] Create CurrencyInventory
* [x] Define currency ID structure
* [x] Create BarSellSystem
* [x] Sell Bars for Currency
* [x] Create multi-Bar selling UI
* [x] Create Currency UI
* [ ] Define Upgrade system
* [ ] Define resource usage for Upgrades
* [ ] Define Tasks

## Long-Term Progression

* [ ] Define active gameplay progression
* [ ] Define prestige system
* [ ] Define Prestige Points
* [ ] Define long-term progression
* [ ] Define mine/tool upgrades
* [ ] Large mines
* [ ] Resource multiplier mechanics
* [ ] Determine future use of Player Level

## Save / Idle

* [ ] Save system
* [ ] Offline progression
* [ ] Offline calculation

## Later

* [ ] Advanced UI
* [ ] Audio
* [ ] VFX
* [ ] Mobile optimization
