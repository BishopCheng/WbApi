using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Entity.TableModel;

namespace ApiServer.DataContext
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class CompanySiteDataContexts:DbContext
    {
        public CompanySiteDataContexts(DbContextOptions<CompanySiteDataContexts>options):base(options)
        {


        }

        public DbSet<T_User> t_User { get; set; }  //用户表

        public DbSet<T_Role> t_Role { get; set; } //权限表

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
