using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Cover_WebApi.Models;

namespace Cover_WebApi.Models
{
    public class WarningBill_Dbcontext : DbContext
    {
        public WarningBill_Dbcontext()
        {
        }

        public WarningBill_Dbcontext(DbContextOptions<WarningBill_Dbcontext> options)
           : base(options)
        {
        }

        public virtual DbSet<WarningBill> WarningBill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<WarningBill>(entity =>
            {
                entity.HasKey(e => e.F_Id);

                entity.ToTable("VW_WarmingBill");
                entity.Property(e => e.F_Id).HasColumnName("F_Id");
                entity.Property(e => e.bill_num).HasColumnName("工单号");
                entity.Property(e => e.status).HasColumnName("工单状态");
                entity.Property(e => e.warning_date).HasColumnName("告警日期");
                entity.Property(e => e.warning_type).HasColumnName("告警类型");
                entity.Property(e => e.code).HasColumnName("序列号");
                entity.Property(e => e.name).HasColumnName("名称");
            });
        }
    }
}
