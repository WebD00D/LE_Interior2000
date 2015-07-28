Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Imports System.Net
Imports System.Net.Mail
Imports System.Web.UI.WebControls
Imports System.Net.Mail.SmtpClient
Imports System.Net.Mail.SmtpDeliveryFormat
Imports System.Net.Mail.SmtpDeliveryMethod
Imports System.Net.Mail.SmtpAccess
Imports System.Net.Mail.SmtpPermission
Imports System.Net.Mail.MailMessage


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
 Public Class Engine
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function SendMail(ByVal Name As String, ByVal Email As String, ByVal Message As String)

        Try
            Dim formattedbody As String = "<strong>Name:</strong>" & Name & "<br /><strong>Email:</strong>" & Email & "<br /><strong>Message:</strong>" & Message & "<br />"

            Dim smtpserver As New SmtpClient()
            With smtpserver
                .Host = "mail.pine.arvixe.com"
                .DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
                .Credentials = New Net.NetworkCredential("Mail@Interior2kva.com", "Password123!")
                .Port = 587
                .EnableSsl = False
            End With

            Dim Mail = New MailMessage()
            With Mail
                .From = New MailAddress("info@Interior2kva.com", "Interior 2000", System.Text.Encoding.UTF8)
                .Subject = "Online Mail Form"
                .ReplyToList.Add(Email)
                .IsBodyHtml = True
                .Body = formattedbody
                .To.Add("Amy@Interior2kva.com,David@Interior2kva.com")

            End With

            smtpserver.Send(Mail)


            Return 1
        Catch ex As Exception
            Return 2
        End Try


    End Function

End Class