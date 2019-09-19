using Mystat.AdditionalClasses;
using Mystat.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.ViewModel
{
    public class ContactViewModel : BaseViewModel
    {
        public RelayCommand SendMailCommand => new RelayCommand(e =>
        {
            Network.SendMail(App.CurrentStudent.Email, subject, body);
        }, o => Body != null && Subject != null);

        public String subject { get; set; }
        public String Subject
        {
            get => subject; set
            {
                if (value == subject) return;

                subject = value;

                OnPropertyChanged();
            }
        }

        public String body { get; set; }
        public String Body
        {
            get => body; set
            {
                if (value == body) return;

                body = value;

                OnPropertyChanged();
            }
        }
    }
}
