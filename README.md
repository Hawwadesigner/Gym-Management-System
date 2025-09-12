# 🏋️‍♂️ GYM Management System

## 📖 Description

**The GYM Management System** is a complete console-based application written in **C#** with **Entity Framework Core** and **QuestPDF** integration, it manages **Members**, **Trainers**, **Subscriptions**, **Attendance**, and **Payments** with rich set of **Reports** that can be exported to PDF. The system is designed with clean  separations of concerns:
- **Models** define domain entities and relationships.
- **Services** encapsulate business logic and data access.
- **Screens** (UI) handle all user interactions in the console.
- **Helpers** simplify input, validation, and formatting

This project simulates a real-world gym system with CRUD operations, event-driven notification, automated subscription checking with timers, and comprehensive reporting.

---

## ✨ Features

- 👤 Manage **Members** (Add, View, Update, Delete, Assign Trainer, Find By Id/Phone)
- 🧑‍🏫 Manage **Trainers** (Add, View, Update)
- 📅 Manage **Subscriptions** (Add, View, Update, Delete, Auto Renew)
- 💰 Manage **Payments** linked to subscriptions
- 📝 Track **Attendance** with prevention of duplicate entries per day
- 📊 Generate rich **Reports**:
  - Members whose subscriptions are about to expire
  - Members list by trainer
  - Revenue by month with breakdown (Standard, Premium, VIP)
  - Most active members By Attendance
- 📂 Export reports to **PDF** using QuestPDF
- 🔔 Event-driven **Notification** for:
  - Subscription Added
  - Subscription Ending
  - Subscription About To Expire
  - Attendance Recorded
- 💻 Clean and structured **Console Menus** with proper formatting

---

## 📂 Project Structure

```
/ GYM_System
│
├─ Program.cs                # Entry point -> loads MainMenuScreen
│
├─ Data/
│ └─ AppDbContext.cs         # EF Core DbContext (DbSets for all Models)
│
├─ Models/                   # Domain models
│ ├─ PersonModel.cs          # Base class for Member & Trainer
│ ├─ MemberModel.cs          # Member entity with subscriptions & attendance
│ ├─ TrainerModel.cs         # Trainer entity with salary & specialization
│ ├─ SpecializationModel.cs  # Specialization linked to Trainer
│ ├─ SubscriptionModel.cs    # Subscription entity with ServiceLevel & PlanType
│ ├─ AttendanceModel.cs      # Attendance tracking for members
│ ├─ AttendanceReportModel.cs# Report model for attendance count
│ ├─ PaymentModel.cs         # Payment linked to subscription
│ ├─ AddressModel.cs         # Owned type inside Member (City, Region, Street...)
│ └─ Enums.cs                # enServiceLevel, enPlanType, enStatus, enPaymentType
│
├─ Services/                 # Business logic & data access
│ ├─ BaseService.cs          # Generic CRUD + GetById/GetAllLazy
│ ├─ MemberService.cs        # Members + Delete with cascade + IsAttendanceBefore
│ ├─ TrainerService.cs       # Trainers CRUD
│ ├─ SubscriptionService.cs  # Subscriptions CRUD + OnSubscriptionAdded event
│ ├─ SubscriptionChecker.cs  # Timer-based subscription expiry check + events
│ ├─ AttendanceService.cs    # Attendance CRUD + OnAttendanceRecorded event
│ ├─ PaymentsService.cs      # Payments CRUD
│ ├─ ReportService.cs        # Queries for reports
│ └─ GymPricingService.cs    # Static price calculator by ServiceLevel & PlanType
│
├─ Screens/                  # Console UI
│ ├─ MainMenuScreen.cs       # Main entry menu
│ │
│ ├─ Member/
│ │ ├─ MembersManagementMenu.cs
│ │ ├─ AddMemberScreen.cs
│ │ ├─ ViewMemberScreen.cs
│ │ ├─ UpdateMemberScreen.cs
│ │ ├─ DeleteMemberScreen.cs
│ │ ├─ FindMemberScreen.cs (Find by Id/Phone)
│ │ ├─ AssignTrainerToMemberScreen.cs
│ │ ├─ Attendance/
│ │ │ ├─ AttendanceManagementMenu.cs
│ │ │ ├─ RecordAttendanceScreen.cs
│ │ │ └─ ViewAttendanceScreen.cs
│ │ └─ Subscription/
│ │   ├─ SubscriptionsManagementMenu.cs
│ │   ├─ AddSubscriptionScreen.cs
│ │   ├─ ViewSubscriptionsScreen.cs
│ │   ├─ UpdateSubscriptionScreen.cs
│ │   ├─ DeleteSubscriptionScreen.cs
│ │   └─ Payments/
│ │     ├─ AddPaymentsScreen.cs
│ │     ├─ ViewPaymentsScreen.cs
│ │     └─ UpdatePaymentsScreen.cs
│ │
│ ├─ Trainer/
│ │ ├─ TrainersManagementMenu.cs
│ │ ├─ AddTrainerScreen.cs
│ │ ├─ ViewTrainersScreen.cs
│ │ └─ UpdateTrainerScreen.cs
│ │
│ └─ Reports/
│   ├─ ReportMenuScreen.cs
│   ├─ ConsoleUI/
│   │ ├─ ReportConsoleRenderers.cs
│   │ └─ ReportConsoleTitle.cs
│   ├─ Core/
│   │ ├─ ReportsCatalog.cs
│   │ └─ ReportDifinationModel.cs
│   └─ PDF/
│     ├─ ReportPdfGenerator.cs
│     └─ ReportPdfRenderers.cs
│
├─ Helper/
│ ├─ CheckHelper.cs
│ ├─ InputHelper.cs
│ ├─ ConsoleUIHelper.cs
│ ├─ NotificationHelper.cs
│ ├─ PersonInputHelper.cs
│ ├─ PersonDisplayHelper.cs
│ ├─ MemberInputHelper.cs
│ ├─ TrainerInputHelper.cs
│ ├─ SubscriptionInputHelper.cs
│ └─ PaymentInputHelper.cs
│
├─ Exceptions/               # Custom exceptions
│
├─ Migrations/               # EF Core Migrations (InitialCreate + Snapshot)
│
└─ README.md
```
---

