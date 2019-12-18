# GE1 Assignment Chris Finn

My proposal for my assignment is a small, cubish, minecraft-esque world that reacts to the music that is being played. I will create a character which is controlled by the player with a 1st person view. There will be a sort of "Staging area" in which the player can control some of the things occurring within the world. The player may be able to control the song playing, control the volume, and randomize the color of the cubes as they react to the song that's playing. My idea is to take the audio visualiser I made a while ago for an assignment I had and integrate the new thing's ive learned and expand upon what I already knew. It will be an evolved version of what I made a while ago. 

 I am still unsure of exactly what I want to add into this world but I am pretty set on the basic idea of a world reacting to audio. However, I don't plan on making the entire world react to the music. If the entire world, inlcuding the ground of the world is bouncing around it may be a little too much if the player wants to explore the area, so I will have key areas that will react to the music. These key areas will include things such as "audio mountains", there may be "audio rivers", "audio caves", an "audio forest", etc. These will be fun little areas or vistas that the player can view. I am still unsure what my limit will be, however, I want to make the world feel alive due to the music, make it vibrant and interesting, and give the player some control over what is happening. The staging area will be like a DJ Booth at a live show. I will try to add in multiple cameras around the place that the player can change to in order to get a different perspective of whatever they wish to view.
 
 The whole idea is to give the player something they can enjoy watching and also interact with. I am still coming up with things to add to the project and considering leaving some things out, but the basic premise will remain.
 
 
 # End of assignment report.
 
 Description of what I did:
 
 First of all I want to say that what I had planned and what I created are quite different. I had planned to combine the audio visualization with the procedural generation terrain but was unable to. I resorted to making 2 seperate scenes. One that had the procedurally generated voxel world, and one that had some audio visualization. I started off with the procedurally generated voxel world.
the majority of my time and effort was spent on that scene as I was attempting to replicate the basis of a minecraft like game. I used 2D perlin noise to generate the terrain and uvs to texture the voxels. The players can also destory targeted blocks with left click and place blocks with right click. The player can adjust what block they are placing with the mouse wheel. To cut down of usage and solve performance issues, multiple things had to be done. First of all I implemented a view distance. This limits the player to a certain amount of chunks being visible in the scene within a certain radius. As the player moves, the new chunks are then loaded one by one and are now fully loaded so that if the player walks back over them there will be no lag. The sides of the voxels are hidden when touching another voxel to cut down on usage.
For the audio visualizer I made cubes scale on the y axis depending on the frequency of the audio playing. I limited them to 8 bands which covers 20Hz - 22000Hz. I then adjusted the shape of these cubes and made new forms to suit the room. I made a staging area for the player to reside and the ability to change some things in the scene such as volume, and disabling/enabling objects. I had planned to combine these features with the terrain scene for a more "whole" project, however I am still happy with what I was able to do.

What I am most proud of:

 I think the terrain scene and everything in it is quite well made. I relied heavily on tutorials for making this but I am still happy with the results.
 
Useful resources:

[Youtube](https://www.youtube.com/watch?v=h66IN1Pndd0&list=PLVsTSlfj0qsWEJ-5eMtXsYp03Y9yF1dEn&index=1)
[Youtube](https://www.youtube.com/watch?v=4Av788P9stk&list=PL3POsQzaCw53p2tA6AWf7_AWgplskR0Vo&index=2)

These 2 videos belong to playlists that are extremely helpful and benefited me a lot.

[Unity Answers](https://answers.unity.com/index.html)

Very helpful website for programming in Unity.

My Youtube video:

[Youtube](https://www.youtube.com/watch?v=xdw1VA2-BzM)
