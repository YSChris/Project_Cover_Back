using System;
namespace Cover_WebApi.Models
{
    public partial class WarningBill
    { 
        public string F_Id { get; set; }
        public string bill_num { get; set; }
        //0:待处理 1：接单 2：完成
        public string status { get; set; }
        public DateTime warning_date { get; set; }
        public string warning_type { get; set; }
        public string code { get; set; }
        public string name { get; set; }

    }
}
