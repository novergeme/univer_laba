/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2016                    */
/* Created on:     25.01.2018 1:38:52                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Analytics_tab') and o.name = 'FK_ANALYTIC_EXPORT_FUNNEL_T')
alter table Analytics_tab
   drop constraint FK_ANALYTIC_EXPORT_FUNNEL_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Deal_tab') and o.name = 'FK_DEAL_TAB_CONVERTIN_INITIAL_')
alter table Deal_tab
   drop constraint FK_DEAL_TAB_CONVERTIN_INITIAL_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Deal_tab') and o.name = 'FK_DEAL_TAB_RESPONSIB_MANAGER_')
alter table Deal_tab
   drop constraint FK_DEAL_TAB_RESPONSIB_MANAGER_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Funnel_tab') and o.name = 'FK_FUNNEL_T_CONDUCT_COMPANY_')
alter table Funnel_tab
   drop constraint FK_FUNNEL_T_CONDUCT_COMPANY_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Initial_contact_tab') and o.name = 'FK_INITIAL__HANDLING__FUNNEL_T')
alter table Initial_contact_tab
   drop constraint FK_INITIAL__HANDLING__FUNNEL_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Manager_stat_tab') and o.name = 'FK_MANAGER__SAVE_STAT_MANAGER_')
alter table Manager_stat_tab
   drop constraint FK_MANAGER__SAVE_STAT_MANAGER_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Manager_tab') and o.name = 'FK_MANAGER__REGISTR_COMPANY_')
alter table Manager_tab
   drop constraint FK_MANAGER__REGISTR_COMPANY_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Target_tab') and o.name = 'FK_TARGET_T_INSTALLAT_COMPANY_')
alter table Target_tab
   drop constraint FK_TARGET_T_INSTALLAT_COMPANY_
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Analytics_tab')
            and   name  = 'export_FK'
            and   indid > 0
            and   indid < 255)
   drop index Analytics_tab.export_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Analytics_tab')
            and   type = 'U')
   drop table Analytics_tab
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Company_tab')
            and   type = 'U')
   drop table Company_tab
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Deal_tab')
            and   name  = 'responsible_FK'
            and   indid > 0
            and   indid < 255)
   drop index Deal_tab.responsible_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Deal_tab')
            and   name  = 'converting_FK'
            and   indid > 0
            and   indid < 255)
   drop index Deal_tab.converting_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Deal_tab')
            and   type = 'U')
   drop table Deal_tab
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Funnel_tab')
            and   name  = 'conduct_FK'
            and   indid > 0
            and   indid < 255)
   drop index Funnel_tab.conduct_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Funnel_tab')
            and   type = 'U')
   drop table Funnel_tab
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Initial_contact_tab')
            and   name  = 'handling_initial_FK'
            and   indid > 0
            and   indid < 255)
   drop index Initial_contact_tab.handling_initial_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Initial_contact_tab')
            and   type = 'U')
   drop table Initial_contact_tab
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Manager_stat_tab')
            and   name  = 'save_stat_FK'
            and   indid > 0
            and   indid < 255)
   drop index Manager_stat_tab.save_stat_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Manager_stat_tab')
            and   type = 'U')
   drop table Manager_stat_tab
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Manager_tab')
            and   name  = 'registr_FK'
            and   indid > 0
            and   indid < 255)
   drop index Manager_tab.registr_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Manager_tab')
            and   type = 'U')
   drop table Manager_tab
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Target_tab')
            and   name  = 'installation_FK'
            and   indid > 0
            and   indid < 255)
   drop index Target_tab.installation_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Target_tab')
            and   type = 'U')
   drop table Target_tab
go

/*==============================================================*/
/* Table: Analytics_tab                                         */
/*==============================================================*/
create table Analytics_tab (
   id_analytics         int                  not null,
   id_funnel            int                  not null,
   date_analytics       datetime             null,
   sum_sale_target_fin  int                  null,
   set_call_target_fin  int                  null,
   percent_target_fin   int                  null,
   constraint PK_ANALYTICS_TAB primary key (id_analytics)
)
go

/*==============================================================*/
/* Index: export_FK                                             */
/*==============================================================*/




create nonclustered index export_FK on Analytics_tab (id_funnel ASC)
go

/*==============================================================*/
/* Table: Company_tab                                           */
/*==============================================================*/
create table Company_tab (
   id_company           int                  not null,
   name_company         varchar(20)          not null,
   pass_company         varchar(20)          not null,
   constraint PK_COMPANY_TAB primary key (id_company)
)
go

/*==============================================================*/
/* Table: Deal_tab                                              */
/*==============================================================*/
create table Deal_tab (
   id_deal              int                  not null,
   id_initial_contact   int                  not null,
   id_manager           int                  not null,
   name_product_deal    varchar(20)          not null,
   date_deal            datetime             not null,
   sum_deal             int                  null,
   set_call_deal        int                  null,
   how_step             int                  null,
   constraint PK_DEAL_TAB primary key (id_deal)
)
go

