using System;
using System.Collections.Generic;
using System.Text;

namespace Priceline.Models
{
   public class BankDetail
    {


        public int bank_id { get; set; }
        public string user_id { get; set; }
        public string acc_holder { get; set; }
        public Nullable<int> phone_no { get; set; }
        public Nullable<int> acc_no { get; set; }
        public Nullable<int> card_no { get; set; }
        public string acc_Type { get; set; }
        public Nullable<int> branch_no { get; set; }
        public Nullable<int> cvv { get; set; }
        public string exp_Date { get; set; }
        public string bank_Name { get; set; }
    }
}
