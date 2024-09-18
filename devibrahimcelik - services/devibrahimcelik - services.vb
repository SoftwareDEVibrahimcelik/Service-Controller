Imports System.ServiceProcess
Public Class devibrahimcelik___services

    'YouTube: https://www.youtube.com/@devibrahimcelik/
    'Linkedin: https://www.linkedin.com/in/devibrahimcelik/
    'Patreon: https://www.patreon.com/devibrahimcelik
    Private Sub devibrahimcelik___services_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        showservices()


    End Sub


    Private Sub showservices()

        Dim services() As ServiceController = ServiceController.GetServices
        For Each svc As ServiceController In services

            ListBox1.Items.Add(svc.ServiceName)

        Next


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)  'start



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        TextBox1.Text = ListBox1.SelectedItem.ToString


        If TextBox1.Text.Contains(" - Running") Then

            TextBox1.Text = TextBox1.Text.Replace(" - Running", String.Empty)

        End If



        If TextBox1.Text.Contains(" - Stopped") Then

            TextBox1.Text = TextBox1.Text.Replace(" - Stopped", String.Empty)

        End If





    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick



        Me.Text = (Guid.NewGuid.ToString() & Guid.NewGuid.ToString).Replace("-", "").Substring(0, 10).ToUpper
        startservicebutton.Text = (Guid.NewGuid.ToString() & Guid.NewGuid.ToString).Replace("-", "").Substring(0, 10).ToUpper
        stopservicebutton.Text = (Guid.NewGuid.ToString() & Guid.NewGuid.ToString).Replace("-", "").Substring(0, 10).ToUpper
        refreshbutton.Text = (Guid.NewGuid.ToString() & Guid.NewGuid.ToString).Replace("-", "").Substring(0, 10).ToUpper
        Switch1.Text = (Guid.NewGuid.ToString() & Guid.NewGuid.ToString).Replace("-", "").Substring(0, 10).ToUpper

        Label1.Text = (Guid.NewGuid.ToString() & Guid.NewGuid.ToString).Replace("-", "").Substring(0, 10).ToUpper
        Label2.Text = (Guid.NewGuid.ToString() & Guid.NewGuid.ToString).Replace("-", "").Substring(0, 10).ToUpper
        Label3.Text = (Guid.NewGuid.ToString() & Guid.NewGuid.ToString).Replace("-", "").Substring(0, 10).ToUpper


        Dim random As New Random

        Dim stringchange As Label() = {Label1, Label2, Label3}

        For Each hepsi In stringchange
            hepsi.ForeColor = Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256))
        Next



    End Sub

    Private Sub startservicebutton_Click(sender As Object, e As EventArgs) Handles startservicebutton.Click
        Dim services As New ServiceController(TextBox1.Text)

        If services.Status = ServiceControllerStatus.Stopped Or services.Status = ServiceControllerStatus.StopPending Then

            services.Start()
            services.WaitForStatus(ServiceControllerStatus.Running)

        End If

    End Sub

    Private Sub stopservicebutton_Click(sender As Object, e As EventArgs) Handles stopservicebutton.Click
        Dim services As New ServiceController(TextBox1.Text)

        If services.Status = ServiceControllerStatus.Running Then

            services.Stop()
            services.WaitForStatus(ServiceControllerStatus.Stopped)

        End If
    End Sub

    Private Sub refreshbutton_Click(sender As Object, e As EventArgs) Handles refreshbutton.Click

        showservices()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Switch1_CheckedChanged(sender As Object, e As EventArgs) Handles Switch1.CheckedChanged

        If Switch1.Checked = True Then

            ListBox1.Items.Clear()

            Dim services() As ServiceController = ServiceController.GetServices

            For Each svc As ServiceController In services

                Dim servicename As String = svc.ServiceName
                Dim servicestatus As String = svc.Status.ToString


                ListBox1.Items.Add($"{servicename} - {servicestatus}")

            Next

        End If


        If Switch1.Checked = False Then

            ListBox1.Items.Clear()

            Dim services() As ServiceController = ServiceController.GetServices

            For Each svc As ServiceController In services

                Dim servicename As String = svc.ServiceName
                Dim servicestatus As String = svc.Status.ToString


                ListBox1.Items.Add(svc.ServiceName)

            Next

        End If


    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://www.youtube.com/@devibrahimcelik/")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start("https://www.linkedin.com/in/devibrahimcelik/")

        '
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

        System.Diagnostics.Process.Start("https://www.patreon.com/devibrahimcelik")
        '
    End Sub

    Private Sub Switch2_CheckedChanged(sender As Object, e As EventArgs) Handles Switch2.CheckedChanged


        If Switch2.Checked = True Then

            Timer1.Start()


        End If

        If Switch2.Checked = False Then

            startservicebutton.Text = "Start"
            stopservicebutton.Text = "Start"
            refreshbutton.Text = "Start"
            Me.Text = "devibrahimcelik - Services"
            Label3.Text = "SHOW / HIDE STATUS"
            Label2.Text = "String Change"
            Label1.Text = "Service Status"
            Timer1.Stop()

        End If


    End Sub
End Class