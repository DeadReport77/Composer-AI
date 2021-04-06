Imports System.Speech
Imports System.Text
Imports System.Speech.Recognition
Imports System.Threading
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports NAudio.Wave
Imports System.IO
Imports NAudio
Imports NAudio.Utils


Public Class Form1
    Private waveSource As Wave.WaveIn = Nothing
    Private waveFile As Wave.WaveFileWriter = Nothing
    Private waveFileWriter As Wave.WaveFileWriter
    Dim ms As MemoryStream

    Private Sub waveSource_DataAvailable(ByVal sender As Object, ByVal e As Wave.WaveInEventArgs)
        waveFileWriter.Write(e.Buffer, 0, e.BytesRecorded)
        waveFileWriter.Flush()
    End Sub

    Private Sub waveSource_RecordingStopped(ByVal sender As Object, ByVal e As Wave.StoppedEventArgs)
        Dim fs As FileStream = File.Create(Environment.CurrentDirectory & "\Test.wav")
        ms.Seek(0, SeekOrigin.Begin)
        ms.CopyTo(fs)
    End Sub

    Private sb As New StringBuilder
    <DllImport("winmm.dll", EntryPoint:="mciSendStringW")>
    Private Shared Function mciSendStringW(<MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrCommand As String, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrReturnString As StringBuilder, ByVal uReturnLength As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function

    <DllImport("KERNEL32.DLL")> Public Shared Sub Beep(ByVal freq As Integer, ByVal dur As Integer)
    End Sub
    Dim WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine(New CultureInfo("en-UK"))
    Dim synth As New System.Speech.Synthesis.SpeechSynthesizer
    Dim Aphoric As String = "Open"
    Private SaveFileDialog1 As Object

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function
    Const WM_APPCOMMAND As UInteger = &H319
    Const APPCOMMAND_VOLUME_UP As UInteger = &HA
    Const APPCOMMAND_VOLUME_DOWN As UInteger = &H9
    Const APPCOMMAND_VOLUME_MUTE As UInteger = &H8

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        waveSource = New Wave.WaveIn
        AddHandler waveSource.DataAvailable, AddressOf waveSource_DataAvailable
        AddHandler waveSource.RecordingStopped, AddressOf waveSource_RecordingStopped

        Me.Text = "Sound recorder via output"
        Button2.Enabled = False

        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        Dim gram As New Recognition.SrgsGrammar.SrgsDocument
        Dim colorRule As New Recognition.SrgsGrammar.SrgsRule("command")
        Dim colorsList As New Recognition.SrgsGrammar.SrgsOneOf("INCREASE VOLUME", "DECREASE VOLUME", "MUTE VOLUME")
        colorRule.Add(colorsList)
        gram.Rules.Add(colorRule)
        gram.Root = colorRule
        rec.LoadGrammar(New Recognition.Grammar(gram))
        rec.SetInputToDefaultAudioDevice()
        rec.RecognizeAsync(RecognizeMode.Multiple)
    End Sub

    Private Sub GotSpeech(ByVal sender As System.Object, ByVal phrase As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        Select Case phrase.Result.Text

            Case "INCREASE VOLUME"
                Dim arr As Integer() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
                Dim i As Integer
                For Each i In arr
                    SendMessage(Me.Handle, WM_APPCOMMAND, &H30292, APPCOMMAND_VOLUME_UP * &H10000)
                Next i
                Thread.Sleep(2000)

            Case "DECREASE VOLUME"
                Dim arr As Integer() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
                Dim i As Integer
                For Each i In arr
                    SendMessage(Me.Handle, WM_APPCOMMAND, &H30292, APPCOMMAND_VOLUME_DOWN * &H10000)
                Next i
                Thread.Sleep(2000)

            Case "MUTE VOLUME"
                SendMessage(Me.Handle, WM_APPCOMMAND, &H200EB0, APPCOMMAND_VOLUME_MUTE * &H10000)
                Thread.Sleep(2000)

        End Select

    End Sub
    Private Sub speechy(x As String)
        synth.SpeakAsync(x)
    End Sub

    Private Sub Play_KeyDown(ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles Btn1.KeyDown, Btn2.KeyDown, Btn3.KeyDown,
        Btn4.KeyDown, Btn5.KeyDown, Btn6.KeyDown,
        Btn7.KeyDown, Btn8.KeyDown, Btn9.KeyDown,
        Btn10.KeyDown, Btn11.KeyDown, Btn13.KeyDown,
        Btn14.KeyDown, Btn15.KeyDown, Btn16.KeyDown,
        Btn17.KeyDown, Btn18.KeyDown, Btn19.KeyDown,
        Btn20.KeyDown, Btn21.KeyDown, Btn22.KeyDown,
        Btn23.KeyDown, Btn24.KeyDown, Btn25.KeyDown,
        Btn26.KeyDown, Btn27.KeyDown, Btn28.KeyDown,
        Btn29.KeyDown, Btn30.KeyDown, Btn31.KeyDown,
        Btn32.KeyDown, Btn33.KeyDown, Btn34.KeyDown,
        Btn35.KeyDown, Btn36.KeyDown, Btn37.KeyDown,
        Btn38.KeyDown, Btn39.KeyDown, Btn40.KeyDown,
        Btn41.KeyDown, Me.KeyDown

        Me.Focus()

        Select Case e.KeyData.ToString()
            Case "Q"
                Btn1.PerformClick()
            Case "W"
                Btn2.PerformClick()
            Case "E"
                Btn3.PerformClick()
            Case "R"
                Btn4.PerformClick()
            Case "T"
                Btn5.PerformClick()
            Case "Y"
                Btn6.PerformClick()
            Case "U"
                Btn7.PerformClick()
            Case "I"
                Btn8.PerformClick()
            Case "O"
                Btn9.PerformClick()
            Case "P"
                Btn10.PerformClick()
            Case "A"
                Btn11.PerformClick()
            Case "S"
                Btn12.PerformClick()
            Case "D"
                Btn13.PerformClick()
            Case "F"
                Btn14.PerformClick()
            Case "G"
                Btn15.PerformClick()
            Case "H"
                Btn16.PerformClick()
            Case "J"
                Btn17.PerformClick()
            Case "K"
                Btn18.PerformClick()
            Case "L"
                Btn19.PerformClick()
            Case "Z"
                Btn20.PerformClick()
            Case "X"
                Btn21.PerformClick()
            Case "C"
                Btn22.PerformClick()
            Case "V"
                Btn23.PerformClick()
            Case "B"
                Btn24.PerformClick()
            Case "N"
                Btn25.PerformClick()
            Case "M"
                Btn26.PerformClick()
            Case "D1"
                Btn27.PerformClick()
            Case "D2"
                Btn27.PerformClick()
            Case "D3"
                Btn28.PerformClick()
            Case "D4"
                Btn29.PerformClick()
            Case "D5"
                Btn30.PerformClick()
            Case "D6"
                Btn31.PerformClick()
            Case "D7"
                Btn32.PerformClick()
            Case "D8"
                Btn33.PerformClick()
            Case "D9"
                Btn34.PerformClick()
            Case "D0"
                Btn35.PerformClick()
            Case "OemMinus"
                Btn36.PerformClick()

        End Select

    End Sub

    Private Sub Btn1_Click(sender As Object, e As EventArgs) Handles Btn1.Click
        My.Computer.Audio.Play(My.Resources.c1, AudioPlayMode.Background)
    End Sub

    Private Sub Btn2_Click(sender As Object, e As EventArgs) Handles Btn2.Click
        My.Computer.Audio.Play(My.Resources.d1, AudioPlayMode.Background)
    End Sub

    Private Sub Btn3_Click(sender As Object, e As EventArgs) Handles Btn3.Click
        My.Computer.Audio.Play(My.Resources.e1, AudioPlayMode.Background)
    End Sub

    Private Sub Btn4_Click(sender As Object, e As EventArgs) Handles Btn4.Click
        My.Computer.Audio.Play(My.Resources.f1, AudioPlayMode.Background)
    End Sub

    Private Sub Btn5_Click(sender As Object, e As EventArgs) Handles Btn5.Click
        My.Computer.Audio.Play(My.Resources.g1, AudioPlayMode.Background)
    End Sub

    Private Sub Btn6_Click(sender As Object, e As EventArgs) Handles Btn6.Click
        My.Computer.Audio.Play(My.Resources.a1, AudioPlayMode.Background)
    End Sub

    Private Sub Btn7_Click(sender As Object, e As EventArgs) Handles Btn7.Click
        My.Computer.Audio.Play(My.Resources.b1, AudioPlayMode.Background)
    End Sub

    Private Sub Btn8_Click(sender As Object, e As EventArgs) Handles Btn8.Click
        My.Computer.Audio.Play(My.Resources.c2, AudioPlayMode.Background)
    End Sub

    Private Sub Btn9_Click(sender As Object, e As EventArgs) Handles Btn9.Click
        My.Computer.Audio.Play(My.Resources.d2, AudioPlayMode.Background)
    End Sub

    Private Sub Btn10_Click(sender As Object, e As EventArgs) Handles Btn10.Click
        My.Computer.Audio.Play(My.Resources.e2, AudioPlayMode.Background)
    End Sub

    Private Sub Btn11_Click(sender As Object, e As EventArgs) Handles Btn11.Click
        My.Computer.Audio.Play(My.Resources.f2, AudioPlayMode.Background)
    End Sub

    Private Sub Btn12_Click(sender As Object, e As EventArgs) Handles Btn12.Click
        My.Computer.Audio.Play(My.Resources.g2, AudioPlayMode.Background)
    End Sub

    Private Sub Btn13_Click(sender As Object, e As EventArgs) Handles Btn13.Click
        My.Computer.Audio.Play(My.Resources.a2, AudioPlayMode.Background)
    End Sub

    Private Sub Btn14_Click(sender As Object, e As EventArgs) Handles Btn14.Click
        My.Computer.Audio.Play(My.Resources.b2, AudioPlayMode.Background)
    End Sub

    Private Sub Btn15_Click(sender As Object, e As EventArgs) Handles Btn15.Click
        My.Computer.Audio.Play(My.Resources.c3, AudioPlayMode.Background)
    End Sub

    Private Sub Btn16_Click(sender As Object, e As EventArgs) Handles Btn16.Click
        My.Computer.Audio.Play(My.Resources.d3, AudioPlayMode.Background)
    End Sub

    Private Sub Btn17_Click(sender As Object, e As EventArgs) Handles Btn17.Click
        My.Computer.Audio.Play(My.Resources.e3, AudioPlayMode.Background)
    End Sub

    Private Sub Btn18_Click(sender As Object, e As EventArgs) Handles Btn18.Click
        My.Computer.Audio.Play(My.Resources.f3, AudioPlayMode.Background)
    End Sub

    Private Sub Btn19_Click(sender As Object, e As EventArgs) Handles Btn19.Click
        My.Computer.Audio.Play(My.Resources.g3, AudioPlayMode.Background)
    End Sub

    Private Sub Btn20_Click(sender As Object, e As EventArgs) Handles Btn20.Click
        My.Computer.Audio.Play(My.Resources.a3, AudioPlayMode.Background)
    End Sub

    Private Sub Btn21_Click(sender As Object, e As EventArgs) Handles Btn21.Click
        My.Computer.Audio.Play(My.Resources.b3, AudioPlayMode.Background)
    End Sub

    Private Sub Btn22_Click(sender As Object, e As EventArgs) Handles Btn22.Click
        My.Computer.Audio.Play(My.Resources.C_1, AudioPlayMode.Background)
    End Sub

    Private Sub Btn23_Click(sender As Object, e As EventArgs) Handles Btn23.Click
        My.Computer.Audio.Play(My.Resources.D_1, AudioPlayMode.Background)
    End Sub

    Private Sub Btn24_Click(sender As Object, e As EventArgs) Handles Btn24.Click
        My.Computer.Audio.Play(My.Resources.F_1, AudioPlayMode.Background)
    End Sub

    Private Sub Btn25_Click(sender As Object, e As EventArgs) Handles Btn25.Click
        My.Computer.Audio.Play(My.Resources.G_1, AudioPlayMode.Background)
    End Sub

    Private Sub Btn26_Click(sender As Object, e As EventArgs) Handles Btn26.Click
        My.Computer.Audio.Play(My.Resources.A_1, AudioPlayMode.Background)
    End Sub

    Private Sub Btn27_Click(sender As Object, e As EventArgs) Handles Btn27.Click
        My.Computer.Audio.Play(My.Resources.C_2, AudioPlayMode.Background)
    End Sub

    Private Sub Btn28_Click(sender As Object, e As EventArgs) Handles Btn28.Click
        My.Computer.Audio.Play(My.Resources.D_2, AudioPlayMode.Background)
    End Sub

    Private Sub Btn29_Click(sender As Object, e As EventArgs) Handles Btn29.Click
        My.Computer.Audio.Play(My.Resources.F_2, AudioPlayMode.Background)
    End Sub

    Private Sub Btn30_Click(sender As Object, e As EventArgs) Handles Btn30.Click
        My.Computer.Audio.Play(My.Resources.G_2, AudioPlayMode.Background)
    End Sub

    Private Sub Btn31_Click(sender As Object, e As EventArgs) Handles Btn31.Click
        My.Computer.Audio.Play(My.Resources.A_2, AudioPlayMode.Background)
    End Sub

    Private Sub Btn32_Click(sender As Object, e As EventArgs) Handles Btn32.Click
        My.Computer.Audio.Play(My.Resources.C_3, AudioPlayMode.Background)
    End Sub

    Private Sub Btn33_Click(sender As Object, e As EventArgs) Handles Btn33.Click
        My.Computer.Audio.Play(My.Resources.D_3, AudioPlayMode.Background)
    End Sub

    Private Sub Btn34_Click(sender As Object, e As EventArgs) Handles Btn34.Click
        My.Computer.Audio.Play(My.Resources.F_3, AudioPlayMode.Background)
    End Sub

    Private Sub Btn35_Click(sender As Object, e As EventArgs) Handles Btn35.Click
        My.Computer.Audio.Play(My.Resources.G_3, AudioPlayMode.Background)
    End Sub

    Private Sub Btn36_Click(sender As Object, e As EventArgs) Handles Btn36.Click
        My.Computer.Audio.Play(My.Resources.A_3, AudioPlayMode.Background)
    End Sub

    Private Sub Btn37_Click(sender As Object, e As EventArgs) Handles Btn37.Click

    End Sub

    Private Sub Btn38_Click(sender As Object, e As EventArgs) Handles Btn38.Click

    End Sub

    Private Sub Btn39_Click(sender As Object, e As EventArgs) Handles Btn39.Click

    End Sub

    Private Sub Btn40_Click(sender As Object, e As EventArgs) Handles Btn40.Click
        SFX_STUDIO.Show()
        Me.Hide()
    End Sub

    Private Sub Btn41_Click(sender As Object, e As EventArgs) Handles Btn41.Click

    End Sub

    Private Sub BtnClose1_Click(sender As Object, e As EventArgs) Handles BtnClose1.Click
        Application.Exit()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ms = New MemoryStream()
        waveFileWriter = New Wave.WaveFileWriter(New IgnoreDisposeStream(ms), waveSource.WaveFormat)
        waveSource.StartRecording()
        Button2.Enabled = True
        Button1.Enabled = False
        mciSendStringW("open new Type waveaudio Alias capture", sb, 0, IntPtr.Zero)
        mciSendStringW("set capture time format ms bitspersample 16 channels 2 samplespersec 48000 bytespersec 192000 alignment 4", Nothing, 0, IntPtr.Zero)
        'mciSendStringW("record capture", sb, 0, IntPtr.Zero)
        mciSendStringW("record capture", Nothing, 0, IntPtr.Zero)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        mciSendStringW("stop capture", sb, 0, IntPtr.Zero)
        Using sfd As New SaveFileDialog
            sfd.FileName = "Untitled"
            sfd.DefaultExt = "wav"
            sfd.AddExtension = True
            sfd.InitialDirectory = "C:\Users\Leeraoy.Jenkins\Desktop"
            If sfd.ShowDialog = DialogResult.OK Then
                Button2.Enabled = False
                Dim saveas As String = Chr(34) & sfd.FileName & Chr(34)
                'mciSendStringW("save capture " & saveas, sb, 0, IntPtr.Zero)
                mciSendStringW("save capture " & saveas, Nothing, 0, IntPtr.Zero)
            End If
        End Using
        mciSendStringW("close capture", sb, 0, IntPtr.Zero)
        Button2.Enabled = False
        Button1.Enabled = True
        waveSource.StopRecording()
    End Sub
End Class
