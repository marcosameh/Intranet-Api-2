using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel;

public partial class IntranetContext : DbContext
{
    public IntranetContext()
    {
    }
    public IntranetContext(DbContextOptions<IntranetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<News> News { get; set; }
    public virtual DbSet<NewsAttachment> NewsAttachments { get; set; }
    public virtual DbSet<NewsType> NewsTypes { get; set; }
    public virtual DbSet<Newscomment> Newscomments { get; set; }
    public virtual DbSet<Almanac> Almanacs { get; set; }
    public virtual DbSet<KnowledgebaseArticle> KnowledgebaseArticles { get; set; }
    public virtual DbSet<KnowledgebaseCategroy> KnowledgebaseCategroys { get; set; }
    public virtual DbSet<KnowledgebaseFile> KnowledgebaseFiles { get; set; }
    public virtual DbSet<QuickLink> QuickLinks { get; set; }
    public virtual DbSet<EmployeeInformation> EmployeeInformations { get; set; }
    public virtual DbSet<KnbMainCategory> KnbMainCategories { get; set; }
    public virtual DbSet<KnbSubCategory> KnbSubCategories { get; set; }
    public virtual DbSet<KnbTeamRole> KnbTeamRoles { get; set; }
    public virtual DbSet<KnowledgebaseTeam> KnowledgebaseTeams { get; set; }
    public virtual DbSet<UsersSession> UsersSessions { get; set; }
    public virtual DbSet<KbaseSectionItem> KbaseSectionItems { get; set; }
    public virtual DbSet<KnbScategoryFile> KnbScategoryFiles { get; set; }
    public virtual DbSet<Knowledgebase> Knowledgebases { get; set; }
    public virtual DbSet<KnowledgebaseRole> KnowledgebaseRoles { get; set; }
    public virtual DbSet<KnowledgebaseSection> KnowledgebaseSections { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Userlogin> Userlogins { get; set; }
    public virtual DbSet<KnowledgebaseFileDownload> KnowledgebaseFileDownloads { get; set; }




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseOracle("User ID=intranet;Password=intranet;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(COMMUNITY = tcp.world)(PROTOCOL = TCP)(Host = devdb.tanmeyah.lan)(Port = 1521)))(CONNECT_DATA=(SID=devdbtest)));");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("INTRANET");

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("NEWS_PK");

            entity.ToTable("NEWS");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");
            entity.Property(e => e.Body)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("BODY");
            entity.Property(e => e.Createdon)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDON");
            entity.Property(e => e.NewsTypeId)
                .HasPrecision(10)
                .HasColumnName("NEWS_TYPE_ID");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.NewsType).WithMany(p => p.News)
                .HasForeignKey(d => d.NewsTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NEWS_TYPE");
        });

        modelBuilder.Entity<NewsAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("NEWS_ATTACHMENT_PK");

