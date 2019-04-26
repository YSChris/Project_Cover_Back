using System;
using System.Collections.Generic;

namespace Cover_WebApi.Models
{
    public partial class CoverInfo
    {
        public string F_Id { get; set; }
        public string F_DeviceId { get; set; }
        public string F_AreaId { get; set; }
        public string F_PointX { get; set; }
        public string F_PointY { get; set; }
        public string Area { get; set; }
        public string SaleCenter { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string install_address { get; set; }
        public string address_des { get; set; }
        public string size { get; set; }
        public string demension { get; set; }
        public string short_name { get; set; }
        public string status { get; set; }
        public string company { get; set; }
        public string factory_name { get; set; }
        public string IMSI { get; set; }
        public string phone_num { get; set; }
        public string board_num { get; set; }
        public string device_type { get; set; }
        public string lock_num { get; set; }
        public string newest_contart { get; set; }
        public DateTime? newest_uploadTime { get; set; }
        public DateTime? init_time { get; set; }
        public string cover_status { get; set; }
        public string lock_status { get; set; }
        public int online_status { get; set; }
        public string upload_status { get; set; }
        public string warning_type { get; set; }
        public string report_type { get; set; }
        public string report_status { get; set; }
        public string vol { get; set; }
        public string vol_status { get; set; }
        public string signal { get; set; }
        public string moudule_time { get; set; }
        public string last_meg { get; set; }
        public string open_meg { get; set; }
        public string close_meg { get; set; }
        public Boolean lable { get; set; }
        public string raw_data { get; set; }
    }
}