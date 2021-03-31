# SPNOverflow


![](vestaslogo.jpeg)

Apparently there's something about the images...I wonder!
Usually, when dealing with images you start by looking at the METADATA, encoding patterns, etc... but there's nothing useful on that.
We do know that files types can embed other files types. Binwalk is a well-known and used utility that searchs a given binary image for embedded files and executable code. Let's give it a try!

```
└─$ binwalk vestaslogo.jpeg     

DECIMAL       HEXADECIMAL     DESCRIPTION
--------------------------------------------------------------------------------
0             0x0             JPEG image data, JFIF standard 1.01
262048        0x3FFA0         Zip archive data, at least v2.0 to extract, uncompressed size: 1337, name: text.txt
262733        0x4024D         Zip archive data, at least v2.0 to extract, uncompressed size: 327, name: __MACOSX/._text.txt
263184        0x40410         End of Zip archive, footer length: 22
 ```
 Touché! Seems like there are zip files embedded within the **vestaslogo.jpeg**. It is possible to extract such zip files by using the same tool by passing the mighty **-e** flag.
 
 ```
 └─$ binwalk vestaslogo.jpeg     

DECIMAL       HEXADECIMAL     DESCRIPTION
--------------------------------------------------------------------------------
0             0x0             JPEG image data, JFIF standard 1.01
262048        0x3FFA0         Zip archive data, at least v2.0 to extract, uncompressed size: 1337, name: text.txt
262733        0x4024D         Zip archive data, at least v2.0 to extract, uncompressed size: 327, name: __MACOSX/._text.txt
263184        0x40410         End of Zip archive, footer length: 22
 ```
 Now looking at the extract contents we found text.tct content.
 
 ```
 ____   _______________ _________________________    _________
\   \ /   /\_   _____//   _____/\__    ___/  _  \  /   _____/
 \   Y   /  |    __)_ \_____  \   |    | /  /_\  \ \_____  \ 
  \     /   |        \/        \  |    |/    |    \/        \
   \___/   /_______  /_______  /  |____|\____|__  /_______  /
                   \/        \/                 \/        \/ 
    __    __     __________________________      __    __    
    \ \   \ \   /   _____/\______   \      \    / /   / /    
     \ \   \ \  \_____  \  |     ___/   |   \  / /   / /     
     / /   / /  /        \ |    |  /    |    \ \ \   \ \     
    /_/   /_/  /_______  / |____|  \____|__  /  \_\   \_\    
                       \/                  \/                
                                                             

This is just the beginning of a long journey....

To find the next clue, you have to look around.

Who knows if it's MD5 or SHA-1, SHA-2. Only NSA knows it, or not....


59f271f6309355962f0fec64dca36cff44776ea4e199ed0a350147e15e0f3a6c


This hash allows you to unlock the following text:


D7fKPOftK2aYzKn0F7z+BeAmQeyAMZ0w+N5gCm5KlQ9JdVVcpS3+V/+APnnaHv2fN+z+wGLyI+1oS7FzszN5vbz/sNyt98/vcLYR7RJDb3cSQi8gV0Q5VgrtqVoksQ+F43l+7cdesdHZbCoc84/aJA==


Remember that this may have 2 steps! But you should know this better than I....

 ```
 At a first glance seems that we are looking at an encryption algorithm that makes use a key string to encode the precious plaintext. It might be a AES for instance...we'll see if we are mistaken or not.
 
 Well...The hashed key `59f271f6309355962f0fec64dca36cff44776ea4e199ed0a350147e15e0f3a6c` resembles a SHA-256. If you decode it it gives you the plain key.
 
 ```
 └─$ hash-identifier 59f271f6309355962f0fec64dca36cff44776ea4e199ed0a350147e15e0f3a6c                          100 ⨯
   #########################################################################
   #     __  __                     __           ______    _____           #
   #    /\ \/\ \                   /\ \         /\__  _\  /\  _ `\         #
   #    \ \ \_\ \     __      ____ \ \ \___     \/_/\ \/  \ \ \/\ \        #
   #     \ \  _  \  /'__`\   / ,__\ \ \  _ `\      \ \ \   \ \ \ \ \       #
   #      \ \ \ \ \/\ \_\ \_/\__, `\ \ \ \ \ \      \_\ \__ \ \ \_\ \      #
   #       \ \_\ \_\ \___ \_\/\____/  \ \_\ \_\     /\_____\ \ \____/      #
   #        \/_/\/_/\/__/\/_/\/___/    \/_/\/_/     \/_____/  \/___/  v1.2 #
   #                                                             By Zion3R #
   #                                                    www.Blackploit.com #
   #                                                   Root@Blackploit.com #
   #########################################################################
--------------------------------------------------

Possible Hashs:
[+] SHA-256
[+] Haval-256
 
 ```
 
 It is indeed a **SHA-256**, we can use `findmyhash.py` uitlity to get the plain text which is (**SPOILER ALERT**) 1234567891234567.
 
 ``` 
 findmyhash SHA256 -h 59f271f6309355962f0fec64dca36cff44776ea4e199ed0a350147e15e0f3a6c

Cracking hash: 59f271f6309355962f0fec64dca36cff44776ea4e199ed0a350147e15e0f3a6c

Analyzing with SHA256 ...

***** HASH CRACKED!! *****
The original string is: 1234567891234567 


The following hashes were cracked:
----------------------------------

59f271f6309355962f0fec64dca36cff44776ea4e199ed0a350147e15e0f3a6c -> 1234567891234567 

```


 
 