            entity.ToTable("NEWS_ATTACHMENT");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");
            entity.Property(e => e.AttachmentName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("null")
                .HasColumnName("ATTACHMENT_NAME");
            entity.Property(e => e.CoverImg)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("COVER_IMG");
            entity.Property(e => e.Extension)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EXTENSION");
            entity.Property(e => e.NewsId)
                .HasPrecision(10)
                .HasColumnName("NEWS_ID");

            entity.HasOne(d => d.News).WithMany(p => p.NewsAttachments)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NEWS");
        });

        modelBuilder.Entity<NewsType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("NEWS_TYPE_PK");

            entity.ToTable("NEWS_TYPE");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");
            entity.Property(e => e.Isenable)
                .HasPrecision(1)
                .HasDefaultValueSql("(0)")
                .HasColumnName("ISENABLE");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Newscomment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C0045260");

            entity.ToTable("NEWSCOMMENTS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Content)
                .IsUnicode(false)
                .HasColumnName("CONTENT");
            entity.Property(e => e.Newsid)
                .HasColumnType("NUMBER")
                .HasColumnName("NEWSID");
            entity.Property(e => e.Timestamp)
                .HasColumnType("DATE")
                .HasColumnName("TIMESTAMP");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");
        });
        modelBuilder.Entity<KbaseSectionItem>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.ToTable("KBASE_SECTION_ITEM");

            entity.Property(e => e.ItemId)
                .HasPrecision(5)
                .HasColumnName("ITEM_ID");

            entity.Property(e => e.ItemContent)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ITEM_CONTENT");

            entity.Property(e => e.ItemName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("ITEM_NAME");

            entity.Property(e => e.SectionId)
                .HasPrecision(5)
                .HasColumnName("SECTION_ID");

            entity.HasOne(d => d.Section)
                .WithMany(p => p.KbaseSectionItems)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KNOWLEDGEBASE_ITEM");
        });

        modelBuilder.Entity<KnbMainCategory>(entity =>
        {
            entity.HasKey(e => e.MainCategoryId);

            entity.ToTable("KNB_MAIN_CATEGORY");

            entity.Property(e => e.MainCategoryId)
                .HasPrecision(5)
                .HasColumnName("MAIN_CATEGORY_ID");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CATEGORY_NAME");

            entity.Property(e => e.TeamId)
                .HasPrecision(5)
                .HasColumnName("TEAM_ID");

            entity.HasOne(d => d.Team)
                .WithMany(p => p.KnbMainCategories)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KNB_MCATEGORY_KNB_TEAM");
        });

        modelBuilder.Entity<KnbScategoryFile>(entity =>
        {
            entity.HasKey(e => e.FileId);

            entity.ToTable("KNB_SCATEGORY_FILES");

            entity.Property(e => e.FileId)
                .HasPrecision(5)
                .HasColumnName("FILE_ID");

            entity.Property(e => e.FileName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FILE_NAME");

            entity.Property(e => e.FileOriginalName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FILE_ORIGINAL_NAME");

            entity.Property(e => e.SubCategoryId)
                .HasPrecision(5)
                .HasColumnName("SUB_CATEGORY_ID");

            entity.HasOne(d => d.SubCategory)
             .WithMany(p => p.KnbScategoryFiles)
             .HasForeignKey(d => d.SubCategoryId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_KNB_SCF_SCATEGORY");
        });

        modelBuilder.Entity<KnbSubCategory>(entity =>
        {
            entity.HasKey(e => e.SubCategoryId);

            entity.ToTable("KNB_SUB_CATEGORY");

            entity.Property(e => e.SubCategoryId)
                .HasPrecision(5)
                .HasColumnName("SUB_CATEGORY_ID");

            entity.Property(e => e.MainCategoryId)
                .HasPrecision(5)
                .HasColumnName("MAIN_CATEGORY_ID");

            entity.Property(e => e.SubCategoryContent)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SUB_CATEGORY_CONTENT");

            entity.Property(e => e.SubCategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SUB_CATEGORY_NAME");

            entity.HasOne(d => d.MainCategory)
                .WithMany(p => p.KnbSubCategories)
                .HasForeignKey(d => d.MainCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KNB_SCATEGORY_KNB_MCAT");
        });

        modelBuilder.Entity<KnbTeamRole>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("KNB_TEAM_ROLE");

            entity.Property(e => e.RoleId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ROLE_ID");

            entity.Property(e => e.TeamId)
                .HasPrecision(5)
                .HasColumnName("TEAM_ID");

            entity.HasOne(d => d.Role)
                .WithMany()
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KNB_TEAM_ROLE");

            entity.HasOne(d => d.Team)
                .WithMany()
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KNB_TEAM_TEAM");
        });

        modelBuilder.Entity<Knowledgebase>(entity =>
        {
            entity.ToTable("KNOWLEDGEBASE");

            entity.Property(e => e.Id)
                .HasPrecision(5)
                .HasColumnName("ID");

            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<KnowledgebaseArticle>(entity =>
        {
            entity.HasKey(e => e.ArticleId)
                .HasName("PK_KB_ARTICLE");

            entity.ToTable("KNOWLEDGEBASE_ARTICLE");

            entity.Property(e => e.ArticleId)
                .HasPrecision(5)
                .HasColumnName("ARTICLE_ID");

            entity.Property(e => e.CategroyId)
                .HasPrecision(5)
                .HasColumnName("CATEGROY_ID");

            entity.Property(e => e.Content)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CONTENT");

            entity.Property(e => e.Subject)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");

            entity.HasOne(d => d.Categroy)
                .WithMany(p => p.KnowledgebaseArticles)
                .HasForeignKey(d => d.CategroyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARTICLE_KB");
        });

        modelBuilder.Entity<KnowledgebaseCategroy>(entity =>
        {
            entity.HasKey(e => e.CategroyId)
                .HasName("PK_KB_TREE");

            entity.ToTable("KNOWLEDGEBASE_CATEGROY");

            entity.Property(e => e.CategroyId)
                .HasPrecision(5)
                .HasColumnName("CATEGROY_ID");

            entity.Property(e => e.CategroyName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("CATEGROY_NAME");

            entity.Property(e => e.ParentCategroyId)
                .HasPrecision(5)
                .HasColumnName("PARENT_CATEGROY_ID");
        });

        modelBuilder.Entity<KnowledgebaseFile>(entity =>
        {
            entity.HasKey(e => e.FileId)
                .HasName("PK_KB_FILE");

            entity.ToTable("KNOWLEDGEBASE_FILE");

            entity.Property(e => e.FileId)
                .HasPrecision(5)
                .HasColumnName("FILE_ID");

            entity.Property(e => e.CategroyId)
                .HasPrecision(5)
                .HasColumnName("CATEGROY_ID");

            entity.Property(e => e.FileName)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("FILE_NAME");

            entity.Property(e => e.FileNameHash)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("FILE_NAME_HASH");

            entity.Property(e => e.IsViewOnly)
                .HasColumnType("NUMBER")
                .HasColumnName("IS_VIEW_ONLY");

            entity.HasOne(d => d.Categroy)
                .WithMany(p => p.KnowledgebaseFiles)
                .HasForeignKey(d => d.CategroyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KN_CATEGROY_F");
        });

        modelBuilder.Entity<KnowledgebaseRole>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("KNOWLEDGEBASE_ROLE");

            entity.Property(e => e.KnowledgebaseId)
                .HasPrecision(5)
                .HasColumnName("KNOWLEDGEBASE_ID");

            entity.Property(e => e.RoleId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ROLE_ID");

            entity.HasOne(d => d.Knowledgebase)
                .WithMany()
                .HasForeignKey(d => d.KnowledgebaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KBASE_ROLE");

            entity.HasOne(d => d.Role)
                .WithMany()
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KNOWLEDGEBASE_ROLE");
        });

        modelBuilder.Entity<KnowledgebaseSection>(entity =>
        {
            entity.HasKey(e => e.SectionId)
                .HasName("PK_KB_SECTION");

            entity.ToTable("KNOWLEDGEBASE_SECTION");

            entity.Property(e => e.SectionId)
                .HasPrecision(5)
                .HasColumnName("SECTION_ID");

            entity.Property(e => e.KnowledgebaseId)
                .HasPrecision(5)
                .HasColumnName("KNOWLEDGEBASE_ID");

            entity.Property(e => e.SectionName)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasColumnName("SECTION_NAME");

            entity.HasOne(d => d.Knowledgebase)
                .WithMany(p => p.KnowledgebaseSections)
                .HasForeignKey(d => d.KnowledgebaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KNOWLEDGEBASE");
        });

        modelBuilder.Entity<KnowledgebaseTeam>(entity =>
        {
            entity.HasKey(e => e.TeamId);

            entity.ToTable("KNOWLEDGEBASE_TEAM");

            entity.Property(e => e.TeamId)
                .HasPrecision(5)
                .HasColumnName("TEAM_ID");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");

            entity.Property(e => e.ErpDepartmentId)
                .HasPrecision(10)
                .HasColumnName("ERP_DEPARTMENT_ID");

            entity.Property(e => e.TeamName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TEAM_NAME");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("ROLES");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ID");

            entity.Property(e => e.ConcurrencyStamp)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("CONCURRENCYSTAMP");

            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");

            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("NAME");

            entity.Property(e => e.NormalizedName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("NORMALIZEDNAME");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USERS");

            entity.HasIndex(e => e.Email, "USERS_UNIQUE")
                .IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ID");

            entity.Property(e => e.AccessFailedCount)
                .HasPrecision(1)
                .HasColumnName("ACCESSFAILEDCOUNT")
                .HasDefaultValueSql("0");

            entity.Property(e => e.ConcurrencyStamp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONCURRENCYSTAMP");

            entity.Property(e => e.NormalizedEmail)
             .HasMaxLength(200)
             .IsUnicode(false)
             .HasColumnName("NORMALIZEDEMAIL");

            entity.Property(e => e.PhoneNumberConfirmed)
 .HasMaxLength(200)
 .IsUnicode(false)
 .HasColumnName("PHONENUMBERCONFIRMED");


            entity.Property(e => e.EmailConfirmed)
 .HasMaxLength(200)
 .IsUnicode(false)
 .HasColumnName("EMAILCONFIRMED");

            entity.Property(e => e.NormalizedUserName)
 .HasMaxLength(200)
 .IsUnicode(false)
 .HasColumnName("NORMALIZEDUSERNAME");



            entity.Property(e => e.TwoFactorEnabled)
           .HasPrecision(1)
           .HasColumnName("TWOFACTORENABLED")
           .HasDefaultValueSql("1");

            entity.Property(e => e.LockoutEnabled)
                .HasPrecision(1)
                .HasColumnName("LOCKOUTENABLED")
                .HasDefaultValueSql("1");

            entity.Property(e => e.Department)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");

            entity.Property(e => e.Isblocked)
                .HasPrecision(1)
                .HasColumnName("ISBLOCKED")
                .HasDefaultValueSql("(0)");

            entity.Property(e => e.LockoutEnabled)
                .HasPrecision(1)
                .HasColumnName("LOCKOUTENABLED")
                .HasDefaultValueSql("1");

            entity.Property(e => e.LockoutEnd)
                .HasColumnType("DATE")
                .HasColumnName("LOCKOUTEND");

            entity.Property(e => e.OracleNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ORACLENO");

            entity.Property(e => e.PasswordHash)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("PASSWORDHASH");

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PHONENUMBER");

            entity.Property(e => e.SecurityStamp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SECURITYSTAMP");

            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasMany(d => d.Roles)
                .WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Userrole",
                    l => l.HasOne<Role>().WithMany().HasForeignKey("Roleid").HasConstraintName("SYS_C008404"),
                    r => r.HasOne<User>().WithMany().HasForeignKey("Userid").HasConstraintName("SYS_C008403"),
                    j =>
                    {
                        j.HasKey("Userid", "Roleid").HasName("SYS_C008347");

                        j.ToTable("USERROLES");

                        j.IndexerProperty<string>("Userid").HasMaxLength(128).IsUnicode(false).HasColumnName("USERID");

                        j.IndexerProperty<string>("Roleid").HasMaxLength(128).IsUnicode(false).HasColumnName("ROLEID");
                    });
        });

        modelBuilder.Entity<Userlogin>(entity =>
        {
            entity.HasKey(e => new { e.Loginprovider, e.Providerkey })
                .HasName("SYS_C008346");

            entity.ToTable("USERLOGINS");

            entity.Property(e => e.Loginprovider)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("LOGINPROVIDER");

            entity.Property(e => e.Providerkey)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("PROVIDERKEY");

            entity.Property(e => e.Providerdisplayname)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("PROVIDERDISPLAYNAME");

            entity.Property(e => e.Userid)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("USERID");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Userlogins)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USERS");
        });

        modelBuilder.Entity<UsersSession>(entity =>
        {
            entity.HasKey(e => e.SeesionId);

            entity.ToTable("USERS_SESSIONS");

            entity.Property(e => e.SeesionId)
                .HasPrecision(5)
                .HasColumnName("SEESION_ID");

            entity.Property(e => e.LoginTime)
                .HasColumnType("DATE")
                .HasColumnName("LOGIN_TIME");

            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("TOKEN");

            entity.Property(e => e.UserName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<UsersSession>(entity =>
        {
            entity.HasKey(e => e.SeesionId);

            entity.ToTable("USERS_SESSIONS");

            entity.Property(e => e.SeesionId)
                .HasPrecision(5)
                .HasColumnName("SEESION_ID");

            entity.Property(e => e.LoginTime)
                .HasColumnType("DATE")
                .HasColumnName("LOGIN_TIME");

            entity.Property(e => e.Token)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("TOKEN");

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });
        modelBuilder.HasSequence("ADJUSTMENT_TYPE_SEQ");
        modelBuilder.HasSequence("APPLICATIONS_SEQ");
        modelBuilder.HasSequence("BLANK_MEMO_SEQ");
        modelBuilder.HasSequence("BRACH_ENG_LOG_SEQ");
        modelBuilder.HasSequence("BRANCH_ATTACHMENT_HIS_SEQ");
        modelBuilder.HasSequence("BRANCH_CONDITIONER_HIS_SEQ");
        modelBuilder.HasSequence("BRANCH_ENGINEERING_WORK_SEQ");
        modelBuilder.HasSequence("BRANCH_FURNITURE_HIS_SEQ");
        modelBuilder.HasSequence("BRANCH_FURNITURE_SUPPLY_SEQ");
        modelBuilder.HasSequence("BRANCH_OPERATING_WORK_LOG_SEQ");
        modelBuilder.HasSequence("BRANCH_OPERATING_WORK_SEQ");
        modelBuilder.HasSequence("BRANCH_STATUS_HIS_SEQ");
        modelBuilder.HasSequence("BRANCH_STATUS_OUT_WARRANTY_SEQ");
        modelBuilder.HasSequence("BRANCHES_ATTACHMENT_SEQ");
        modelBuilder.HasSequence("BRANCHES_CONDITIONER_SEQ");
        modelBuilder.HasSequence("BRANCHES_CONTRACT_EXPIRES_SEQ");
        modelBuilder.HasSequence("BRANCHES_STATUS_SEQ");
        modelBuilder.HasSequence("CAR_ATTACHMENT_HIS_SEQ");
        modelBuilder.HasSequence("CAR_ATTACHMENT_SEQ");
        modelBuilder.HasSequence("CAR_HISTORY_SEQ");
        modelBuilder.HasSequence("CAR_INSURANCE_RENEWAL_LOG_SEQ");
        modelBuilder.HasSequence("CAR_LICENSE_RENEWAL_LOG_SEQ");
        modelBuilder.HasSequence("CAR_MAINTENANCE_ATT_HIS_SEQ");
        modelBuilder.HasSequence("CAR_MAINTENANCE_ATTACHMENT_SEQ");
        modelBuilder.HasSequence("CAR_MAINTENANCE_HIS_SEQ");
        modelBuilder.HasSequence("CAR_MISSION_ACCOMPANYING_SEQ");
        modelBuilder.HasSequence("CAR_MISSION_ATTACHMENT_SEQ");
        modelBuilder.HasSequence("CAR_MISSION_DEPARTMENT_SEQ");
        modelBuilder.HasSequence("CAR_MISSION_PERSONS_SEQ");
        modelBuilder.HasSequence("CAR_MISSION_SEQ");
        modelBuilder.HasSequence("CAR_SEQ");
        modelBuilder.HasSequence("CATEGORY_MEMOS_SEQUENCE");
        modelBuilder.HasSequence("CHANGE_DOCUMENT_SEQ");
        modelBuilder.HasSequence("CHANGE_REQUEST_SEQ");
        modelBuilder.HasSequence("CONTRACT_CLASSIFICATION_SEQ");
        modelBuilder.HasSequence("DESIGN_FORM_SEQUENCE");
        modelBuilder.HasSequence("DRIVER_LICENSE_SEQ");
        modelBuilder.HasSequence("DRIVER_SEQ");
        modelBuilder.HasSequence("DRIVERS_HISTORY_SEQ");
        modelBuilder.HasSequence("EMPLOYEE_INFORMATION_SEQ");
        modelBuilder.HasSequence("FB_WFLOW_DOCUMENTS_SEQUENCE");
        modelBuilder.HasSequence("FIELD_PERMISSIONS_SEQUENCE");
        modelBuilder.HasSequence("FORM_BUILDER_DATA_SEQUENCE");
        modelBuilder.HasSequence("FORM_BUILDER_WORKFLOW_SEQUENCE");
        modelBuilder.HasSequence("FORM_BUILDERS_SEQUENCE");
        modelBuilder.HasSequence("FORM_INPUT_FIELDS_SEQUENCE");
        modelBuilder.HasSequence("INCIDENT_REPORT_SEQ");
        modelBuilder.HasSequence("INITIATE_REQUESTS_SEQUENCE");
        modelBuilder.HasSequence("INPUT_FIELD_DATA_SEQUENCE");
        modelBuilder.HasSequence("IT_CONTRACT_HIS_SEQ");
        modelBuilder.HasSequence("IT_CONTRACT_SEQ");
        modelBuilder.HasSequence("IT_CONTRACT_STATUS_SEQ");
        modelBuilder.HasSequence("IT_CONTRACT_TYPE_SEQ");
        modelBuilder.HasSequence("IT_DEPARTMENTS_SEQ");
        modelBuilder.HasSequence("IT_SUP_DEPARTMENTS_SEQ");
        modelBuilder.HasSequence("KNB_MAIN_CATEGORY_SEQUENCE");
        modelBuilder.HasSequence("KNB_SCATEGORY_FILES_SEQUENCE");
        modelBuilder.HasSequence("KNB_SUB_CATEGORY_SEQUENCE");
        modelBuilder.HasSequence("KNOWLEDGEBASE_ARTICLE_SEQ");
        modelBuilder.HasSequence("KNOWLEDGEBASE_CATEGORY_SEQ");
        modelBuilder.HasSequence("KNOWLEDGEBASE_FILE_SEQ");
        modelBuilder.HasSequence("KNOWLEDGEBASE_TEAM_SEQUENCE");
        modelBuilder.HasSequence("LOGGING_LOG_SEQ");
        modelBuilder.HasSequence("MAINTENANCE_SEQ");
        modelBuilder.HasSequence("MEMO_TYPE_SEQ");
        modelBuilder.HasSequence("MESSAGE_SEQ");
        modelBuilder.HasSequence("NEWS_ATTACHMENT_ID");
        modelBuilder.HasSequence("NEWS_ID");
        modelBuilder.HasSequence("NEWS_TYPE_ID");
        modelBuilder.HasSequence("NEWSCOMMENTS_SEQ");
        modelBuilder.HasSequence("PASS_LMT_SEQUENCE");
        modelBuilder.HasSequence("PAYMENT_TYPES_SEQ");
        modelBuilder.HasSequence("PRIORITY_LEVEL_SEQ");
        modelBuilder.HasSequence("R_MEMO_ATT_ID");
        modelBuilder.HasSequence("R_MEMO_SIGN_ID");
        modelBuilder.HasSequence("R_MEMO_SUPER_ID");
        modelBuilder.HasSequence("REQUEST_ACTION_SEQUENCE");
        modelBuilder.HasSequence("REQUEST_FORMS_SEQUENCE");
        modelBuilder.HasSequence("REQUEST_MEMO_MEMOID");
        modelBuilder.HasSequence("SLA_PROCESS_LOG_SEQUENCE");
        modelBuilder.HasSequence("TABLES_NAMES_SEQUENCE");
        modelBuilder.HasSequence("TIRE_CHANGE_MAIL_SEQ");
        modelBuilder.HasSequence("TRAFFIC_VIOLATION_SEQ");
        modelBuilder.HasSequence("USERS_SESSIONS_SEQUENCE");
        modelBuilder.HasSequence("WF_HISTORY_SEQUENCE");
        modelBuilder.HasSequence("WORK_FLOW_SEQUENCE");
        modelBuilder.HasSequence("WORK_FLOW_TASKS_SEQUENCE");
        modelBuilder.HasSequence("WORKFLOW_HISTORY_SEQUENCE");
        modelBuilder.HasSequence("WORKFLOW_ID");
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<IdentityUserLogin<string>>();

        modelBuilder.Ignore<IdentityUser<string>>();
        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
