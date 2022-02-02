# Taiko-Encryption-Tool
How to add custom songs to taiko no tatujin

## You need:
1. Tja charts
2. [okku3ds](https://www.teampapafox.org/projects/okku3ds.html)
3. [Eternity Audio Tool](https://animegamemods.net/thread/618/)
4. [.NET Core 3.1 Runtime (x86)](https://dotnet.microsoft.com/en-us/download/dotnet/3.1/runtime)
5. [A good text editor](https://notepad-plus-plus.org/downloads/)
6. Some shitty program that i made
7. Access to the taiko no tatsujin folder

## Steps:
1. Locate your Taiko No Tatsujin installation folder and open it

2. Then go into the Taiko no Tatsujin_Data folder, and then the streamingassets folder

3. the fumen folder contains charts, the sound folder contains music 
for the chart and the readassets contains the information about the song

4. Make a new folder in the fumen folder and name it a short word ex. "custom1"  
**Remember this name cause you will be using it throughout this tutorial**

5. You're gonna wanna grab three files from the readassets folder
(Musicinfo.bin, Songinfo.bin and newwordlist.bin)
and copy a random song file from the sound folder
**MAKE SURE TO MAKE BACKUPS!**

6. Drag the musicinfo, songinfo and newwordlist each separately into
the taiko encryption tool exe, and select decrypt readasset

7. You have to edit the musicinfo, songinfo and newwordlist to get the song in the game
these are json files, if you dont format it correctly the game won't load

8. **[musicinfo]**

![MusicInfo](https://i.imgur.com/dnFaoWT.png)

9. **[songinfo]**

![image](https://i.imgur.com/IdL0nMI.png)


10. **[newwordlist]**

![MusicInfo](https://i.imgur.com/tAJQfHu.png)

![MusicInfo](https://i.imgur.com/iR8xHte.png)

![MusicInfo](https://i.imgur.com/bKYM5mL.png)

11. Drag each one of the files separately into the taiko encryption tool exe and select encrypt readasset

12. Drag and replace them into the readasset folder in the streamingassets folder

13. Drag the music file into the Taiko Encryption Tool exe, and select decrypt music file, then
rename the fileextension from bin to acb

14. Open up eternity and open the file

15. Click on the first track hit replace, then select the song that came with the tja and hit dont loop

16. Click on file then save

17. Drag the music file into the Taiko Encryption Tool exe, and select encrypt music file, then
rename the fileextension from acb to bin

18. Rename the file into "song_(name)", then put it in the sounds folder in streamingassets

19. Open the 3dstaiko folder go into okku, and in the bin folder delete the lzx file and the ffmpeg file

20. Open okkuconverter

21. Select the tja you want to add to the game

22. Select a difficulty

23. Ignore the errors and hit "y"

24. There will now be a fumen file in the tja folder, drag it into the encryption tool and hit encrypt fumen

25. Then rename the fumen into "(name)_(difficulty).bin" the difficulties are "e" easy "n" normal "h" hard "m" extreme "x" ura oni

26. Drag the fumen file into the folder you created in the fumen folder in streamingassets

27. Do this for each difficulty you want

28. If you've done this correctly, you should now have a new song in the game

## Troubleshooting:
Q. The only thing that shows up when the game starts is load text

A. This means that there is something wrong with the readassets files
make sure theres no errors when editing the decrypted file and make sure you encrypt it afterwards

Q. Okku converter gives error when trying to convert tja

A. Open the tja in notepad++ hit the format tab, then click on convert to utf-8 and save then try again
