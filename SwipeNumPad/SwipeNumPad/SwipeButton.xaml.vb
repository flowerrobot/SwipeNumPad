Imports PropertyChanged

<ImplementPropertyChanged>
Public Class SwipeButton
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = Me
    End Sub


    Public Shared ReadOnly TopVisibleProperty As DependencyProperty = DependencyProperty.Register("TopVisible", GetType(Boolean), GetType(SwipeButton), New FrameworkPropertyMetadata(False))
    Public Shared ReadOnly BtmVisibleProperty As DependencyProperty = DependencyProperty.Register("BtmVisible", GetType(Boolean), GetType(SwipeButton), New FrameworkPropertyMetadata(False))
    Public Shared ReadOnly LeftVisibleProperty As DependencyProperty = DependencyProperty.Register("LeftVisible", GetType(Boolean), GetType(SwipeButton), New FrameworkPropertyMetadata(False))
    Public Shared ReadOnly RightVisibleProperty As DependencyProperty = DependencyProperty.Register("RightVisible", GetType(Boolean), GetType(SwipeButton), New FrameworkPropertyMetadata(False))

    Public Shared ReadOnly DisplayButtonProperty As DependencyProperty = DependencyProperty.Register("DisplayButton", GetType(String), GetType(SwipeButton), New FrameworkPropertyMetadata(""))

    Public Shared ReadOnly InverseIconProperty As DependencyProperty = DependencyProperty.Register("InverseIcon", GetType(Boolean), GetType(SwipeButton), New FrameworkPropertyMetadata(False))

    Public Property DisplayButton As String
        Get
            Return CStr(GetValue(DisplayButtonProperty))
        End Get
        Set(value As String)
            SetValue(DisplayButtonProperty, value)
        End Set
    End Property
    Public Property InverseIcon As Boolean
        Get
            Return CBool(GetValue(InverseIconProperty))
        End Get
        Set(value As Boolean)
            SetValue(InverseIconProperty, value)
        End Set
    End Property
    Public Property KeytoSend As Key

    Public Property TopVisible As Boolean

    Public Property BtmVisible As Boolean
    Public Property LeftVisible As Boolean
    Public Property RightVisible As Boolean

    Public Property KeyAsString As String
        Get
            Try
                Return KeytoSend.ToString
            Catch ex As Exception
            End Try
            Return ""
        End Get
        Set(value As String)
            Dim Res As Key
            If [Enum].TryParse(Of Key)(value, Res) Then
                value = Res
            End If
        End Set
    End Property
    Private Sub Outer_MouseLeave(sender As Object, e As MouseEventArgs)
        Dim st As String = DisplayButton
        If st = "Enter" Then
            Forms.SendKeys.SendWait("{ENTER}")
        Else
            SendStrings.SendString(DisplayButton)
        End If

    End Sub
End Class
