How do you use this asset?

Firstly, please note that it usually easier to match the camera to the size of the background than the other way around. Resizing the content rather than the camera leads to undesirable gaps in between the backgrounds. Having said that... The scripts for horizontal parallax attempt to dynamically assign the number of background images to clone and recycle. Currently, the scripts detect the screen width and the background's width and uses that to create up to three extra background images on either side of the camera so that the recycling is not seen by the camera.

Without further ado...

Add Script to GameObject: First, create an empty game object, call it something like "ParalaxGroup." Then add one script by dragging the script into the inspector for the object. To create layers, add multiple scripts to the same GameObject. Consider each component you assign as its own layer.

Set ScrollSpeed: Adjust the speed at which the background scrolls in the Inspector window.

Set PoolSize: This part is now mostly automated for the horizontal parallax scripts. For the vertical scripts, you will need to determine the number of background objects that will be instantiated. Adjust this according to the size and complexity of your background. Please note that the scripts will automatically hide all sprites that were assigned before spawning in the clones. This is so the original images and sprites do not detract from the parallax by staying visible.

Set GapSize: Another portion that is largely automated. Sometimes, however, you may want to control the gap between each background object. You can see my use of gap control in the vertical parallax sample scenes. If you set this to zero, the script will try to dynamically snap the backgrounds together. If a gap still remains, you may use a negative gap value to seal it.

Set AlphaChance: Controls the chance for a background object to be 100% opaque or 100% transparent. If you set this to zero, the backgrounds will never be hidden. If you set it to one, they will always be hidden. Again, this is the CHANCE that they will be visible or not. You can see my use of this feature in the Vertical Parallax scenes.

Adjust Transforms: You can adjust the position of the background objects by moving the transform around in the scene. This will change where the backgrounds scroll from. Honestly, I do not think changing the offset values does anything noticeable. You can 100% adjust the positioning of the backgrounds using the transforms.

Instantiate BackgroundPrefab: Assign the prefab for the background that will be scrolling in the Inspector window by dragging and dropping your desired prefab into the field.

Remember to save your changes and run your game to see the effects.

And that’s it! You now have a multiple layered parallax background in your Unity game. Remember, you can always tweak the parameters in the script to get the exact look you want.

If you need assistance, email me at jmeyer1980@gmail.com. I can help by explaining the process further. I will not help with editing the scripts. They have been commented fairly well and AI can help you with the code if you know how to use it.

Happy devving!
Bellok