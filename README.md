# Game Of Life
Windows Form Application - c#

A little game of life to have running on your computer to fill the empty screen.

![image](https://user-images.githubusercontent.com/51237466/190041228-6615a950-0534-4fae-b613-b0454b6471ac.png)

## Game Rules
Under traditional rules, for each "cycle" of the game the following decision is made for every cell based on the state of its neighbors.

If the cell is alive:
 - If < 2 neighbors are alive, the cell dies by underpopulation
 - If > 3 neighbors are alive, the cell dies by overpopulation
 - Otherwise, the cell lives on
 
If the cell is dead:
 - If exactly 3 neighbors are alive, the cell lives by reproduction
 - Otherwise, the cell remains dead

## Controls
When launching the program, a controller will appear alongside the "tank" the game is played in:

![image](https://user-images.githubusercontent.com/51237466/190041472-594e794d-8527-4f85-88e5-e19a6a3cabbf.png)

### Stats
The stats group contains information about the current and full life of the game:
- Alive: The current amount of cells alive within the game
- Dead: The current amount of dead cells within the game
- Avg Lifespan: The average age of each cell 
- Births: Total amount of cells that transitioned from dead to alive
- Deaths: Total amount of cells that transitioned from alive to dead 
- Cycles: Amount of cycles run 

### Config
The config group contains a few options, and can modify the game in real time:
- Cell Size: Size of the cells in the game (warning: resets the game)
- Cycle time (ms): The amount, in milliseconds, each "cycle" of the game is performed
- Rand Density (%): The percentage of cells "alive" at the start of a new game
- Set Tank Color: Changes the color of the background of the game
- Set Cell Color: Changes the color of alive cells
- Freeze: Prevents cycles from running
- Show Grid: Adds a border between cells

### Feed
The feed button provides a way of breathing life into a already running game. Hitting the feed button modifies the next cycle of the game when determining whether a cell lives or dies. In addition to the traditional rules for the game, the following modifies are added

If the cell is alive and is feed:
 - If < 1 neighbors are alive, the cell dies by underpopulation
 - If > 4 neighbors are alive, the cell dies by overpopulation
 - Otherwise, the cell lives on
 
If the cell is dead:
 - If > 3 neighbors are alive and fed, the cell lives by reproduction
 - Otherwise, the cell remains dead

### Reset
The game can be reset in a few methods; either resizing the tank window, or by hitting one of the reset buttons.
- Random: The game is reset using the density config to determine the initial amount of alive cells
- Glider: The game is reset with a glider pattern
- Spaceship: The game is reset with a spaceship pattern
- Glider Gun: The game is reset with a glider gun pattern
- Row: The game is reset with a row pattern
- Pulsar: The game is reset with a pulsar pattern
