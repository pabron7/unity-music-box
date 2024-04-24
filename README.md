# MUSIC BOX
> Music Box that supports multiple playlists. Made for Unity.
> Can be used for both prototyping and production.
> Was developed to be able to test multiple music samples for different environments & themes. For example; safe zones, danger zones, combat, town, etc...
***
### INSTRUCTIONS
* Simply create a new variable in the Playlist script _List<SongEntry>_. 
* Then, add your pieces of music from the inspector. Later, create a new variable in the Music Box Controller script to represent your new playlist variable. 
* Also, add a new entry to the dropdown menu to be able to switch between those. 
* Finally, it should work without a flow.
##### IMPLEMENTATION INTO A NEW SCENE
* If you want to implement it into a new scene, just drop the Music Box component in the hierarchy and Music Box Renderer under your UI Canvas.
* Then, attach the required UI elements to the Music Box. (You will see them in the inspector)
* Create your music playlists as you want, create variables and it's done.
---
###### USEFUL LINKS
[Dropdown Tutorial](https://gamedevdustin.medium.com/using-dropdowns-for-difficulty-in-unity-2021-urp-a33ffbc2ffed)
[Unity Audio Source Documentation](https://docs.unity3d.com/ScriptReference/AudioSource.html)
---
### HOW DOES IT WORK?
It reads your Song Entry lists and plays them in an order. The buttons change the index and reset it to 0 after reaching the ends of the list. The dropdown simply changes your current playlist and resets index to 0.
