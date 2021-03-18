/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2016                    */
/* Created on:     16.01.2018 21:36:26                          */
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
   where r.fkeyid = object_id('Deal_tab') and o.name = 'FK_DEAL_TAB_MOVE_DECI_DECISION')
alter table Deal_tab
   drop constraint FK_DEAL_TAB_MOVE_DECI_DECISION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Deal_tab') and o.name = 'FK_DEAL_TAB_MOVE_FAIL_FAILURE_')
alter table Deal_tab
   drop constraint FK_DEAL_TAB_MOVE_FAIL_FAILURE_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Deal_tab') and o.name = 'FK_DEAL_TAB_MOVE_MADE_MADE_BUY')
alter table Deal_tab
   drop constraint FK_DEAL_TAB_MOVE_MADE_MADE_BUY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Deal_tab') and o.name = 'FK_DEAL_TAB_RESPONSIB_MANAGER_')
alter table Deal_tab
   drop constraint FK_DEAL_TAB_RESPONSIB_MANAGER_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Decision_buy_tab') and o.name = 'FK_DECISION_HANDLING__FUNNEL_T')
alter table Decision_buy_tab
   drop constraint FK_DECISION_HANDLING__FUNNEL_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Decision_buy_tab') and o.name = 'FK_DECISION_MOVE_DECI_DEAL_TAB')
alter table Decision_buy_tab
   drop constraint FK_DECISION_MOVE_DECI_DEAL_TAB
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Failure_buy_tab') and o.name = 'FK_FAILURE__HANDLING__FUNNEL_T')
alter table Failure_buy_tab
   drop constraint FK_FAILURE__HANDLING__FUNNEL_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Failure_buy_tab') and o.name = 'FK_FAILURE__MOVE_FAIL_DEAL_TAB')
alter table Failure_buy_tab
   drop constraint FK_FAILURE__MOVE_FAIL_DEAL_TAB
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Initial_contact_tab') and o.name = 'FK_INITIAL__HANDLING__FUNNEL_T')
alter table Initial_contact_tab
   drop constraint FK_INITIAL__HANDLING__FUNNEL_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Made_buy_tab') and o.name = 'FK_MADE_BUY_HANDLING__FUNNEL_T')
alter table Made_buy_tab
   drop constraint FK_MADE_BUY_HANDLING__FUNNEL_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Made_buy_tab') and o.name = 'FK_MADE_BUY_MOVE_MADE_DEAL_TAB')
alter table Made_buy_tab
   drop constraint FK_MADE_BUY_MOVE_MADE_DEAL_TAB
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Manager_tab') and o.name = 'FK_MANAGER__CHOICE_FUNNEL_T')
alter table Manager_tab
   drop constraint FK_MANAGER__CHOICE_FUNNEL_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Manager_tab') and o.name = 'FK_MANAGER__EXECUTION_TARGET_T')
alter table Manager_tab
   drop constraint FK_MANAGER__EXECUTION_TARGET_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Target_tab') and o.name = 'FK_TARGET_T_COMPARISO_ANALYTIC')
alter table Target_tab
   drop constraint FK_TARGET_T_COMPARISO_ANALYTIC
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
            from  sysindexes
           where  id    = object_id('Deal_tab')
            and   name  = 'move_decision_FK'
            and   indid > 0
            and   indid < 255)
   drop index Deal_tab.move_decision_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Deal_tab')
            and   name  = 'move_made_FK'
            and   indid > 0
            and   indid < 255)
   drop index Deal_tab.move_made_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Deal_tab')
            and   name  = 'move_failure_FK'
            and   indid > 0
            and   indid < 255)
   drop index Deal_tab.move_failure_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Deal_tab')
            and   type = 'U')
   drop table Deal_tab
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Decision_buy_tab')
            and   name  = 'move_decision2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Decision_buy_tab.move_decision2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Decision_buy_tab')
            and   name  = 'handling_decision_FK'
            and   indid > 0
            and   indid < 255)
   drop index Decision_buy_tab.handling_decision_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Decision_buy_tab')
            and   type = 'U')
   drop table Decision_buy_tab
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Failure_buy_tab')
            and   name  = 'move_failure2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Failure_buy_tab.move_failure2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Failure_buy_tab')
            and   name  = 'handling_failure_FK'
            and   indid > 0
            and   indid < 255)
   drop index Failure_buy_tab.handling_failure_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Failure_buy_tab')
            and   type = 'U')
   drop table Failure_buy_tab
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
           where  id    = object_id('Made_buy_tab')
            and   name  = 'move_made2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Made_buy_tab.move_made2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Made_buy_tab')
            and   name  = 'handling_made_FK'
            and   indid > 0
            and   indid < 255)
   drop index Made_buy_tab.handling_made_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Made_buy_tab')
            and   type = 'U')
   drop table Made_buy_tab
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Manager_tab')
            and   name  = 'choice_FK'
            and   indid > 0
            and   indid < 255)
   drop index Manager_tab.choice_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Manager_tab')
            and   name  = 'execution_FK'
            and   indid > 0
            and   indid < 255)
   drop index Manager_tab.execution_FK
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
            and   name  = 'comparison_FK'
            and   indid > 0
            and   indid < 255)
   drop index Target_tab.comparison_FK
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
   id_analytics         int                  IDENTITY(1,1),
   id_funnel            int                  not null,
   percent_target_fin   int                  null,
   sum_sale_target_fin  int                  null,
   set_call_target_fin  int                  null,
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
   id_company           int                  IDENTITY(1,1),
   name_company         varchar(20)          not null,
   pass_company         varchar(20)          not null,
   constraint PK_COMPANY_TAB primary key (id_company)
)
go

