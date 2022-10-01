using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Invitation
    {
        public bool IsActive { get; set; } = false;
        public User? Sender { get; set; }
        public User? Receiver { get; set; }
        public Marathon? Marathon { get; set; }

        public Invitation(User? sender, User? receiver, Marathon? marathon)
        {
            IsActive = true;
            Sender = sender;
            Receiver = receiver;
            Marathon = marathon;
        }
    }
}
