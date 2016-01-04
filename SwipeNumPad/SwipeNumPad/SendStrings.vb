Imports System.Runtime.InteropServices

Module SendStrings
    ''' <summary>
    ''' Synthesizes keystrokes corresponding to the specified Unicode string,
    ''' sending them to the currently active window.
    ''' </summary>
    ''' <param name="s">The string to send.</param>
    Public Sub SendString(s As String)
        ' Construct list of inputs in order to send them through a single SendInput call at the end.
        Dim inputs As New List(Of INPUT)()

        ' Loop through each Unicode character in the string.
        For Each ch As Char In s
            ' First send a key down, then a key up.
            For Each keyUp As Boolean In New Boolean() {False, True}
                ' INPUT is a multi-purpose structure which can be used 
                ' for synthesizing keystrokes, mouse motions, and button clicks.
                ' Need a keyboard event.
                ' KEYBDINPUT will contain all the information for a single keyboard event
                ' (more precisely, for a single key-down or key-up).
                ' Virtual-key code must be 0 since we are sending Unicode characters.

                ' The Unicode character to be sent.

                ' Indicate that we are sending a Unicode character.
                ' Also indicate key-up on the second iteration.

                Dim input As New INPUT() With {
                .type = INPUT_KEYBOARD,
                .u = New InputUnion() With {
                    .ki = New KEYBDINPUT() With {
                        .wVk = 0,
                        .wScan = AscW(ch),
                        .dwFlags = KEYEVENTF_UNICODE Or (If(keyUp, KEYEVENTF_KEYUP, 0)),
                        .dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
                ' Add to the list (to be sent later).
                inputs.Add(input)
            Next
        Next

        ' Send all inputs together using a Windows API call.
        SendInput(CUInt(inputs.Count), inputs.ToArray(), Marshal.SizeOf(GetType(INPUT)))
    End Sub
    ''http://www.codeproject.com/Articles/18366/Sending-Keystrokes-to-another-Application-in-C
    'Public Sub SendKey(iKey As Key)

    '    Dim foregroundWindowHandle As Integer = GetForegroundWindow()
    '    Dim remoteThreadId As UInteger = GetWindowThreadProcessId(foregroundWindowHandle, 0)
    '    Dim currentThreadId As UInteger = GetCurrentThreadId()
    '    Dim b As Boolean = AttachThreadInput(remoteThreadId, currentThreadId, True)
    '    Dim focused As Integer = GetFocus()
    '    Dim d As Integer = System.Runtime.InteropServices.Marshal.GetLastWin32Error()
    '    b = AttachThreadInput(remoteThreadId, currentThreadId, False)
    '    SendMessage(focused, WM_GETTEXT, builder.Capacity, builder)
    '    clip = builder.ToString()

    '    'Text operations...

    '    SendMessage(focused, WM_SETTEXT, 0, builder)


    '    SendMessage(AppHandle, WM_KEYDOWN, 0, Integer(PChar(#13)))
    '    SendMessage(AppHandle, WM_KEYUP, 0, Integer(PChar(#13)))


    '    PostMessage(AppHandle, WM_KEYDOWN, VK_RETURN, 0)
    'End Sub


    Const INPUT_MOUSE As Integer = 0
    Const INPUT_KEYBOARD As Integer = 1
    Const INPUT_HARDWARE As Integer = 2
    Const KEYEVENTF_EXTENDEDKEY As UInteger = &H1
    Const KEYEVENTF_KEYUP As UInteger = &H2
    Const KEYEVENTF_UNICODE As UInteger = &H4
    Const KEYEVENTF_SCANCODE As UInteger = &H8
    Const XBUTTON1 As UInteger = &H1
    Const XBUTTON2 As UInteger = &H2
    Const MOUSEEVENTF_MOVE As UInteger = &H1
    Const MOUSEEVENTF_LEFTDOWN As UInteger = &H2
    Const MOUSEEVENTF_LEFTUP As UInteger = &H4
    Const MOUSEEVENTF_RIGHTDOWN As UInteger = &H8
    Const MOUSEEVENTF_RIGHTUP As UInteger = &H10
    Const MOUSEEVENTF_MIDDLEDOWN As UInteger = &H20
    Const MOUSEEVENTF_MIDDLEUP As UInteger = &H40
    Const MOUSEEVENTF_XDOWN As UInteger = &H80
    Const MOUSEEVENTF_XUP As UInteger = &H100
    Const MOUSEEVENTF_WHEEL As UInteger = &H800
    Const MOUSEEVENTF_VIRTUALDESK As UInteger = &H4000
    Const MOUSEEVENTF_ABSOLUTE As UInteger = &H8000

    Private Structure INPUT
        Public type As Integer
        Public u As InputUnion
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Private Structure InputUnion
        <FieldOffset(0)>
        Public mi As MOUSEINPUT
        <FieldOffset(0)>
        Public ki As KEYBDINPUT
        <FieldOffset(0)>
        Public hi As HARDWAREINPUT
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure MOUSEINPUT
        Public dx As Integer
        Public dy As Integer
        Public mouseData As UInteger
        Public dwFlags As UInteger
        Public time As UInteger
        Public dwExtraInfo As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure KEYBDINPUT
        'Virtual Key code.  Must be from 1-254.  If the dwFlags member specifies KEYEVENTF_UNICODE, wVk must be 0.

        Public wVk As UShort
        'A hardware scan code for the key. If dwFlags specifies KEYEVENTF_UNICODE, wScan specifies a Unicode character which is to be sent to the foreground application.

        Public wScan As UShort
        'Specifies various aspects of a keystroke.  See the KEYEVENTF_ constants for more information.

        Public dwFlags As UInteger
        'The time stamp for the event, in milliseconds. If this parameter is zero, the system will provide its own time stamp.

        Public time As UInteger
        'An additional value associated with the keystroke. Use the GetMessageExtraInfo function to obtain this information.

        Public dwExtraInfo As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure HARDWAREINPUT
        Public uMsg As UInteger
        Public wParamL As UShort
        Public wParamH As UShort
    End Structure

    <DllImport("user32.dll")>
    Private Function GetMessageExtraInfo() As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Function SendInput(nInputs As UInteger, pInputs As INPUT(), cbSize As Integer) As UInteger
    End Function

    '=======================================================
    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================
End Module