## 🔗 Models & Relationships

- **Member** ↔ **Trainer** → Many Members per Trainer
- **Member** ↔ **Subscription** → One Member, Many Subscriptions
- **Member** ↔ **Attendance** → One Member, Many Attendance Records
- **Subscription** ↔ **Payment** → One-to-One (each subscription has one payment)
- **Trainer** ↔ **Specialization** → One-to-One

```
Trainer 1 ── * Member 1 ── * Subscription 1 ── 1 Payment
                      │
                      └── * Attendance
```
---

## 🧾 Properties of Models

### 👤 MemberModel
- Id, FullName, Phone, Email
- DateOfBirth
- Address (City, Region, Street, Building)
- TrainerId, Trainer
- ICollection 
- ICollection
### 🧑‍🏫 TrainerModel
- Id, FullName, Phone, Email
- Salary
- Specialization
- ICollection
### 📘 SubscriptionModel
- Id
- cDateSubscription (StartDate, EndDate)
- ServiceLevel (Standard, Premium, VIP)
- PlanType (Monthly, Yearly)
- Price
- Status (Active, Inactive)
- IsAutoRenew
- MemberId, Member
- Payment
### 💰 PaymentModel
- Id
- Date
- PaymentType (Cash, Card)
- Amount
- SubscriptionId, Subscription
### 📝 AttendanceModel
- Id
- Date
- MemberId, Member
### 🏷 SpecializationModel
- Id
- Name
- TrainerId, Trainer
### 🏠 AddressModel (Owned by Member)
- City, Region, Street, Building
### 📊 AttendanceReportModel
- MemberName
- AttendanceCount

---

## 🛠 Services Overview

- **BaseService** → Generic CRUD operations
- **MemberService** → Delete with cascade (Attendance + Subscriptions), check duplicate attendance
- **TrainerService** → Manage trainers
- **SubscriptionService** → Add/Delete subscriptions, fire OnSubscriptionAdded event
- **SubscriptionChecker** → Timer-based checker for expiring subscriptions (fires OnSubscriptionEnd & OnSubscriptionAboutToExpire)
- **AttendanceService** → Add attendance, fire OnAttendanceRecorded event
- **PaymentsService** → Manage subscription payments
- **ReportService** → Build datasets for reports (expiring, by trainer, revenue, attendance)
- **GymPricingService** → Calculate price by ServiceLevel & PlanType

