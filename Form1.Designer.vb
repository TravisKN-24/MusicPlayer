<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form1))
        btnDarkMode = New Button()
        btnImport = New Button()
        lstSongs = New ListBox()
        tbVolume = New TrackBar()
        tbBass = New TrackBar()
        tbTreble = New TrackBar()
        lblVolume = New Label()
        lblBass = New Label()
        lblTreble = New Label()
        lblNow = New Label()
        txtNow = New TextBox()
        btnPlay = New Button()
        btnNext = New Button()
        btnPrevious = New Button()
        lblName = New Label()
        CType(tbVolume, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbBass, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbTreble, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnDarkMode
        ' 
        btnDarkMode.BackColor = Color.Black
        btnDarkMode.Cursor = Cursors.Hand
        btnDarkMode.Font = New Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDarkMode.ForeColor = Color.White
        btnDarkMode.Location = New Point(932, 12)
        btnDarkMode.Name = "btnDarkMode"
        btnDarkMode.Size = New Size(146, 49)
        btnDarkMode.TabIndex = 1
        btnDarkMode.Text = "DARK MODE"
        btnDarkMode.UseVisualStyleBackColor = False
        ' 
        ' btnImport
        ' 
        btnImport.BackColor = Color.Black
        btnImport.Font = New Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnImport.ForeColor = Color.White
        btnImport.Location = New Point(110, 77)
        btnImport.Name = "btnImport"
        btnImport.Size = New Size(199, 48)
        btnImport.TabIndex = 2
        btnImport.Text = "IMPORT FOLDER"
        btnImport.UseVisualStyleBackColor = False
        ' 
        ' lstSongs
        ' 
        lstSongs.FormattingEnabled = True
        lstSongs.Location = New Point(23, 146)
        lstSongs.Name = "lstSongs"
        lstSongs.Size = New Size(395, 384)
        lstSongs.TabIndex = 3
        ' 
        ' tbVolume
        ' 
        tbVolume.Location = New Point(488, 178)
        tbVolume.Name = "tbVolume"
        tbVolume.Size = New Size(252, 56)
        tbVolume.TabIndex = 5
        ' 
        ' tbBass
        ' 
        tbBass.Location = New Point(488, 315)
        tbBass.Name = "tbBass"
        tbBass.Size = New Size(252, 56)
        tbBass.TabIndex = 6
        ' 
        ' tbTreble
        ' 
        tbTreble.Location = New Point(488, 446)
        tbTreble.Name = "tbTreble"
        tbTreble.Size = New Size(252, 56)
        tbTreble.TabIndex = 7
        ' 
        ' lblVolume
        ' 
        lblVolume.AutoSize = True
        lblVolume.Font = New Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblVolume.Location = New Point(516, 138)
        lblVolume.Name = "lblVolume"
        lblVolume.Size = New Size(83, 28)
        lblVolume.TabIndex = 8
        lblVolume.Text = "Volume:"
        ' 
        ' lblBass
        ' 
        lblBass.AutoSize = True
        lblBass.Font = New Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblBass.Location = New Point(516, 279)
        lblBass.Name = "lblBass"
        lblBass.Size = New Size(61, 28)
        lblBass.TabIndex = 9
        lblBass.Text = "Bass:"
        ' 
        ' lblTreble
        ' 
        lblTreble.AutoSize = True
        lblTreble.Font = New Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTreble.Location = New Point(516, 413)
        lblTreble.Name = "lblTreble"
        lblTreble.Size = New Size(81, 28)
        lblTreble.TabIndex = 10
        lblTreble.Text = "Treble:"
        ' 
        ' lblNow
        ' 
        lblNow.AutoSize = True
        lblNow.Font = New Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblNow.Location = New Point(870, 179)
        lblNow.Name = "lblNow"
        lblNow.Size = New Size(137, 29)
        lblNow.TabIndex = 11
        lblNow.Text = "Now Playing:"
        ' 
        ' txtNow
        ' 
        txtNow.Location = New Point(802, 222)
        txtNow.Name = "txtNow"
        txtNow.Size = New Size(276, 27)
        txtNow.TabIndex = 12
        ' 
        ' btnPlay
        ' 
        btnPlay.BackColor = Color.Black
        btnPlay.Font = New Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPlay.ForeColor = Color.White
        btnPlay.Location = New Point(909, 280)
        btnPlay.Name = "btnPlay"
        btnPlay.Size = New Size(57, 41)
        btnPlay.TabIndex = 13
        btnPlay.Text = "|>"
        btnPlay.UseVisualStyleBackColor = False
        ' 
        ' btnNext
        ' 
        btnNext.BackColor = Color.Black
        btnNext.Font = New Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNext.ForeColor = Color.White
        btnNext.Location = New Point(993, 280)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(57, 41)
        btnNext.TabIndex = 14
        btnNext.Text = ">>"
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' btnPrevious
        ' 
        btnPrevious.BackColor = Color.Black
        btnPrevious.Font = New Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPrevious.ForeColor = Color.White
        btnPrevious.Location = New Point(822, 280)
        btnPrevious.Name = "btnPrevious"
        btnPrevious.Size = New Size(57, 41)
        btnPrevious.TabIndex = 15
        btnPrevious.Text = "<<"
        btnPrevious.UseVisualStyleBackColor = False
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Font = New Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblName.Location = New Point(488, 675)
        lblName.Name = "lblName"
        lblName.Size = New Size(189, 32)
        lblName.TabIndex = 16
        lblName.Text = "Made by Travis"
        ' 
        ' form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1107, 731)
        Controls.Add(lblName)
        Controls.Add(btnPrevious)
        Controls.Add(btnNext)
        Controls.Add(btnPlay)
        Controls.Add(txtNow)
        Controls.Add(lblNow)
        Controls.Add(lblTreble)
        Controls.Add(lblBass)
        Controls.Add(lblVolume)
        Controls.Add(tbTreble)
        Controls.Add(tbBass)
        Controls.Add(tbVolume)
        Controls.Add(lstSongs)
        Controls.Add(btnImport)
        Controls.Add(btnDarkMode)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Music Hub"
        CType(tbVolume, ComponentModel.ISupportInitialize).EndInit()
        CType(tbBass, ComponentModel.ISupportInitialize).EndInit()
        CType(tbTreble, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnDarkMode As Button
    Friend WithEvents btnImport As Button
    Friend WithEvents lstSongs As ListBox
    Friend WithEvents tbVolume As TrackBar
    Friend WithEvents tbBass As TrackBar
    Friend WithEvents tbTreble As TrackBar
    Friend WithEvents lblVolume As Label
    Friend WithEvents lblBass As Label
    Friend WithEvents lblTreble As Label
    Friend WithEvents lblNow As Label
    Friend WithEvents txtNow As TextBox
    Friend WithEvents btnPlay As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents lblName As Label

End Class
