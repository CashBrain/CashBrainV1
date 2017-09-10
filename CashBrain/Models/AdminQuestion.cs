using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashBrain.Models
{
    public class AdminQuestion
    {
        public string Question { get; set; }
        public string ID { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public string CorrectAnswers { get; set; }
        public List<AdminQuestion> ShowallQuestion { get; set; }
    }
    
}

