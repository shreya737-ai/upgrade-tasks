using System;

namespace week6_task2
{
    // 1. Interface
    public interface INotification
    {
        void Send(string message);
    }

    // 2. Email Notification
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email Notification Sent: {message}");
        }
    }

    // 3. SMS Notification
    public class SMSNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS Notification Sent: {message}");
        }
    }

    // 4. Push Notification
    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Push Notification Sent: {message}");
        }
    }

    // 5. Factory Class
    public class NotificationFactory
    {
        public INotification CreateNotification(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("Notification type cannot be empty.");
            }

            switch (type.ToLower())
            {
                case "email":
                    return new EmailNotification();

                case "sms":
                    return new SMSNotification();

                case "push":
                    return new PushNotification();

                default:
                    throw new ArgumentException("Invalid notification type.");
            }
        }
    }

    internal class Program6
    {
        static void Main(string[] args)
        {
            try
            {
                NotificationFactory factory = new NotificationFactory();

                // Email Notification
                INotification emailNotification = factory.CreateNotification("email");
                emailNotification.Send("Welcome to our service!");

                // SMS Notification
                INotification smsNotification = factory.CreateNotification("sms");
                smsNotification.Send("Your OTP is 123456.");

                // Push Notification
                INotification pushNotification = factory.CreateNotification("push");
                pushNotification.Send("You have a new update!");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}