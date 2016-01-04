Imports System.Windows.Threading
Imports PropertyChanged

<ImplementPropertyChanged>
Class SwipeNumPad

    Public Property MouseIsOutside As Boolean
    Shared hHook As Integer = 0
    Dim MouseHookProcedure As HookProc

    Dim timer As DispatcherTimer
    Dim _hotKey As New HotKey(Key.Home, KeyModifier.Ctrl, AddressOf OnHotKeyHandler)
    Public Delegate Function HookProc(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As Integer
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.DataContext = Me
        ' Add any initialization after the InitializeComponent() call.
        Me.WindowStartupLocation = WindowStartupLocation.Manual

        Dim NominateLeft As Integer = Forms.Cursor.Position.X - Me.Width / 2
        Dim NominatedTop As Integer = Forms.Cursor.Position.Y - Me.Height / 2

        Dim workingArea As System.Drawing.Rectangle = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea

        If NominatedTop < workingArea.Top Then
            NominatedTop = workingArea.Top
        End If
        If NominatedTop + Me.Height > workingArea.Bottom Then
            NominatedTop = workingArea.Bottom - Me.Height
        End If
        If NominateLeft < workingArea.Left Then
            NominateLeft = workingArea.Left
        End If
        If NominateLeft + Me.Width > workingArea.Right Then
            NominateLeft = workingArea.Right
        End If

        Me.Left = NominateLeft
        Me.Top = NominatedTop

        timer = New DispatcherTimer()
        timer.Interval = TimeSpan.FromSeconds(0.05)

        AddHandler timer.Tick, AddressOf timer_Tick
        timer.Start()
    End Sub

    Protected Overrides Sub OnDeactivated(e As EventArgs)
        MyBase.OnDeactivated(e)
        Me.Hide()
    End Sub


    Private Sub timer_Tick(sender As Object, e As EventArgs)
        Dim x As Integer = System.Windows.Forms.Cursor.Position.X
        Dim y As Integer = Forms.Cursor.Position.Y

        Dim Res As Boolean = False
        'Tottally left of form.
        'Tottally right of form
        'Tottall above form
        'Tottally bellow form
        If x < Me.Left OrElse x > (Me.Left + Me.Width) Then
            Res = True
        End If

        If y < Me.Top OrElse y > (Me.Top + Me.Height) Then
            Res = True
        End If

        MouseIsOutside = Res

    End Sub

    Private Sub ExitCommand_CanExecute(sender As Object, e As CanExecuteRoutedEventArgs)
        e.CanExecute = True
    End Sub

    Private Sub ExitCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        Me.Show()
    End Sub
    Private Sub OnHotKeyHandler(hotKey As HotKey)
        Me.Show()
        Me.Focus()
    End Sub

End Class
Public NotInheritable Class CustomCommands
    Private Sub New()
    End Sub
    Public Shared ReadOnly [Exit] As New RoutedUICommand("Exit", "Exit", GetType(CustomCommands), New InputGestureCollection() From {
            New KeyGesture(Key.Q, ModifierKeys.Control)
        })

    'Define more commands here, just like the one above
End Class