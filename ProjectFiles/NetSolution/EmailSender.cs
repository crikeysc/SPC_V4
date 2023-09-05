using FTOptix.NetLogic;
using System;
using System.Net;
using System.Net.Mail;
using UAManagedCore;
using FTOptix.SerialPort;
using FTOptix.System;
using FTOptix.EventLogger;

public class EmailSender : BaseNetLogic
{
    [ExportMethod]
    public static void SendEmail(string replyToAddress, string mailSubject, string mailBody)
    {
        if (string.IsNullOrEmpty(replyToAddress) || mailSubject == null || mailBody == null)
        {
            Log.Error("EmailSender", "Invalid values for one or more parameters.");
            return;
        }

        var fromAddress = new MailAddress("nhp.vic.ai@gmail.com", "NHP Vic"); // Email Sender
        var toAddress = new MailAddress("nhp.vic.ai@gmail.com", "NHP Vic"); // Email Receiver
        // Password for SMTP server authentication if required
        const string fromPassword = "bqqfammvwnczpxzv";

        var smtpClient = new SmtpClient
        {
            // Fill the following lines with your SMTP server info
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true, // Set to true if the server requires SSL.
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        var message = new MailMessage
        {
            // Create the message.
            Subject = mailSubject,
            Body = mailBody,
            // Specify the sender
            From = fromAddress
        };

        // Recipient emails
        // The MailMessage.To property is a collection of emails, so you can add different recipients using:
        // message.To.Add(new MailAddress(...));
        message.To.Add(toAddress);

        // Add reply-to address
        message.ReplyToList.Add(replyToAddress);

        try
        {
            // Send email message
            smtpClient.Send(message);
            Log.Info("Message " + mailSubject + " sent successfully.");
        }
        catch (Exception ex)
        {
            // Insert here actions to be performed in case of an error when sending an email
            Log.Error("Error while sending message " + mailSubject + ", please try again. " + ex.Message);
        }
    }
}
