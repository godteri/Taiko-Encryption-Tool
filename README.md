# Taiko-Encryption-Tool
How to add custom songs to taiko no tatujin

## You need:
1. Tja charts
2. [okku3ds](https://www.teampapafox.org/projects/okku3ds.html)
3. [Eternity Audio Tool](https://animegamemods.net/thread/618/)
4. Some shitty program that i made
5. A good text editor

## Steps:
1. In the xbox app make sure that mods are enabled, then click on go to modification folder

2. Then go into the Taiko no Tatsujin_Data folder, and then the streamingassets folder

3. the fumen folder contains charts, the sound folder contains music 
for the chart and the readassets contains the information about the song

4. Make a new folder in the fumen folder and name it a short word
Remember this name cause you will be using it throughout this tutorial
I'll be reffering to it as (id)

5. You're gonna wanna grab three files from the readassets folder
(Musicinfo.bin, Songinfo.bin and newwordlist.bin)
and a random song file from the sound folder

6. Drag the musicinfo, songinfo and newwordlist each separately into
the taiko encryption tool exe, and select decrypt readasset

7. You have to edit the musicinfo, songinfo and newwordlist to add a new song into the game
these are json files im not gonna go into how they work, so if you are confused look up a tutorial

8. musicinfo
In the musicinfo file scroll down to until you see "UniqueId":75 and copy that entry
After you've pasted it, edit the uniqueid to 76, the id to to (id), then the songfilename to song_(id)
Also make sure that the price is 0
The rest is optional to edit

9. songinfo
The songinfo is simple just make a new entry change the id to (id)
then change the offset to the one in the tja without any punctuation

10. newwordlist
In newwordlist make a new entry, the key should be song_(id) and change all of the text to the name of the song

11. Drag each one of the separately into the taiko encryption tool exe and select encrypt readasset

12. Drag and replace them into the readasset folder in the streamingassets folder

13. Drag the music file into the encryption tool, and select decrypt music file, then
rename the fileextension from bin to acb

14. Open up eternity and open the file

15. Click on the first track hit replace, then select the song that came with the tja and hit dont loop

16. Click on file then save

17. Drag the music file into the encryption tool, and select encrypt music file, then
rename the fileextension from acb to bin

18. Rename the file into "sound_(id)", then put it in the sounds folder in streamingassets

19. Open the 3dstaiko folder go into okku, and in the bin folder delete the lzx file and the ffmpeg file

20. Open okkuconverter

21. Select the tja you want to add to the game

22. Select the difficulty

23. Hit "y"

24. There will now be a fumen file in the tja folder, drag it into the encryption tool and hit encrypt fumen

25. Then rename the fumen into "(id)_(difficulty).bin" the difficulties are "e" easy "n" normal "h" hard "m" extreme "x" ura oni

26. Drag the fumen into the folder you created in the fumen folder in streamingassets

27. Do this for each difficulty you want

28. If you've done this correctly, you should now have a new song in the game