/*==============================================================*/
/* Index: converting_FK                                         */
/*==============================================================*/




create nonclustered index converting_FK on Deal_tab (id_initial_contact ASC)
go

/*==============================================================*/
/* Index: responsible_FK                                        */
/*==============================================================*/




create nonclustered index responsible_FK on Deal_tab (id_manager ASC)
go

/*==============================================================*/
/* Table: Funnel_tab                                            */
/*==============================================================*/
create table Funnel_tab (
   id_funnel            int                  not null,
   id_company           int                  not null,
   name_funnel          varchar(20)          not null,
   set_deal_f           int                  null,
   set_contacts_f       int                  null,
   constraint PK_FUNNEL_TAB primary key (id_funnel)
)
go

/*==============================================================*/
/* Index: conduct_FK                                            */
/*==============================================================*/




create nonclustered index conduct_FK on Funnel_tab (id_company ASC)
go

/*==============================================================*/
/* Table: Initial_contact_tab                                   */
/*==============================================================*/
create table Initial_contact_tab (
   id_initial_contact   int                  not null,
   id_funnel            int                  not null,
   num_tel_initial_contact varchar(11)          not null,
   name_initial_contact text                 not null,
   source_traf_initial_contact text                 not null,
   constraint PK_INITIAL_CONTACT_TAB primary key (id_initial_contact)
)
go

/*==============================================================*/
/* Index: handling_initial_FK                                   */
/*==============================================================*/




create nonclustered index handling_initial_FK on Initial_contact_tab (id_funnel ASC)
go

/*==============================================================*/
/* Table: Manager_stat_tab                                      */
/*==============================================================*/
create table Manager_stat_tab (
   id_stat_manag        int                  not null,
   id_manager           int                  not null,
   date_stat_manag      datetime             null,
   set_call_mf          int                  null,
   sum_sale_mf          int                  null,
   indiv_targ_call      int                  null,
   indiv_targ_sale      int                  null,
   win_deal             int                  null,
   fail_deal            int                  null,
   no_touch             int                  null,
   convers_man          int                  null,
   constraint PK_MANAGER_STAT_TAB primary key (id_stat_manag)
)
go

/*==============================================================*/
/* Index: save_stat_FK                                          */
/*==============================================================*/




create nonclustered index save_stat_FK on Manager_stat_tab (id_manager ASC)
go

/*==============================================================*/
/* Table: Manager_tab                                           */
/*==============================================================*/
create table Manager_tab (
   id_manager           int                  not null,
   id_company           int                  not null,
   login_manager        varchar(20)          not null,
   pass_manager         varchar(20)          not null,
   name_manager         varchar(20)          not null,
   surname_manager      varchar(20)          null,
   gender_manager       varchar(3)           null,
   constraint PK_MANAGER_TAB primary key (id_manager)
)
go

/*==============================================================*/
/* Index: registr_FK                                            */
/*==============================================================*/




create nonclustered index registr_FK on Manager_tab (id_company ASC)
go

/*==============================================================*/
/* Table: Target_tab                                            */
/*==============================================================*/
create table Target_tab (
   id_target_c          int                  not null,
   id_company           int                  not null,
   date_target_c        datetime             not null,
   set_call_target_c    int                  not null,
   sum_sale_target_c    int                  null,
   set_call_tm          int                  null,
   sum_sale_tm          int                  null,
   constraint PK_TARGET_TAB primary key (id_target_c)
)
go

/*==============================================================*/
/* Index: installation_FK                                       */
/*==============================================================*/




create nonclustered index installation_FK on Target_tab (id_company ASC)
go

alter table Analytics_tab
   add constraint FK_ANALYTIC_EXPORT_FUNNEL_T foreign key (id_funnel)
      references Funnel_tab (id_funnel)
go

alter table Deal_tab
   add constraint FK_DEAL_TAB_CONVERTIN_INITIAL_ foreign key (id_initial_contact)
      references Initial_contact_tab (id_initial_contact)
go

alter table Deal_tab
   add constraint FK_DEAL_TAB_RESPONSIB_MANAGER_ foreign key (id_manager)
      references Manager_tab (id_manager)
go

alter table Funnel_tab
   add constraint FK_FUNNEL_T_CONDUCT_COMPANY_ foreign key (id_company)
      references Company_tab (id_company)
go

alter table Initial_contact_tab
   add constraint FK_INITIAL__HANDLING__FUNNEL_T foreign key (id_funnel)
      references Funnel_tab (id_funnel)
go

alter table Manager_stat_tab
   add constraint FK_MANAGER__SAVE_STAT_MANAGER_ foreign key (id_manager)
      references Manager_tab (id_manager)
go

alter table Manager_tab
   add constraint FK_MANAGER__REGISTR_COMPANY_ foreign key (id_company)
      references Company_tab (id_company)
go

alter table Target_tab
   add constraint FK_TARGET_T_INSTALLAT_COMPANY_ foreign key (id_company)
      references Company_tab (id_company)
go

