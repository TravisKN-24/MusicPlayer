Imports System.IO
Imports NAudio.Wave
Imports NAudio.Dsp

Public Class form1

    Private songPaths As New List(Of String)
    Private audioFile As AudioFileReader
    Private outputDevice As WaveOutEvent
    Private currentSongIndex As Integer = -1
    Private equalizer As Equalizer
    Private isPlaying As Boolean = False

    ' Toggle dark mode
    Private Sub btnDarkMode_Click(sender As Object, e As EventArgs) Handles btnDarkMode.Click
        If Me.BackColor = Color.White Then
            Me.BackColor = Color.Black
            btnDarkMode.BackColor = Color.White
            btnDarkMode.ForeColor = Color.Black
        Else
            Me.BackColor = Color.White
            btnDarkMode.BackColor = Color.Black
            btnDarkMode.ForeColor = Color.White
        End If

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button AndAlso ctrl IsNot btnDarkMode Then
                Dim btn As Button = CType(ctrl, Button)
                btn.BackColor = If(Me.BackColor = Color.Black, Color.White, Color.Black)
                btn.ForeColor = If(Me.BackColor = Color.Black, Color.Black, Color.White)
            End If
            If TypeOf ctrl Is Label AndAlso ctrl IsNot btnDarkMode Then
                Dim lbl As Label = CType(ctrl, Label)
                lbl.BackColor = If(Me.BackColor = Color.Black, Color.Black, Color.White)
                lbl.ForeColor = If(Me.BackColor = Color.Black, Color.White, Color.Black)
            End If
        Next
    End Sub

    ' Initialize form components and set initial colors
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        btnDarkMode.Location = New Point(945, 12)

        Me.BackColor = Color.White
        btnDarkMode.BackColor = Color.Black
        btnDarkMode.ForeColor = Color.White
        lblVolume.BackColor = Me.BackColor
        lblVolume.ForeColor = Color.Black

        tbVolume.Minimum = 0
        tbVolume.Maximum = 100
        tbVolume.Value = 35
        tbVolume.Orientation = Orientation.Horizontal

        tbBass.Minimum = -10
        tbBass.Maximum = 10
        tbBass.Value = 0
        tbBass.Orientation = Orientation.Horizontal

        tbTreble.Minimum = -10
        tbTreble.Maximum = 10
        tbTreble.Value = 0
        tbTreble.Orientation = Orientation.Horizontal

        AddHandler tbVolume.ValueChanged, AddressOf tbVolume_ValueChanged
        AddHandler tbBass.ValueChanged, AddressOf tbBass_ValueChanged
        AddHandler tbTreble.ValueChanged, AddressOf tbTreble_ValueChanged
    End Sub

    ' Close the application
    Private Sub btnQuit_Click(sender As Object, e As EventArgs)
        ActiveForm.Close()
    End Sub

    ' Import songs from a selected folder
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        lstSongs.Items.Clear()
        songPaths.Clear()

        Using folderBrowserDialog As New FolderBrowserDialog()
            If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                Dim folderPath As String = folderBrowserDialog.SelectedPath
                Dim songFiles As String() = Directory.GetFiles(folderPath, "*.mp3")

                For Each songFile As String In songFiles
                    lstSongs.Items.Add(Path.GetFileName(songFile))
                    songPaths.Add(songFile)
                Next
            End If
        End Using
    End Sub

    ' Adjust the volume based on the trackbar value
    Private Sub tbVolume_ValueChanged(sender As Object, e As EventArgs) Handles tbVolume.ValueChanged
        If audioFile IsNot Nothing Then
            audioFile.Volume = tbVolume.Value / 100.0F
        End If
        lblVolume.Text = $"Volume: {tbVolume.Value}"
    End Sub

    ' Adjust the bass level based on the trackbar value
    Private Sub tbBass_ValueChanged(sender As Object, e As EventArgs) Handles tbBass.ValueChanged
        If equalizer IsNot Nothing Then
            equalizer.AdjustBass(tbBass.Value)
        End If
        lblBass.Text = $"Bass: {tbBass.Value}"
    End Sub

    ' Adjust the treble level based on the trackbar value
    Private Sub tbTreble_ValueChanged(sender As Object, e As EventArgs) Handles tbTreble.ValueChanged
        If equalizer IsNot Nothing Then
            equalizer.AdjustTreble(tbTreble.Value)
        End If
        lblTreble.Text = $"Treble: {tbTreble.Value}"
    End Sub

    ' Play or pause the selected song
    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        If isPlaying Then
            PauseSong()
        Else
            PlaySelectedSong()
        End If
    End Sub

    ' Pause the currently playing song
    Private Sub PauseSong()
        If outputDevice IsNot Nothing Then
            If outputDevice.PlaybackState = PlaybackState.Playing Then
                outputDevice.Pause()
                isPlaying = False
                btnPlay.Text = "|>"
            End If
        End If
    End Sub

    ' Play the next song in the playlist
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        PlayNextSong()
    End Sub

    ' Play the previous song in the playlist
    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        PlayPreviousSong()
    End Sub

    ' Update the current song index when selection changes
    Private Sub lstSongs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSongs.SelectedIndexChanged
        currentSongIndex = lstSongs.SelectedIndex
    End Sub

    ' Play the selected song from the playlist
    Private Sub PlaySelectedSong()
        If lstSongs.SelectedIndex >= 0 Then
            PlaySong(songPaths(lstSongs.SelectedIndex))
        End If
    End Sub

    ' Play the next song in the playlist
    Private Sub PlayNextSong()
        If lstSongs.Items.Count > 0 Then
            currentSongIndex = (currentSongIndex + 1) Mod lstSongs.Items.Count
            lstSongs.SelectedIndex = currentSongIndex
            PlaySong(lstSongs.SelectedItem.ToString())
        End If
    End Sub

    ' Play the previous song in the playlist
    Private Sub PlayPreviousSong()
        If lstSongs.Items.Count > 0 Then
            currentSongIndex = If(currentSongIndex - 1 < 0, lstSongs.Items.Count - 1, currentSongIndex - 1)
            lstSongs.SelectedIndex = currentSongIndex
            PlaySong(lstSongs.SelectedItem.ToString())
        End If
    End Sub

    ' Start playing the selected song
    Private Sub PlaySong(songPath As String)
        txtNow.Text = Path.GetFileName(songPath)

        If outputDevice IsNot Nothing Then
            outputDevice.Stop()
            outputDevice.Dispose()
            outputDevice = Nothing
        End If

        If audioFile IsNot Nothing Then
            audioFile.Dispose()
            audioFile = Nothing
        End If

        audioFile = New AudioFileReader(songPath)
        equalizer = New Equalizer(audioFile)
        outputDevice = New WaveOutEvent()
        outputDevice.Init(equalizer)

        AddHandler outputDevice.PlaybackStopped, AddressOf OutputDevice_PlaybackStopped

        outputDevice.Play()
        isPlaying = True
        btnPlay.Text = "|>"

        AdjustVolume()
        AdjustBass()
        AdjustTreble()
    End Sub

    ' Automatically play the next song when playback stops
    Private Sub OutputDevice_PlaybackStopped(sender As Object, e As StoppedEventArgs)
        If currentSongIndex < songPaths.Count - 1 Then
            currentSongIndex += 1
            PlaySong(songPaths(currentSongIndex))
            lstSongs.SelectedIndex = currentSongIndex
        End If
    End Sub

    ' Adjust the volume of the currently playing song
    Private Sub AdjustVolume()
        If audioFile IsNot Nothing Then
            audioFile.Volume = tbVolume.Value / 100.0F
        End If
    End Sub

    ' Adjust the bass level of the currently playing song
    Private Sub AdjustBass()
        If equalizer IsNot Nothing Then
            equalizer.AdjustBass(tbBass.Value)
        End If
    End Sub

    ' Adjust the treble level of the currently playing song
    Private Sub AdjustTreble()
        If equalizer IsNot Nothing Then
            equalizer.AdjustTreble(tbTreble.Value)
        End If
    End Sub
End Class

Public Class Equalizer
    Implements ISampleProvider

    Private ReadOnly sampleProvider As ISampleProvider
    Private bass As Single = 0.0F
    Private treble As Single = 0.0F

    Public Sub New(sourceProvider As ISampleProvider)
        sampleProvider = sourceProvider
        WaveFormat = sourceProvider.WaveFormat
    End Sub

    Public ReadOnly Property WaveFormat As WaveFormat Implements ISampleProvider.WaveFormat

    Public Function Read(buffer As Single(), offset As Integer, count As Integer) As Integer Implements ISampleProvider.Read
        Dim samplesRead = sampleProvider.Read(buffer, offset, count)
        For i = 0 To samplesRead - 1 Step 2
            buffer(i) *= (1 + bass * 0.1F)
            buffer(i + 1) *= (1 + treble * 0.1F)
        Next
        Return samplesRead
    End Function

    Public Sub AdjustBass(value As Integer)
        bass = value
    End Sub

    Public Sub AdjustTreble(value As Integer)
        treble = value
    End Sub
End Class
