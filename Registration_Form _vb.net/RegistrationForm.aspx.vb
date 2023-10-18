Imports System.Diagnostics.Eventing.Reader
Imports System.IO

Public Class RegistrationForm
    Inherits System.Web.UI.Page

    Private sFilePath As String = Server.MapPath("~/Rpts")
    Private sErr_Msg As String = ""
    Private sFileName As String = "UserDetails.txt"
    Private writer As StreamWriter = Nothing
    Private reader As StreamReader = Nothing

    Private sHeader As String = "Sr No.| Name | DOB | Gender | phone | Email | Course" & vbCrLf

    Private Fname As String = ""
    Private Mname As String = ""
    Private Lname As String = ""
    Private dateDob As String = ""
    Private Phone As String = ""
    Private Email As String = ""
    Private listCourse As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub fnJsAlert(ByVal sMsg As String)
        sMsg = sMsg.Replace(vbCrLf, "\n")
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "JS" + Now.Ticks.ToString, "alert('" & sMsg & "');", True)
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        Fname = Request.Form("txtFName")
        Mname = Request.Form("txtMName")
        Lname = Request.Form("txtLName")
        dateDob = Request.Form("txtdob")
        Phone = Request.Form("txtPhone")
        Email = Request.Form("txtEmail")
        listCourse = Request.Form("listCourse")

        Dim Error_Message As String = ""

        If Fname = "" Then
            Error_Message += "Kindly enter First Name\n"
        End If

        If Mname = "" Then
            Error_Message += "Kindly enter Middle Name\n"
        End If

        If Lname = "" Then
            Error_Message += "Kindly enter Last Name\n"
        End If

        If Phone = "" Then
            Error_Message += "Kindly enter phone number\n"
        End If

        If Email = "" Then
            Error_Message += "Kindly enter email id\n"
        End If

        If listCourse = "" Then
            Error_Message += "Kindly select course name\n"
        End If

        'If Not (male Or female) Then
        '    Error_Message += "Kindly choose the gender\n"
        'End If

        If Error_Message <> "" Then
            fnJsAlert(Error_Message)
        Else
            fnFormDetails()
        End If

    End Sub


    Private Function fnFormDetails() As Boolean

        Dim rbGender As String = ""

        Try
            rbGender = Request.Form("gender").ToString()
            Fname = Request.Form("txtFName")
            Mname = Request.Form("txtMName")
            Lname = Request.Form("txtLName")
            dateDob = Request.Form("txtdob")
            Phone = Request.Form("txtPhone")
            Email = Request.Form("txtEmail")
            listCourse = Request.Form("listCourse")


            Dim sData As String = ""
            Dim iSrNo As Integer = 1

            sFilePath = If(sFilePath.EndsWith("/"), sFilePath, sFilePath & "/")

            Dim sFile As String = sFilePath & sFileName

            If Not Directory.Exists(sFilePath) Then
                Directory.CreateDirectory(sFilePath)
            End If

            If File.Exists(sFile) Then
                reader = New StreamReader(sFile)
                If Not reader.EndOfStream Then
                    Dim bChkhdr As Boolean = True
                    Do While Not reader.EndOfStream
                        Dim sCurrLine As String = reader.ReadLine
                        If bChkhdr = True Then
                            If sCurrLine.Trim <> sHeader.Trim Then
                                sData = sHeader
                            End If
                            bChkhdr = False
                            Continue Do
                        End If
                        Dim sLineArr() As String = Split(sCurrLine, "|")
                        iSrNo = CInt(sLineArr(0)) + 1

                        If sLineArr(4) = Phone Then
                            fnJsAlert("Phone number is already present!")
                            reader.Close()
                            Return False
                        End If

                        If sLineArr(5) = Email Then
                            fnJsAlert("Email_id is already present!")
                            reader.Close()
                            Return False
                        End If

                    Loop
                End If
                reader.Close()
            Else
                sData = sHeader
            End If


            sData += iSrNo.ToString & "|" & Fname & " " & Mname & " " & Lname & "|" & dateDob & "|" & rbGender & "|" & Phone & "|" & Email & "|" & listCourse




            writer = New StreamWriter(sFilePath & sFileName, True)
            writer.WriteLine(sData)

            If Not writer Is Nothing Then writer.Close()
            Return True

        Catch appex As ApplicationException
            sErr_Msg = appex.Message
            Return False
        Catch ex As Exception
            sErr_Msg = ex.Message
            Return False

        Finally
            If sErr_Msg <> "" Then
                fnJsAlert(sErr_Msg)
            Else
                fnJsAlert("Data Added successfully !")
            End If

        End Try

    End Function


End Class