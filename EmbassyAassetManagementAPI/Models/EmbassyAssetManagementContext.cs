using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmbassyAassetManagementAPI.Models;

public partial class EmbassyAssetManagementContext : DbContext
{
    public EmbassyAssetManagementContext()
    {
    }

    public EmbassyAssetManagementContext(DbContextOptions<EmbassyAssetManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Loginauditlog> Loginauditlogs { get; set; }

    public virtual DbSet<TblAssetCategory> TblAssetCategories { get; set; }

    public virtual DbSet<TblAssetRegistration> TblAssetRegistrations { get; set; }

    public virtual DbSet<TblAssetSubCategory> TblAssetSubCategories { get; set; }

    public virtual DbSet<TblAssetTransaction> TblAssetTransactions { get; set; }

    public virtual DbSet<TblCountryMaster> TblCountryMasters { get; set; }

    public virtual DbSet<TblCurrencyMaster> TblCurrencyMasters { get; set; }

    public virtual DbSet<TblDepartmentMaster> TblDepartmentMasters { get; set; }

    public virtual DbSet<TblEmbassyMaster> TblEmbassyMasters { get; set; }

    public virtual DbSet<TblMenuPerm> TblMenuPerms { get; set; }

    public virtual DbSet<TblPopupMenu> TblPopupMenus { get; set; }

    public virtual DbSet<TblRoleMaster> TblRoleMasters { get; set; }

    public virtual DbSet<TblUserMaster> TblUserMasters { get; set; }

    public virtual DbSet<TblUserRole> TblUserRoles { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Loginauditlog>(entity =>
        {
            entity.HasKey(e => e.Logid).HasName("loginauditlogs_pkey");

            entity.ToTable("loginauditlogs");

            entity.Property(e => e.Logid).HasColumnName("logid");
            entity.Property(e => e.Appname)
                .HasMaxLength(150)
                .HasColumnName("appname");
            entity.Property(e => e.Asinfo)
                .HasMaxLength(150)
                .HasColumnName("asinfo");
            entity.Property(e => e.Browserinfo)
                .HasMaxLength(300)
                .HasColumnName("browserinfo");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Countrycode)
                .HasMaxLength(20)
                .HasColumnName("countrycode");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .HasColumnName("ipaddress");
            entity.Property(e => e.Isp)
                .HasMaxLength(150)
                .HasColumnName("isp");
            entity.Property(e => e.Latitude)
                .HasMaxLength(50)
                .HasColumnName("latitude");
            entity.Property(e => e.Loggedinat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("loggedinat");
            entity.Property(e => e.Longitude)
                .HasMaxLength(50)
                .HasColumnName("longitude");
            entity.Property(e => e.Org)
                .HasMaxLength(150)
                .HasColumnName("org");
            entity.Property(e => e.Region)
                .HasMaxLength(100)
                .HasColumnName("region");
            entity.Property(e => e.Regionname)
                .HasMaxLength(100)
                .HasColumnName("regionname");
            entity.Property(e => e.Timezone)
                .HasMaxLength(100)
                .HasColumnName("timezone");
            entity.Property(e => e.Username)
                .HasMaxLength(150)
                .HasColumnName("username");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(20)
                .HasColumnName("zipcode");
        });

        modelBuilder.Entity<TblAssetCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("tbl_asset_category_pkey");

            entity.ToTable("tbl_asset_category");

            entity.HasIndex(e => e.CategoryCode, "tbl_asset_category_category_code_key").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(50)
                .HasColumnName("category_code");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(150)
                .HasColumnName("category_name");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("true")
                .HasColumnName("is_active");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<TblAssetRegistration>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("tbl_asset_registration_pkey");

            entity.ToTable("tbl_asset_registration");

            entity.HasIndex(e => e.AssetCode, "tbl_asset_registration_asset_code_key").IsUnique();

            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.AssetCode)
                .HasMaxLength(100)
                .HasColumnName("asset_code");
            entity.Property(e => e.AssetCondition)
                .HasMaxLength(50)
                .HasColumnName("asset_condition");
            entity.Property(e => e.AssetName)
                .HasMaxLength(200)
                .HasColumnName("asset_name");
            entity.Property(e => e.AssetStatus)
                .HasMaxLength(50)
                .HasColumnName("asset_status");
            entity.Property(e => e.BarcodePath)
                .HasMaxLength(200)
                .HasColumnName("barcode_path");
            entity.Property(e => e.Brand)
                .HasMaxLength(150)
                .HasColumnName("brand");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DepreciationRate)
                .HasPrecision(5, 2)
                .HasColumnName("depreciation_rate");
            entity.Property(e => e.DepreciationType)
                .HasMaxLength(50)
                .HasColumnName("depreciation_type");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EmbassyId).HasColumnName("embassy_id");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(100)
                .HasColumnName("invoice_no");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("true")
                .HasColumnName("is_active");
            entity.Property(e => e.LocationDetails).HasColumnName("location_details");
            entity.Property(e => e.ModelNumber)
                .HasMaxLength(150)
                .HasColumnName("model_number");
            entity.Property(e => e.PurchaseAmount)
                .HasPrecision(18, 2)
                .HasColumnName("purchase_amount");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(150)
                .HasColumnName("serial_number");
            entity.Property(e => e.SubcategoryId).HasColumnName("subcategory_id");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
            entity.Property(e => e.VendorName)
                .HasMaxLength(200)
                .HasColumnName("vendor_name");
            entity.Property(e => e.WarrantyEndDate).HasColumnName("warranty_end_date");
            entity.Property(e => e.WarrantyStartDate).HasColumnName("warranty_start_date");

            entity.HasOne(d => d.Category).WithMany(p => p.TblAssetRegistrations)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("tbl_asset_registration_category_id_fkey");

            entity.HasOne(d => d.Currency).WithMany(p => p.TblAssetRegistrations)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("tbl_asset_registration_currency_id_fkey");

            entity.HasOne(d => d.Department).WithMany(p => p.TblAssetRegistrations)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("tbl_asset_registration_department_id_fkey");

            entity.HasOne(d => d.Embassy).WithMany(p => p.TblAssetRegistrations)
                .HasForeignKey(d => d.EmbassyId)
                .HasConstraintName("tbl_asset_registration_embassy_id_fkey");

            entity.HasOne(d => d.Subcategory).WithMany(p => p.TblAssetRegistrations)
                .HasForeignKey(d => d.SubcategoryId)
                .HasConstraintName("tbl_asset_registration_subcategory_id_fkey");
        });

        modelBuilder.Entity<TblAssetSubCategory>(entity =>
        {
            entity.HasKey(e => e.SubcategoryId).HasName("tbl_asset_sub_category_pkey");

            entity.ToTable("tbl_asset_sub_category");

            entity.HasIndex(e => e.SubcategoryCode, "tbl_asset_sub_category_subcategory_code_key").IsUnique();

            entity.Property(e => e.SubcategoryId).HasColumnName("subcategory_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("true")
                .HasColumnName("is_active");
            entity.Property(e => e.SubcategoryCode)
                .HasMaxLength(50)
                .HasColumnName("subcategory_code");
            entity.Property(e => e.SubcategoryName)
                .HasMaxLength(150)
                .HasColumnName("subcategory_name");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.Category).WithMany(p => p.TblAssetSubCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("tbl_asset_sub_category_category_id_fkey");
        });

        modelBuilder.Entity<TblAssetTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("tbl_asset_transaction_pkey");

            entity.ToTable("tbl_asset_transaction");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.ActionType)
                .HasMaxLength(50)
                .HasColumnName("action_type");
            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.FromEmbassy).HasColumnName("from_embassy");
            entity.Property(e => e.Remarks).HasColumnName("remarks");
            entity.Property(e => e.ToEmbassy).HasColumnName("to_embassy");

            entity.HasOne(d => d.Asset).WithMany(p => p.TblAssetTransactions)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("tbl_asset_transaction_asset_id_fkey");
        });

        modelBuilder.Entity<TblCountryMaster>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("tbl_country_master_pkey");

            entity.ToTable("tbl_country_master");

            entity.HasIndex(e => e.CountryCode, "tbl_country_master_country_code_key").IsUnique();

            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(20)
                .HasColumnName("country_code");
            entity.Property(e => e.CountryName)
                .HasMaxLength(150)
                .HasColumnName("country_name");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("true")
                .HasColumnName("is_active");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<TblCurrencyMaster>(entity =>
        {
            entity.HasKey(e => e.CurrencyId).HasName("tbl_currency_master_pkey");

            entity.ToTable("tbl_currency_master");

            entity.HasIndex(e => e.CurrencyCode, "tbl_currency_master_currency_code_key").IsUnique();

            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .HasColumnName("currency_code");
            entity.Property(e => e.CurrencyName)
                .HasMaxLength(100)
                .HasColumnName("currency_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("true")
                .HasColumnName("is_active");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.Country).WithMany(p => p.TblCurrencyMasters)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("tbl_currency_master_country_id_fkey");
        });

        modelBuilder.Entity<TblDepartmentMaster>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("tbl_department_master_pkey");

            entity.ToTable("tbl_department_master");

            entity.HasIndex(e => e.DepartmentCode, "tbl_department_master_department_code_key").IsUnique();

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(50)
                .HasColumnName("department_code");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(150)
                .HasColumnName("department_name");
            entity.Property(e => e.EmbassyId).HasColumnName("embassy_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("true")
                .HasColumnName("is_active");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.Embassy).WithMany(p => p.TblDepartmentMasters)
                .HasForeignKey(d => d.EmbassyId)
                .HasConstraintName("tbl_department_master_embassy_id_fkey");
        });

        modelBuilder.Entity<TblEmbassyMaster>(entity =>
        {
            entity.HasKey(e => e.EmbassyId).HasName("tbl_embassy_master_pkey");

            entity.ToTable("tbl_embassy_master");

            entity.HasIndex(e => e.EmbassyCode, "tbl_embassy_master_embassy_code_key").IsUnique();

            entity.Property(e => e.EmbassyId).HasColumnName("embassy_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(150)
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(150)
                .HasColumnName("contact_person");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(50)
                .HasColumnName("contact_phone");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.EmbassyCode)
                .HasMaxLength(50)
                .HasColumnName("embassy_code");
            entity.Property(e => e.EmbassyName)
                .HasMaxLength(200)
                .HasColumnName("embassy_name");
            entity.Property(e => e.EmbassyType)
                .HasMaxLength(50)
                .HasColumnName("embassy_type");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("true")
                .HasColumnName("is_active");
            entity.Property(e => e.Latitude)
                .HasPrecision(10, 6)
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasPrecision(10, 6)
                .HasColumnName("longitude");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.Country).WithMany(p => p.TblEmbassyMasters)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("tbl_embassy_master_country_id_fkey");
        });

        modelBuilder.Entity<TblMenuPerm>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("tbl_menu_perm_pkey");

            entity.ToTable("tbl_menu_perm");

            entity.HasIndex(e => e.MenuId, "IX_tbl_menu_perm_menu_id");

            entity.HasIndex(e => new { e.RoleId, e.MenuId }, "tbl_menu_perm_role_id_menu_id_key").IsUnique();

            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.CanDelete)
                .HasDefaultValueSql("false")
                .HasColumnName("can_delete");
            entity.Property(e => e.CanRead)
                .HasDefaultValueSql("false")
                .HasColumnName("can_read");
            entity.Property(e => e.CanWrite)
                .HasDefaultValueSql("false")
                .HasColumnName("can_write");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("character varying")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("true")
                .HasColumnName("is_active");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("character varying")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.Menu).WithMany(p => p.TblMenuPerms)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("tbl_menu_perm_menu_id_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.TblMenuPerms)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("tbl_menu_perm_role_id_fkey");
        });

        modelBuilder.Entity<TblPopupMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("tbl_popup_menu_pkey");

            entity.ToTable("tbl_popup_menu");

            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("character varying")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.Helperurl)
                .HasMaxLength(200)
                .HasColumnName("helperurl");
            entity.Property(e => e.Href)
                .HasMaxLength(200)
                .HasColumnName("href");
            entity.Property(e => e.Icon)
                .HasMaxLength(100)
                .HasColumnName("icon");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("true")
                .HasColumnName("is_active");
            entity.Property(e => e.MenuName)
                .HasMaxLength(100)
                .HasColumnName("menu_name");
            entity.Property(e => e.Orderby).HasColumnName("orderby");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("character varying")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<TblRoleMaster>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("tbl_role_master_pkey");

            entity.ToTable("tbl_role_master");

            entity.HasIndex(e => e.RoleName, "tbl_role_master_role_name_key").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("character varying")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("true")
                .HasColumnName("is_active");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("character varying")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<TblUserMaster>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("tbl_user_master_pkey");

            entity.ToTable("tbl_user_master");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.Candidateid).HasColumnName("candidateid");
            entity.Property(e => e.Companyname)
                .HasMaxLength(500)
                .HasColumnName("companyname");
            entity.Property(e => e.Companytype)
                .HasMaxLength(500)
                .HasColumnName("companytype");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("character varying")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.EmailId)
                .HasColumnType("character varying")
                .HasColumnName("email_id");
            entity.Property(e => e.Empid)
                .HasMaxLength(100)
                .HasColumnName("empid");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.MobileNo)
                .HasColumnType("character varying")
                .HasColumnName("mobile_no");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Nationalid)
                .HasMaxLength(100)
                .HasColumnName("nationalid");
            entity.Property(e => e.Otp).HasColumnName("otp");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Salesmanid).HasColumnName("salesmanid");
            entity.Property(e => e.Token)
                .HasColumnType("character varying")
                .HasColumnName("token");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("character varying")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
        });

        modelBuilder.Entity<TblUserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("tbl_user_roles_pkey");

            entity.ToTable("tbl_user_roles");

            entity.HasIndex(e => e.Parentid, "IX_tbl_user_roles_parentid");

            entity.HasIndex(e => e.RoleId, "IX_tbl_user_roles_role_id");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("character varying")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("true")
                .HasColumnName("is_active");
            entity.Property(e => e.Parentid).HasColumnName("parentid");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("character varying")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.Parent).WithMany(p => p.TblUserRoleParents)
                .HasForeignKey(d => d.Parentid)
                .HasConstraintName("fk_parent_role");

            entity.HasOne(d => d.Role).WithMany(p => p.TblUserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_user_roles_role_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.TblUserRoleUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_user_roles_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
