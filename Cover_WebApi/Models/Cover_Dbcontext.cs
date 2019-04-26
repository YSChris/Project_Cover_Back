using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cover_WebApi.Models
{
    public class Cover_Dbcontext : DbContext
    {
        public Cover_Dbcontext()
        {
        }

        public Cover_Dbcontext(DbContextOptions<Cover_Dbcontext> options)
           : base(options)
        {
        }

        public virtual DbSet<CoverInfo> CoverInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<CoverInfo>(entity =>
            {
                entity.HasKey(e => e.F_Id);

                entity.ToTable("VW_CoverInfo");

                entity.Property(e => e.F_Id).HasColumnName("F_Id");
                entity.Property(e => e.F_DeviceId).HasColumnName("F_DeviceId");
                entity.Property(e => e.F_AreaId).HasColumnName("F_AreaId");
                entity.Property(e => e.F_PointX).HasColumnName("F_PointX");
                entity.Property(e => e.F_PointY).HasColumnName("F_PointY");
                entity.Property(e => e.Area).HasColumnName("区域");
                entity.Property(e => e.SaleCenter).HasColumnName("营销中心");
                entity.Property(e => e.code).HasColumnName("序列号");
                entity.Property(e => e.name).HasColumnName("名称");
                entity.Property(e => e.install_address).HasColumnName("安装地址");
                entity.Property(e => e.address_des).HasColumnName("地址描述");
                entity.Property(e => e.size).HasColumnName("尺寸");
                entity.Property(e => e.demension).HasColumnName("规格");
                entity.Property(e => e.short_name).HasColumnName("简称");
                entity.Property(e => e.status).HasColumnName("状态");
                entity.Property(e => e.company).HasColumnName("公司");
                entity.Property(e => e.factory_name).HasColumnName("厂家名称");
                entity.Property(e => e.IMSI).HasColumnName("IMSI码");
                entity.Property(e => e.phone_num).HasColumnName("手机号");
                entity.Property(e => e.board_num).HasColumnName("板号");
                entity.Property(e => e.device_type).HasColumnName("设备类型");
                entity.Property(e => e.lock_num).HasColumnName("锁号");
                entity.Property(e => e.newest_contart).HasColumnName("最新通讯方式");
                entity.Property(e => e.newest_uploadTime).HasColumnName("最新上报时间");
                entity.Property(e => e.init_time).HasColumnName("创建时间");
                entity.Property(e => e.cover_status).HasColumnName("井盖状态");
                entity.Property(e => e.lock_status).HasColumnName("锁状态");
                entity.Property(e => e.online_status).HasColumnName("在线状态");
                entity.Property(e => e.upload_status).HasColumnName("上报状态");
                entity.Property(e => e.warning_type).HasColumnName("告警类型");
                entity.Property(e => e.report_type).HasColumnName("报告类型");
                entity.Property(e => e.report_status).HasColumnName("报告状态");
                entity.Property(e => e.vol).HasColumnName("电压");
                entity.Property(e => e.vol_status).HasColumnName("电量状态");
                entity.Property(e => e.signal).HasColumnName("信号");
                entity.Property(e => e.moudule_time).HasColumnName("模块时间");
                entity.Property(e => e.last_meg).HasColumnName("最后磁场");
                entity.Property(e => e.open_meg).HasColumnName("开盖磁场");
                entity.Property(e => e.close_meg).HasColumnName("关盖磁场");
                entity.Property(e => e.lable).HasColumnName("标志");
                entity.Property(e => e.raw_data).HasColumnName("原始数据");
            });
        }
    }
}
