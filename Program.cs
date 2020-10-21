using System;
using System.Collections.Generic;
using System.Linq;

namespace modul_c_
{
    class Program
    {
        static void Main(string[] args)
        {
            var ex = MessageFunctions.getInstence();
            var exam = new Message("teeext", "0951607142", "0564589456", new TimeSpan(), new DateTime(2020, 10, 4));
            var exam2 = new Message("teeeeeext", "0951607142", "0564589459", new TimeSpan(), new DateTime(2010, 10, 4));
            var exam3 = new Message("teeeeaaaaaaaaaaeext", "0951607142", "0564589459", new TimeSpan(), new DateTime(2012, 10, 4));
            ex.NewMessage(exam);
            ex.NewMessage(exam2);
            ex.NewMessage(exam3);
            ex.Output("0564589459");
            Console.WriteLine("///////////////////////////////");
            ex.Print();
            ex.DeleteMessages(new DateTime(2011, 4, 6));
            Console.WriteLine("///////////////////////////////");
            ex.Print();

        }
    }

    class Message
    {
        public string text, senderPhone, recipientPhone;
        public TimeSpan time;
        public DateTime date;
        public Message(string text, string senderPhone, string recipientPhone, TimeSpan time, DateTime date)
        {
            this.text = text;
            this.senderPhone = senderPhone;
            this.recipientPhone = recipientPhone;
            this.time = time;
            this.date = date;
        }

        public void toConsole()
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", this.text, this.senderPhone, this.recipientPhone, this.time, this.date);
        }
    }

    class MessageFunctions
    {
        public List<Message> allMessages = new List<Message>();
        private static MessageFunctions _instance = null;
        private MessageFunctions() { }
        public static MessageFunctions getInstence()
        {
            if (_instance == null)
            {
                return _instance = new MessageFunctions();
            }
            return new MessageFunctions();
        }
        public void NewMessage(Message message)
        {
            this.allMessages.Add(message);
        }

        public void Output(string recipient)
        {
            var newList = this.allMessages.Where(e => e.recipientPhone == recipient);
            foreach (var e in newList)
            {
                e.toConsole();
            }
        }

        public void DeleteMessages(DateTime date)
        {
            var newList = this.allMessages.Where(e => e.date > date);
            this.allMessages = new List<Message>();
            foreach (var e in newList)
            {
                this.allMessages.Add(e);
            }
        }

        public void Print()
        {
            foreach (var e in this.allMessages)
            {
                e.toConsole();
            }
        }
    }
}
