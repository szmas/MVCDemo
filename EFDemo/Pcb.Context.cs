﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFDemo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PcbEntities : DbContext
    {
        public PcbEntities()
            : base("name=PcbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<chen_add> chen_add { get; set; }
        public virtual DbSet<chen_moban> chen_moban { get; set; }
        public virtual DbSet<dt_Administrator> dt_Administrator { get; set; }
        public virtual DbSet<dt_Article> dt_Article { get; set; }
        public virtual DbSet<dt_Bannner> dt_Bannner { get; set; }
        public virtual DbSet<dt_Channel> dt_Channel { get; set; }
        public virtual DbSet<dt_Contents> dt_Contents { get; set; }
        public virtual DbSet<dt_Downloads> dt_Downloads { get; set; }
        public virtual DbSet<dt_Feedback> dt_Feedback { get; set; }
        public virtual DbSet<dt_FriendshipLink> dt_FriendshipLink { get; set; }
        public virtual DbSet<dt_Links> dt_Links { get; set; }
        public virtual DbSet<dt_Member> dt_Member { get; set; }
        public virtual DbSet<dt_PageType> dt_PageType { get; set; }
        public virtual DbSet<dt_Pictures> dt_Pictures { get; set; }
        public virtual DbSet<dt_ProductFeedback> dt_ProductFeedback { get; set; }
        public virtual DbSet<dt_productkey> dt_productkey { get; set; }
        public virtual DbSet<dt_quest> dt_quest { get; set; }
        public virtual DbSet<dt_SinglePage> dt_SinglePage { get; set; }
        public virtual DbSet<dt_SystemLog> dt_SystemLog { get; set; }
        public virtual DbSet<dt_TemplateModel> dt_TemplateModel { get; set; }
        public virtual DbSet<dt_video> dt_video { get; set; }
        public virtual DbSet<dt_webset> dt_webset { get; set; }
        public virtual DbSet<dt_Job> dt_Job { get; set; }
        public virtual DbSet<dt_Module> dt_Module { get; set; }
        public virtual DbSet<dt_PicturesLink> dt_PicturesLink { get; set; }
        public virtual DbSet<dt_Product> dt_Product { get; set; }
        public virtual DbSet<dt_ProductField> dt_ProductField { get; set; }
    }
}
