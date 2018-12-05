# Exploding Blocks

Start date: November 2017

This game has similar building mechanics as Minecraft. The only difference is that it is not as large and the player can destroy their buildings with a cannon.

There were a couple problems that I encountered. The first was that because I was rounding the value of the raycast hit position, the blocks were often placed inside of each other. I corrected for this by shifting the placement position slightly so that the rounding itself was shifted.
```
Vector3 backup = ray.GetPoint (hitInfo.distance - 0.2f);
```
The second problem was that after a certain height that the blocks were placed at, the tower of blocks would fall over due to the instability of the structure. To fix this problem, I made each block kinematic (static) until the cannon was fired. In addition, I added a fixed joint to each block that would join it to the block that was clicked. These fixed joints only broke if a force greater than the predetermined force acted upon it. This stabilized each structure further, even after the cannon was fired.

As I specified before, each block is placed at a position determined by a raycast from the camera (more specifically: where the player clicks). When a block is placed, its data is added to an array with the tag “Instantiated”. This becomes important when the game sets the kinematic value of each block to false.

![](https://media.giphy.com/media/2xPPvuF921a8N6ADUX/giphy.gif)

Removing a block is a little more complicated. When a block is removed, the actual block gameobject is destroyed from the game. But this poses a problem: because the block gameobject is destroyed from the game, it can’t be accessed when the game tries to set its kinematic value to false, thus throwing an error. Every time a block is removed, the game goes through the block array to identify the block and removes it from the array. While it is slightly slow, it reduces memory usage.

![](https://media.giphy.com/media/dYGbkGyDyWNeBrTe6X/giphy.gif)

Finally, the actual destruction:

![](https://media.giphy.com/media/fnyd4yLxz7Fq1rN2OC/giphy.gif)
