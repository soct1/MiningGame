# Cult of the Mine — Design Decisions

## Core Mining Loop

### Player Targeting
Status: Approved

Player automatically moves toward the nearest mine.

The movement is primarily visual. Player does not need manual movement for mining.

### Mining Attack
Status: Approved

Player uses an automatic mining tool.

The tool deals damage at a fixed attack interval.

Example starting tool:

- Damage: 10
- Attack Interval: 1 second
- Damage Radius: TBD

### Mining Radius
Status: Approved

All mines inside the mining tool's damage radius receive damage when the tool attacks.

Player's movement target and damage targets are separate.

The player visually moves toward one mine, while nearby mines inside the radius can also receive damage.

### Mining Area
Status: Approved

Each floor has a Mining Area.

Mines are spawned at random positions inside the Mining Area.

### Mine Spawn
Status: Approved

Each mining cycle contains exactly 10 mines.

All 10 mines spawn simultaneously.

Each mine type is randomly selected from the 2 mine types available on that floor.

### Mine Cycle
Status: Approved

When all 10 mines are destroyed, the current mines are cleared and a new set of 10 random mines is spawned.

The cycle continues indefinitely.

### Mine Resources
Status: Approved

A normal mine gives 1 unit of its corresponding resource when destroyed.

Large mines and resource multiplier mechanics are future systems.

## Mine Stats

Each mine currently has:

- HP
- Hardness

Hardness is intended to scale incoming mining damage so that HP and damage values do not need to become excessively large as the game eventually introduces many mine types.

The exact mathematical formula is NOT finalized.

## Future Economy

Resources may later be:

- Crafted into Bars
- Sold for Gold
- Used for Upgrades
- Used for Tasks

These systems are outside the first mining prototype.