using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Cover_WebApi.Models;

namespace Cover_WebApi.Models
{
    public class BrokenBill_Dbcontext : DbContext
    {
        public BrokenBill_Dbcontext()
        {
        }

        public BrokenBill_Dbcontext(DbContextOptions<BrokenBill_Dbcontext> options)
           : base(options)
        {
        }

        public virtual DbSet<BrokenBill> BrokenBill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<BrokenBill>(entity =>
            {
                entity.HasKey(e => e.F_Id);

                entity.ToTable("VW_BreakDownBill");
                entity.Property(e => e.F_Id).HasColumnName("F_Id");
                entity.Property(e => e.bill_num).HasColumnName("工单号");
                entity.Property(e => e.status).HasColumnName("工单状态");
                entity.Property(e => e.warning_date).HasColumnName("告警日期");
                entity.Property(e => e.warning_reason).HasColumnName("告警原因");
                entity.Property(e => e.code).HasColumnName("序列号");
                entity.Property(e => e.name).HasColumnName("名称");
            });
        }
    }
}
