# NoteBoard
This application is intended to help people not forget which things to buy. It's going to consist of two parts. First part is andoid app with possibility to record voice, transform it to the text and make a note, also to tick notes as bought. Second part is another face of application for a browser.

Main idea:
There is an application for an andriod device, which interacts with a windows azure service. Windows azure service communicates with a database,
which is located also in windows azure cloud. 

Stack of technologies:
1. Entity Framework (Code first approach) for the interactions with the database.
2. ASP NET Web API 2 for the windows azure noteboard service.


************************************************************ version 1.0 *********************************************************

This version of the application works fine, however the perfomance is not good enough. You have to wait quite much time before you get the
possibility to make the first note. It look like a problem with establishing the connection with Google.

Pay attention! This version of the product is like a proof of concept and there can be some strange things, like hardcoded values, not implemented
things and so on. 

User features:
1. User has only two constant boards for notes (they are hardcoded programmatically for now)
2. User can add notes for both of the boards.
3. User can add notes using as voice as simple typing.
3. User can remove notes by clicking on them.


What's planning to add in future:
1. Possibility to install using only *.apk file.
2. Improve the perfomance in several times.
3. Possibility to switch between different boards by swipe from one side to another.
4. Possibility to create as much as needed different boards with notes.
5. Improve the UI.
