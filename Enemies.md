<h2 align="center">Enemies</h2>


<br>
<h2 align="center">Spawning</h2>
<p align="center">
EnemySpawner uses timer to check when enemy should be spawned. Enemies can't be placed in a random place, this would result in player being attack without the chance to fight back.
<br>
First one of 4 sides is randomly choosen, then random offset is generated, depending on a side, and added to spawn position, using this EnemySpawner spawns enemy outside of players view everytime and resets the timer.
</p>


<br>
<h2 align="center">Behaviour</h2>
<p align="center">
Most of the time enemies will just go to players location, except the times they are turned into a blue bomb with ReverseCorruption.
  Their speed and scale is controlled by health, more hp means slower and bigger.
  <br>
There are two ways for enemy to die, get destroyed instantly by player, or by being to small. When enemy becomes small enough it will start to evaporate and get even smaller.
</p>


<h3 align="center">
  <a href="README.md">ReadMe</a>
</h3>
