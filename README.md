Music Hub

This application is a simple music player built using VB.NET and NAudio library for audio playback and equalization.

Features
Play, pause, skip forward, and skip backward functionalities.
Volume control with adjustable bass and treble levels.
Dark mode toggle for UI customization.
Import songs from a specified folder.
Prerequisites
Windows operating system (tested on Windows 11).
.NET Framework 8 or later.
Installation
Clone or download the repository to your local machine.
Open the project in Visual Studio (version 2019 or later).
Restore NuGet packages if prompted.
Build the solution to restore dependencies and compile the application.
Usage
Run the application by pressing F5 or clicking on the Start button in Visual Studio.
Click on the Import button to select a folder containing MP3 files.
Use the playlist (lstSongs) to select a song to play.
Adjust volume, bass, and treble levels using the corresponding sliders (tbVolume, tbBass, tbTreble).
Click Play (btnPlay) to start playback. Click again to pause.
Use Next (btnNext) and Previous (btnPrevious) buttons to navigate through the playlist.
Controls
Dark Mode: Toggle button (btnDarkMode) to switch between light and dark modes.

Notes
This application uses NAudio for audio playback and equalization. Make sure to have the necessary dependencies installed and configured correctly.
Ensure that your system has the appropriate audio drivers and permissions to play audio files.
