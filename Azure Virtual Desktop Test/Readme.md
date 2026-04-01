Azure Virtual Desktop.

I have done AVD first time as my exam work at the end of my first IT school.
Back in the day, I have fixed it on the Azure GUI Interface. 
While It worked and I could do a presentation, it was all new to me but it fascinated me that No matter where you are in the world or what type of OS you running,
you can connect to a company resources and have your own windows desktop inside the company. 
You dont have to say no to productivity softwares like office either.
You can just adjust it, what type of desktop you want, with or without office365.
In 2024 I could deploy via GUI only, this week I managed to do with Visual Studio and Azure CLI.
It worked but I did not fix fslogic and persistent user folders on an azure share drive.
The coming weeks, I will try to create again the AVD solution but this time in JSON and add azure share drive and fslogix with persistent user folders.

In pooled virtual desktop, when a user login to a virtual desktop and example saves a document. The system saves it.
But when you log in the next time, Its not always possible that you will login to the same virtual desktop and you might find your saved document.
The system log you in to a different pooled virtual Desktop.
Thats why there is a shared drive and fslogic, when you login to a virtual drive, Azure will attach your private folder to the desktop you loged in,
so you can save your files on the shared drive under your name. Also need to configure NTFS file permissions and so on. 
