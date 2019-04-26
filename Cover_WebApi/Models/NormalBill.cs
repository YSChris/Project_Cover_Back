using System;
namespace Cover_WebApi.Models
{
    public partial class NormalBill
    {
        public string F_Id { get; set; }
        public string bill_num { get; set; }
        //0:待处理 1：接单 2：完成
        public string auditing { get; set; }
        public string pass { get; set; }
        public string authorize { get; set; }
        public string extend { get; set; }
        public string close { get; set; }
        public DateTime apply_date { get; set; }
        public string apply_reason { get; set; }
        public string code { get; set; }
        public string name { get; set; }

    }
}