---

## 🖥 Console Flow

```
Main Menu
├─ Manage Members
│ ├─ Add / View / Update / Delete
│ ├─ Assign Trainer
│ ├─ Find by Id/Phone
│ └─ Manage Attendance
│   ├─ Record Attendance
│   └─ View Attendance
│ └─ Manage Subscriptions
│   ├─ Add / View / Update / Delete
│   └─ Manage Payments (Add/View/Update)
│
├─ Manage Trainers (Add / View / Update)
├─ Reports (4 types with Console + PDF)
└─ Exit
```
---

## 🚀 Quick Start

```bash
# 1. Clone the repository
git clone https://github.com/Kenzy-Ragab/Gym-Management-System
cd Gym-Management-System

# 2. Apply EF migrations
dotnet ef database update

# 3. Build & run the project
dotnet run

# 4. Navigate the console menus 🎛 and explore features
```
---

## 🧰 Tech Stack

- **C# .NET 8**
- **Entity Framework Core 9**
- **QuestPDF** (report PDF generation)
- **SQL Server** (EF migrations)
- **Console Application**

---

## 👀 Preview

Example: of Console Menu

```
╔══════════════════════════════════════════╗
║                MAIN MENU                 ║
╠══════════════════════════════════════════╣
║[1] Manage Members                        ║
║[2] Manage Attendance                     ║
║[3] Manage Subscriptions                  ║
║[4] Manage Trainers                       ║
║[5] Reports                               ║
║[6] Exit                                  ║
╚══════════════════════════════════════════╝
```
---

## 📄 Sample

Example: View Trainers Screen

```
┌──┬──────────────────┬────────────────┬───────────────────────┬──────────┬──────────────────┐
│ID│ Full Name        │ Phone          │ Email                 │ Salary   │ Specialization   │
├──┼──────────────────┼────────────────┼───────────────────────┼──────────┼──────────────────┤
│ 1│ Malak Ahmed      │ 0123456789     │ malakahmed@gmail.com  │ 8000     │ Cardio           │
└──┴──────────────────┴────────────────┴───────────────────────┴──────────┴──────────────────┘
```
---

## 📊 Sample of Report

Example: Revenue in Specific Month (Console)

```
==========================================
           REVENUE – MONTH September
==========================================
 Service Level        |          Revenue
------------------------------------------
 Standard             |        $1,500.00
 Premium              |        $3,200.00
 VIP                  |        $5,000.00
------------------------------------------
```
Generated also as PDF:

```
Revenue_Month_5.pdf
```
---

## 🧪 Example

Add Subscription Flow:
 1. Select Add Subscription
 2. Choose member
 3. Enter start date
 4. Choose service level & plan type
 5. System auto-calculates end date, price, and status
 6. Subscription saved & OnSubscriptionAdded event triggered

 ---

## 📚 What I Learned

- Structuring large console applications with clear separation of concerns
- Using **Entity Framework Core** for data persistence & relationships
- Handling events in **C#** (delegates for subscription/attendance notifications)
- Implementing timers for background checks (subscription expiry)
- Generating professional PDF reports with QuestPDF
- Designing clean console UI with formatted tables

---

## 🔮 Future Enhancement

- 🌐 Add GUI (WinForms/WPF/Blazor)
- 🛡 Add Authentication & Roles (Admin, Trainer, Member)
- ☁️ Host with real SQL Server / Cloud DB
- 📱 Mobile app integration
- 📈 Advanced analytics (attendance trends, revenue forecast)
- 🔔 Email/SMS notifications instead of console only

---

## 🤍 Task Requirement  in Breakin Point (Student Activity)

📎 [Task Requirement  (Google Drive)](https://drive.google.com/drive/u/1/folders/1sb7paWmxPK0UtUOy_JzGELNE5tkZX3az)

Made with ❤️ by **Kenzy Ragab**

Feel free to **fork**, **use**, or **contribute** to this project!
