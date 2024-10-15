﻿// <auto-generated />
using System;
using Its.Ads.Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ads_api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241015130054_IpMap_001")]
    partial class IpMap_001
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Its.Ads.Api.Models.MApiKey", b =>
                {
                    b.Property<Guid?>("KeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("key_id");

                    b.Property<string>("ApiKey")
                        .HasColumnType("text")
                        .HasColumnName("api_key");

                    b.Property<DateTime?>("KeyCreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("key_created_date");

                    b.Property<string>("KeyDescription")
                        .HasColumnType("text")
                        .HasColumnName("key_description");

                    b.Property<DateTime?>("KeyExpiredDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("key_expired_date");

                    b.Property<string>("OrgId")
                        .HasColumnType("text")
                        .HasColumnName("org_id");

                    b.Property<string>("RolesList")
                        .HasColumnType("text")
                        .HasColumnName("roles_list");

                    b.HasKey("KeyId");

                    b.HasIndex("ApiKey")
                        .IsUnique();

                    b.HasIndex("OrgId");

                    b.ToTable("ApiKeys");
                });

            modelBuilder.Entity("Its.Ads.Api.Models.MBlacklist", b =>
                {
                    b.Property<Guid?>("BlacklistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("blacklist_id");

                    b.Property<string>("BlacklistCode")
                        .HasColumnType("text")
                        .HasColumnName("blacklist_code");

                    b.Property<int?>("BlacklistType")
                        .HasColumnType("integer")
                        .HasColumnName("blacklist_type");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("OrgId")
                        .HasColumnType("text")
                        .HasColumnName("org_id");

                    b.Property<string>("Tags")
                        .HasColumnType("text")
                        .HasColumnName("tags");

                    b.HasKey("BlacklistId");

                    b.ToTable("Blacklists");
                });

            modelBuilder.Entity("Its.Ads.Api.Models.MIpMap", b =>
                {
                    b.Property<Guid?>("IpMapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ip_map_id");

                    b.Property<string>("Cidr")
                        .HasColumnType("text")
                        .HasColumnName("cidr");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<int?>("Description")
                        .HasColumnType("integer")
                        .HasColumnName("description");

                    b.Property<string>("OrgId")
                        .HasColumnType("text")
                        .HasColumnName("org_id");

                    b.Property<string>("Zone")
                        .HasColumnType("text")
                        .HasColumnName("zone");

                    b.HasKey("IpMapId");

                    b.ToTable("IpMaps");
                });

            modelBuilder.Entity("Its.Ads.Api.Models.MOrganization", b =>
                {
                    b.Property<Guid?>("OrgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("org_id");

                    b.Property<DateTime?>("OrgCreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("org_created_date");

                    b.Property<string>("OrgCustomId")
                        .HasColumnType("text")
                        .HasColumnName("org_custom_id");

                    b.Property<string>("OrgDescription")
                        .HasColumnType("text")
                        .HasColumnName("org_description");

                    b.Property<string>("OrgName")
                        .HasColumnType("text")
                        .HasColumnName("org_name");

                    b.HasKey("OrgId");

                    b.HasIndex("OrgCustomId")
                        .IsUnique();

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Its.Ads.Api.Models.MOrganizationUser", b =>
                {
                    b.Property<Guid?>("OrgUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("org_user_id");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("OrgCustomId")
                        .HasColumnType("text")
                        .HasColumnName("org_custom_id");

                    b.Property<string>("RolesList")
                        .HasColumnType("text")
                        .HasColumnName("roles_list");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("UserName")
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("OrgUserId");

                    b.HasIndex("OrgCustomId");

                    b.HasIndex(new[] { "OrgCustomId", "UserId" }, "OrgUser_Unique1")
                        .IsUnique();

                    b.ToTable("OrganizationsUsers");
                });

            modelBuilder.Entity("Its.Ads.Api.Models.MRole", b =>
                {
                    b.Property<Guid?>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.Property<DateTime?>("RoleCreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("role_created_date");

                    b.Property<string>("RoleDefinition")
                        .HasColumnType("text")
                        .HasColumnName("role_definition");

                    b.Property<string>("RoleDescription")
                        .HasColumnType("text")
                        .HasColumnName("role_description");

                    b.Property<string>("RoleLevel")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_level");

                    b.Property<string>("RoleName")
                        .HasColumnType("text")
                        .HasColumnName("role_name");

                    b.HasKey("RoleId");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Its.Ads.Api.Models.MUser", b =>
                {
                    b.Property<Guid?>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<DateTime?>("UserCreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("user_created_date");

                    b.Property<string>("UserEmail")
                        .HasColumnType("text")
                        .HasColumnName("user_email");

                    b.Property<string>("UserName")
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("UserId");

                    b.HasIndex("UserEmail")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Its.Ads.Api.Models.MWorkFlow", b =>
                {
                    b.Property<Guid?>("WorkflowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("workflow_id");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("FlowType")
                        .HasColumnType("text")
                        .HasColumnName("flow_type");

                    b.Property<string>("OrgId")
                        .HasColumnType("text")
                        .HasColumnName("org_id");

                    b.Property<Guid?>("TemplateId")
                        .HasColumnType("uuid")
                        .HasColumnName("template_id");

                    b.Property<string>("TemplateName")
                        .HasColumnType("text")
                        .HasColumnName("template_name");

                    b.Property<string>("Variables")
                        .HasColumnType("text")
                        .HasColumnName("variables");

                    b.Property<string>("WorkflowDesc")
                        .HasColumnType("text")
                        .HasColumnName("workflow_desc");

                    b.Property<string>("WorkflowName")
                        .HasColumnType("text")
                        .HasColumnName("workflow_name");

                    b.HasKey("WorkflowId");

                    b.HasIndex("WorkflowName")
                        .IsUnique();

                    b.ToTable("Workflows");
                });

            modelBuilder.Entity("Its.Ads.Api.Models.MWorkflowTemplate", b =>
                {
                    b.Property<Guid?>("WorkflowTemplateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("workflow_template_id");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("FlowType")
                        .HasColumnType("text")
                        .HasColumnName("flow_type");

                    b.Property<string>("TemplateDesc")
                        .HasColumnType("text")
                        .HasColumnName("template_desc");

                    b.Property<string>("TemplateName")
                        .HasColumnType("text")
                        .HasColumnName("template_name");

                    b.Property<string>("TemplateVersion")
                        .HasColumnType("text")
                        .HasColumnName("template_version");

                    b.Property<string>("Variables")
                        .HasColumnType("text")
                        .HasColumnName("variables");

                    b.HasKey("WorkflowTemplateId");

                    b.HasIndex("TemplateName")
                        .IsUnique();

                    b.ToTable("WorkflowTemplates");
                });
#pragma warning restore 612, 618
        }
    }
}