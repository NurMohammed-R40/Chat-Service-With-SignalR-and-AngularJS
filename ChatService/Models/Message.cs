using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChatService.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string MsgTime { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}