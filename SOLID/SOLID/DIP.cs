using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class DIP
    {
        public class Email
        {
            public void Send()
            {
                // код для отправки email-письма
            }
        }

        // Уведомление
        public class Notification
        {
            private Email email;
            public Notification()
            {
                email = new Email();
            }

            public void EmailDistribution()
            {
                email.Send();
            }
        }
        //решение

        public interface IMessenger1
        {
            void Send();
        }

        public class Email1 : IMessenger1
        {
            public void Send()
            {
                // код для отправки email-письма
            }
        }

        public class SMS : IMessenger1
        {
            public void Send()
            {
                // код для отправки SMS
            }
        }

        // Уведомление
        public class Notification1
        {
            private IMessenger1 _messenger;
            public Notification1()
            {
                _messenger = new Email1();
            }

            public void DoNotify()
            {
                _messenger.Send();
            }
        }
    }
}
