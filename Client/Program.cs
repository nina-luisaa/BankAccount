
using System;
using BankAccountModel;
using CustomerAccountBL;
using MailKit.Net.Smtp;
using MimeKit;
//
namespace new_email_tool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank!");

            Console.Write("Enter Account Number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter PIN: ");
            string pin = Console.ReadLine();

            CustomerGetServices getServices = new CustomerGetServices();

            User user = getServices.GetUser(accountNumber, pin);

            if (user != null)
            {
                Console.WriteLine($"Login Successful!\nYour Balance is: ${user.balance}");
                SendEmail();
            }
            else
            {
                Console.WriteLine("Invalid account number or PIN. Please try again.");
            }
        }

        private static void SendEmail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("BankAccount", "frommynotes.com"));
            message.To.Add(new MailboxAddress("Nina", "ninaluisa@gmail.com"));
            message.Subject = "Thank you for trusting!";

            message.Body = new TextPart("html")
            {
                Text = "<h1>Hello,have a good day!</h1>" +
                      "<p>You have been successfully open your bank account.</p>" +
                      "<p><strong>Thank You!</strong></p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("d80d41b12a5cd3", "275d1119074855");
                    client.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
