Imports System.Speech
Imports System.Text
Imports System.Speech.Recognition
Imports System.Threading
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports NAudio
Imports System.IO
Imports NAudio.Utils
Imports NAudio.Wave

Public Class SFX_STUDIO
    Private waveSource As Wave.WaveIn = Nothing
    Private waveFile As Wave.WaveFileWriter = Nothing
    Private waveFileWriter As Wave.WaveFileWriter
    Dim ms As MemoryStream



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


    Private Sub waveSource_DataAvailable(ByVal sender As Object, ByVal e As Wave.WaveInEventArgs)
        WaveFileWriter.Write(e.Buffer, 0, e.BytesRecorded)
        WaveFileWriter.Flush()
    End Sub

    Private Sub waveSource_RecordingStopped(ByVal sender As Object, ByVal e As Wave.StoppedEventArgs)
        Dim fs As FileStream = File.Create(Environment.CurrentDirectory & "\Test.wav")
        MS.Seek(0, SeekOrigin.Begin)
        MS.CopyTo(fs)
    End Sub



    Private sb As New StringBuilder


    <DllImport("winmm.dll", EntryPoint:="mciSendStringW")>
    Private Shared Function mciSendStringW(<MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrCommand As String, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrReturnString As StringBuilder, ByVal uReturnLength As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function

    <DllImport("KERNEL32.DLL")> Public Shared Sub Beep(ByVal freq As Integer, ByVal dur As Integer)
    End Sub



    Private Sub SFX_STUDIO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.Main, AudioPlayMode.Background)
        waveSource = New Wave.WaveIn
        AddHandler waveSource.DataAvailable, AddressOf waveSource_DataAvailable
        AddHandler waveSource.RecordingStopped, AddressOf waveSource_RecordingStopped

        Me.Text = "Sound recorder via output"
        Button2.Enabled = False

        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        Dim gram As New Recognition.SrgsGrammar.SrgsDocument
        Dim colorRule As New Recognition.SrgsGrammar.SrgsRule("command")
        Dim colorsList As New Recognition.SrgsGrammar.SrgsOneOf("INCREASE VOLUME", "DECREASE VOLUME", "MUTE VOLUME", "CLOSE STUDIO")
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

            Case "CLOSE STUDIO"
                Me.Hide()
                Form1.Show()

        End Select

    End Sub
    Private Sub speechy(x As String)
        synth.SpeakAsync(x)
    End Sub

    Private Sub Funeral1_CheckedChanged(sender As Object, e As EventArgs) Handles Funeral1.CheckedChanged
        My.Computer.Audio.Play(My.Resources.Funeral, AudioPlayMode.Background)
    End Sub

    Private Sub Forget1_CheckedChanged(sender As Object, e As EventArgs) Handles Forget1.CheckedChanged
        My.Computer.Audio.Play(My.Resources.Forgetting, AudioPlayMode.Background)
    End Sub

    Private Sub AphorTow1_CheckedChanged(sender As Object, e As EventArgs) Handles AphorTow1.CheckedChanged
        My.Computer.Audio.Play(My.Resources.Aphotic_Undertow, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        My.Computer.Audio.Play(My.Resources.WhoosherSFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        My.Computer.Audio.Play(My.Resources.Whoosher2SFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        My.Computer.Audio.Play(My.Resources.FastWhooshSFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        My.Computer.Audio.Play(My.Resources.Drum1SFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        My.Computer.Audio.Play(My.Resources.Drum2SFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        My.Computer.Audio.Play(My.Resources.Drum3SFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        My.Computer.Audio.Play(My.Resources.TensionSFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        My.Computer.Audio.Play(My.Resources.SystemDownSFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        My.Computer.Audio.Play(My.Resources.RadioScrollSFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.CheckedChanged
        My.Computer.Audio.Play(My.Resources.OverrideSFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged
        My.Computer.Audio.Play(My.Resources.LowRumbleSFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox12.CheckedChanged
        My.Computer.Audio.Play(My.Resources.EvilKeyboardSFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox13.CheckedChanged
        My.Computer.Audio.Play(My.Resources.Bell1SFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox14_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox14.CheckedChanged
        My.Computer.Audio.Play(My.Resources.Bell2SFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox15_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox15.CheckedChanged
        My.Computer.Audio.Play(My.Resources.Boom1SFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox16_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox16.CheckedChanged
        My.Computer.Audio.Play(My.Resources.DarkPassageSFX, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox17_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox17.CheckedChanged
        My.Computer.Audio.Play(My.Resources.CinematicHorror_SFX, AudioPlayMode.Background)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MS = New MemoryStream()
        WaveFileWriter = New Wave.WaveFileWriter(New IgnoreDisposeStream(MS), waveSource.WaveFormat)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form1.Show()
    End Sub
End Class