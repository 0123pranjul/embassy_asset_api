using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmbassyAassetManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loginauditlogs",
                columns: table => new
                {
                    logid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    appname = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    ipaddress = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    region = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    latitude = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    longitude = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    browserinfo = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    loggedinat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    zipcode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    timezone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    isp = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    org = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    asinfo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    countrycode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    regionname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("loginauditlogs_pkey", x => x.logid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_popup_menu",
                columns: table => new
                {
                    menuid = table.Column<int>(name: "menu_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    menuname = table.Column<string>(name: "menu_name", type: "character varying(100)", maxLength: 100, nullable: false),
                    href = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    parentid = table.Column<int>(name: "parent_id", type: "integer", nullable: true),
                    icon = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    isactive = table.Column<bool>(name: "is_active", type: "boolean", nullable: true, defaultValueSql: "true"),
                    createdby = table.Column<string>(name: "created_by", type: "character varying", nullable: true),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying", nullable: true),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "timestamp without time zone", nullable: true),
                    helperurl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    orderby = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_popup_menu_pkey", x => x.menuid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_role_master",
                columns: table => new
                {
                    roleid = table.Column<int>(name: "role_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rolename = table.Column<string>(name: "role_name", type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "boolean", nullable: true, defaultValueSql: "true"),
                    createdby = table.Column<string>(name: "created_by", type: "character varying", nullable: true),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying", nullable: true),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_role_master_pkey", x => x.roleid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_master",
                columns: table => new
                {
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying", nullable: false),
                    password = table.Column<string>(type: "character varying", nullable: true),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    mobileno = table.Column<string>(name: "mobile_no", type: "character varying", nullable: true),
                    emailid = table.Column<string>(name: "email_id", type: "character varying", nullable: true),
                    address = table.Column<string>(type: "character varying", nullable: true),
                    isactive = table.Column<bool>(name: "is_active", type: "boolean", nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying", nullable: true),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying", nullable: true),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "timestamp without time zone", nullable: true),
                    token = table.Column<string>(type: "character varying", nullable: true),
                    lastname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    empid = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    nationalid = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    deviceid = table.Column<int>(type: "integer", nullable: true),
                    candidateid = table.Column<int>(type: "integer", nullable: true),
                    salesmanid = table.Column<int>(type: "integer", nullable: true),
                    companyname = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    companytype = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    otp = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_user_master_pkey", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_menu_perm",
                columns: table => new
                {
                    permissionid = table.Column<int>(name: "permission_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<int>(name: "role_id", type: "integer", nullable: true),
                    menuid = table.Column<int>(name: "menu_id", type: "integer", nullable: true),
                    canread = table.Column<bool>(name: "can_read", type: "boolean", nullable: true, defaultValueSql: "false"),
                    canwrite = table.Column<bool>(name: "can_write", type: "boolean", nullable: true, defaultValueSql: "false"),
                    candelete = table.Column<bool>(name: "can_delete", type: "boolean", nullable: true, defaultValueSql: "false"),
                    isactive = table.Column<bool>(name: "is_active", type: "boolean", nullable: true, defaultValueSql: "true"),
                    createdby = table.Column<string>(name: "created_by", type: "character varying", nullable: true),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying", nullable: true),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_menu_perm_pkey", x => x.permissionid);
                    table.ForeignKey(
                        name: "tbl_menu_perm_menu_id_fkey",
                        column: x => x.menuid,
                        principalTable: "tbl_popup_menu",
                        principalColumn: "menu_id");
                    table.ForeignKey(
                        name: "tbl_menu_perm_role_id_fkey",
                        column: x => x.roleid,
                        principalTable: "tbl_role_master",
                        principalColumn: "role_id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_roles",
                columns: table => new
                {
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    roleid = table.Column<int>(name: "role_id", type: "integer", nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "boolean", nullable: true, defaultValueSql: "true"),
                    createdby = table.Column<string>(name: "created_by", type: "character varying", nullable: true),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying", nullable: true),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "timestamp without time zone", nullable: true),
                    parentid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_user_roles_pkey", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "fk_parent_role",
                        column: x => x.parentid,
                        principalTable: "tbl_user_master",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "tbl_user_roles_role_id_fkey",
                        column: x => x.roleid,
                        principalTable: "tbl_role_master",
                        principalColumn: "role_id");
                    table.ForeignKey(
                        name: "tbl_user_roles_user_id_fkey",
                        column: x => x.userid,
                        principalTable: "tbl_user_master",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_menu_perm_menu_id",
                table: "tbl_menu_perm",
                column: "menu_id");

            migrationBuilder.CreateIndex(
                name: "tbl_menu_perm_role_id_menu_id_key",
                table: "tbl_menu_perm",
                columns: new[] { "role_id", "menu_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "tbl_role_master_role_name_key",
                table: "tbl_role_master",
                column: "role_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_roles_parentid",
                table: "tbl_user_roles",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_roles_role_id",
                table: "tbl_user_roles",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loginauditlogs");

            migrationBuilder.DropTable(
                name: "tbl_menu_perm");

            migrationBuilder.DropTable(
                name: "tbl_user_roles");

            migrationBuilder.DropTable(
                name: "tbl_popup_menu");

            migrationBuilder.DropTable(
                name: "tbl_user_master");

            migrationBuilder.DropTable(
                name: "tbl_role_master");
        }
    }
}
