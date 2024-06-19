Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class RoundedButton
    Inherits Button

    Private _borderRadius As Integer = 30 ' Adjust this value for more rounded corners

    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate() ' Redraw the button
        End Set
    End Property

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        Dim path As New GraphicsPath()
        path.AddArc(New Rectangle(0, 0, _borderRadius * 2, _borderRadius * 2), 180, 90)
        path.AddArc(New Rectangle(Me.Width - _borderRadius * 2, 0, _borderRadius * 2, _borderRadius * 2), -90, 90)
        path.AddArc(New Rectangle(Me.Width - _borderRadius * 2, Me.Height - _borderRadius * 2, _borderRadius * 2, _borderRadius * 2), 0, 90)
        path.AddArc(New Rectangle(0, Me.Height - _borderRadius * 2, _borderRadius * 2, _borderRadius * 2), 90, 90)
        path.CloseAllFigures()

        Me.Region = New Region(path)

        MyBase.OnPaint(pevent)

        Using pen As New Pen(Me.ForeColor, 1)
            pevent.Graphics.DrawPath(pen, path)
        End Using
    End Sub
End Class
