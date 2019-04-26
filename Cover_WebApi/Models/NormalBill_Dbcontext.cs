using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Cover_WebApi.Models;

namespace Cover_WebApi.Models
{
    public class NormalBill_Dbcontext : DbContext
    {
        public NormalBill_Dbcontext()
        {
        }

        public NormalBill_Dbcontext(DbContextOptions<NormalBill_Dbcontext> options)
           : base(options)
        {
        }

        public virtual DbSet<NormalBill> NormalBill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<NormalBill>(entity =>
            {
                entity.HasKey(e => e.F_Id);

                entity.ToTable("VW_Bill");
                entity.Property(e => e.F_Id).HasColumnName("F_Id");
                entity.Property(e => e.bill_num).HasColumnName("工单号");
                entity.Property(e => e.auditing).HasColumnName("审核");
                entity.Property(e => e.pass).HasColumnName("审批");
                entity.Property(e => e.authorize).HasColumnName("审定");
                entity.Property(e => e.extend).HasColumnName("延长");
                entity.Property(e => e.close).HasColumnName("关闭");
                entity.Property(e => e.apply_date).HasColumnName("日期");
                entity.Property(e => e.apply_reason).HasColumnName("申请原因");
                entity.Property(e => e.code).HasColumnName("序列号");
                entity.Property(e => e.name).HasColumnName("名称");
            });
        }
    }
}