/*==============================================================*/
/* Table: Deal_tab                                              */
/*==============================================================*/
create table Deal_tab (
   id_deal              int                  IDENTITY(1,1),
   id_failure_buy       int                  null,
   id_made_buy          int                  null,
   id_decision_buy      int                  null,
   id_initial_contact   int                  not null,
   id_manager           int                  not null,
   name_product_deal    text                 not null,
   date_deal            datetime             not null,
   sum_deal             int                  not null,
   set_call_deal        int                  not null,
   constraint PK_DEAL_TAB primary key (id_deal)
)
go

/*==============================================================*/
/* Index: move_failure_FK                                       */
/*==============================================================*/




create nonclustered index move_failure_FK on Deal_tab (id_failure_buy ASC)
go

/*==============================================================*/
/* Index: move_made_FK                                          */
/*==============================================================*/




create nonclustered index move_made_FK on Deal_tab (id_made_buy ASC)
go

/*==============================================================*/
/* Index: move_decision_FK                                      */
/*==============================================================*/




create nonclustered index move_decision_FK on Deal_tab (id_decision_buy ASC)
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
/* Table: Decision_buy_tab                                      */
/*==============================================================*/
create table Decision_buy_tab (
   id_decision_buy      int                  IDENTITY(1,1),
   id_funnel            int                  not null,
   id_deal              int                  not null,
   set_decision_buy     int                  null,
   constraint PK_DECISION_BUY_TAB primary key (id_decision_buy)
)
go

/*==============================================================*/
/* Index: handling_decision_FK                                  */
/*==============================================================*/




create nonclustered index handling_decision_FK on Decision_buy_tab (id_funnel ASC)
go

/*==============================================================*/
/* Index: move_decision2_FK                                     */
/*==============================================================*/




create nonclustered index move_decision2_FK on Decision_buy_tab (id_deal ASC)
go

/*==============================================================*/
/* Table: Failure_buy_tab                                       */
/*==============================================================*/
create table Failure_buy_tab (
   id_failure_buy       int                  IDENTITY(1,1),
   id_funnel            int                  not null,
   id_deal              int                  not null,
   set_failure_buy      int                  null,
   constraint PK_FAILURE_BUY_TAB primary key (id_failure_buy)
)
go

/*==============================================================*/
/* Index: handling_failure_FK                                   */
/*==============================================================*/




create nonclustered index handling_failure_FK on Failure_buy_tab (id_funnel ASC)
go

/*==============================================================*/
/* Index: move_failure2_FK                                      */
/*==============================================================*/




create nonclustered index move_failure2_FK on Failure_buy_tab (id_deal ASC)
go

/*==============================================================*/
/* Table: Funnel_tab                                            */
/*==============================================================*/
create table Funnel_tab (
   id_funnel            int                  IDENTITY(1,1),
   set_contacts_f       int                  null,
   set_deal_f           int                  null,
   constraint PK_FUNNEL_TAB primary key (id_funnel)
)
go

