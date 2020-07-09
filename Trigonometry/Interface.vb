'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Drawing
Imports System.Math
Imports System.Windows.Forms

'This module contains this program's main interface window.
Public Class InterfaceWindow
   Private GraphicsO As New Bitmap(My.Computer.Screen.WorkingArea.Width, My.Computer.Screen.WorkingArea.Height) 'Contains this window's graphics.

   'This procedure initializes this window.
   Public Sub New()
      Try
         InitializeComponent()

         My.Application.ChangeCulture("en-US")

         With My.Computer.Screen.WorkingArea
            Me.Size = New Size(CInt(.Width / 1.1), CInt(.Height / 1.1))
         End With

         With My.Application.Info
            Me.Text = $"{ .Title} v{ .Version} - by: { .CompanyName}"
         End With

         Me.BackgroundImage = GraphicsO

         DrawGraphics(OppositeX:=CInt(Me.ClientSize.Width / 2), OppositeY:=CInt(Me.ClientSize.Height / 2))
      Catch ExceptionO As Exception
         MessageBox.Show(ExceptionO.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   'This procedure handles the user's mouse clicks.
   Private Sub Form_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
      Try
         DrawGraphics(OppositeX:=e.X, OppositeY:=e.Y)
      Catch ExceptionO As Exception
         MessageBox.Show(ExceptionO.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   'This procedure adjusts this window's objects to its new size.
   Private Sub Form_Resize(sender As Object, e As EventArgs) Handles Me.Resize
      Try
         Me.Invalidate()
      Catch ExceptionO As Exception
         MessageBox.Show(ExceptionO.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   'This procedure draws the graphics.
   Private Sub DrawGraphics(OppositeX As Integer, OppositeY As Integer)
      Try
         Dim Center As Point = New Point(CInt(Me.ClientSize.Width / 2), CInt(Me.ClientSize.Height / 2))
         Dim Opposite As Point = New Point(OppositeX - Center.X, OppositeY - Center.Y)
         Dim Hypotenuse As Double = Sqrt((Opposite.X ^ 2) + (Opposite.Y ^ 2))

         With Graphics.FromImage(GraphicsO)
            .Clear(Me.BackColor)
            .DrawLine(Pens.Green, Center.X, 0, Center.X, Me.ClientSize.Height)
            .DrawLine(Pens.Green, 0, Center.Y, Me.ClientSize.Width, Center.Y)
            .DrawLine(Pens.Red, Center.X + Opposite.X, Center.Y + Opposite.Y, Center.X + Opposite.X, Center.Y)
            .DrawLine(Pens.Yellow, Center.X + Opposite.X, Center.Y, Center.X, Center.Y)
            .DrawLine(Pens.Blue, Center.X + Opposite.X, Center.Y + Opposite.Y, Center.X, Center.Y)
            .DrawEllipse(Pens.Purple, Center.X - CInt(Abs(Hypotenuse)), Center.Y - CInt(Abs(Hypotenuse)), CInt(Abs(Hypotenuse) * 2), CInt(Abs(Hypotenuse) * 2))
         End With

         DisplayTrigonometricValues(Opposite, Hypotenuse)

         Me.Invalidate()
      Catch ExceptionO As Exception
         MessageBox.Show(ExceptionO.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   'This procedure displays the trigonometric values.
   Private Sub DisplayTrigonometricValues(Opposite As Point, Hypotenuse As Double)
      Try
         Dim MyCosine As Double = Min(Opposite.X, Hypotenuse) / Max(Opposite.X, Hypotenuse)
         Dim MySine As Double = Min(Opposite.Y, Hypotenuse) / Max(Opposite.Y, Hypotenuse)
         Dim MyTangent As Double = MySine / MyCosine
         Dim Angle As Double = Asin(MySine)

         If (MySine <= 0 AndAlso MyCosine <= 0) OrElse (MySine >= 0 AndAlso MyCosine <= 0) Then
            Angle = PI - Angle
         ElseIf MySine <= 0 AndAlso MyCosine >= 0 Then
            Angle = (PI * 2) + Angle
         ElseIf MySine >= 0 AndAlso MyCosine >= 0 Then
            Angle = Angle
         Else
            Angle = 0
         End If
         Angle = CInt(Angle * (180 / PI))
         With Graphics.FromImage(GraphicsO)

            .DrawString($"Sine: {MySine:0.00}", Me.Font, Brushes.Red, New Point(0, 0))
            .DrawString($"Cosine: {MyCosine:0.00}", Me.Font, Brushes.Yellow, New Point(0, 16))
            .DrawString($"Tangent: {MyTangent:0.00}", Me.Font, Brushes.Green, New Point(0, 32))
            .DrawString($"Hypotenuse: {CInt(Hypotenuse)}", Me.Font, Brushes.Blue, New Point(0, 48))
            .DrawString($"Opposite: {Opposite.Y}", Me.Font, Brushes.Red, New Point(0, 64))
            .DrawString($"Adjacent: {Opposite.X}", Me.Font, Brushes.Yellow, New Point(0, 80))
            .DrawString($"Angle: {Angle}", Me.Font, Brushes.Green, New Point(0, 96))
         End With
      Catch ExceptionO As Exception
         MessageBox.Show(ExceptionO.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
End Class
