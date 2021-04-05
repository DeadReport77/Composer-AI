
Public Class SFX_STUDIO
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

    Private Sub SFX_STUDIO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.Main, AudioPlayMode.Background)
    End Sub
End Class