/*==============================================================*/
/* Table: Initial_contact_tab                                   */
/*==============================================================*/
create table Initial_contact_tab (
   id_initial_contact   int                  IDENTITY(1,1),
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
/* Table: Made_buy_tab                                          */
/*==============================================================*/
create table Made_buy_tab (
   id_made_buy          int                  IDENTITY(1,1),
   id_funnel            int                  not null,
   id_deal              int                  not null,
   set_made_buy         int                  null,
   constraint PK_MADE_BUY_TAB primary key (id_made_buy)
)
go

/*==============================================================*/
/* Index: handling_made_FK                                      */
/*==============================================================*/




create nonclustered index handling_made_FK on Made_buy_tab (id_funnel ASC)
go

/*==============================================================*/
/* Index: move_made2_FK                                         */
/*==============================================================*/




create nonclustered index move_made2_FK on Made_buy_tab (id_deal ASC)
go

/*==============================================================*/
/* Table: Manager_tab                                           */
/*==============================================================*/
create table Manager_tab (
   id_manager           int                  IDENTITY(1,1),
   id_target_c          int                  not null,
   id_funnel            int                  not null,
   pass_manager         varchar(10)          not null,
   name_manager         text                 not null,
   surname_manager      text                 not null,
   gender_manager       text                 null,
   set_call_tm          int                  null,
   sum_sale_tm          int                  null,
   constraint PK_MANAGER_TAB primary key (id_manager)
)
go

/*==============================================================*/
/* Index: execution_FK                                          */
/*==============================================================*/




create nonclustered index execution_FK on Manager_tab (id_target_c ASC)
go

/*==============================================================*/
/* Index: choice_FK                                             */
/*==============================================================*/




create nonclustered index choice_FK on Manager_tab (id_funnel ASC)
go

/*==============================================================*/
/* Table: Target_tab                                            */
/*==============================================================*/
create table Target_tab (
   id_target_c          int                  IDENTITY(1,1),
   id_company           int                  not null,
   id_analytics         int                  not null,
   date_target_c        datetime             not null,
   set_call_target_c    int                  not null,
   sum_sale_target_c    int                  not null,
   constraint PK_TARGET_TAB primary key (id_target_c)
)
go

/*==============================================================*/
/* Index: installation_FK                                       */
/*==============================================================*/




create nonclustered index installation_FK on Target_tab (id_company ASC)
go

/*==============================================================*/
/* Index: comparison_FK                                         */
/*==============================================================*/




create nonclustered index comparison_FK on Target_tab (id_analytics ASC)
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
   add constraint FK_DEAL_TAB_MOVE_DECI_DECISION foreign key (id_decision_buy)
      references Decision_buy_tab (id_decision_buy)
go

alter table Deal_tab
   add constraint FK_DEAL_TAB_MOVE_FAIL_FAILURE_ foreign key (id_failure_buy)
      references Failure_buy_tab (id_failure_buy)
go

alter table Deal_tab
   add constraint FK_DEAL_TAB_MOVE_MADE_MADE_BUY foreign key (id_made_buy)
      references Made_buy_tab (id_made_buy)
go

alter table Deal_tab
   add constraint FK_DEAL_TAB_RESPONSIB_MANAGER_ foreign key (id_manager)
      references Manager_tab (id_manager)
go

alter table Decision_buy_tab
   add constraint FK_DECISION_HANDLING__FUNNEL_T foreign key (id_funnel)
      references Funnel_tab (id_funnel)
go

alter table Decision_buy_tab
   add constraint FK_DECISION_MOVE_DECI_DEAL_TAB foreign key (id_deal)
      references Deal_tab (id_deal)
go

alter table Failure_buy_tab
   add constraint FK_FAILURE__HANDLING__FUNNEL_T foreign key (id_funnel)
      references Funnel_tab (id_funnel)
go

alter table Failure_buy_tab
   add constraint FK_FAILURE__MOVE_FAIL_DEAL_TAB foreign key (id_deal)
      references Deal_tab (id_deal)
go

alter table Initial_contact_tab
   add constraint FK_INITIAL__HANDLING__FUNNEL_T foreign key (id_funnel)
      references Funnel_tab (id_funnel)
go

alter table Made_buy_tab
   add constraint FK_MADE_BUY_HANDLING__FUNNEL_T foreign key (id_funnel)
      references Funnel_tab (id_funnel)
go

alter table Made_buy_tab
   add constraint FK_MADE_BUY_MOVE_MADE_DEAL_TAB foreign key (id_deal)
      references Deal_tab (id_deal)
go

alter table Manager_tab
   add constraint FK_MANAGER__CHOICE_FUNNEL_T foreign key (id_funnel)
      references Funnel_tab (id_funnel)
go

alter table Manager_tab
   add constraint FK_MANAGER__EXECUTION_TARGET_T foreign key (id_target_c)
      references Target_tab (id_target_c)
go

alter table Target_tab
   add constraint FK_TARGET_T_COMPARISO_ANALYTIC foreign key (id_analytics)
      references Analytics_tab (id_analytics)
go

alter table Target_tab
   add constraint FK_TARGET_T_INSTALLAT_COMPANY_ foreign key (id_company)
      references Company_tab (id_company)
go

