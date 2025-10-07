# 🏥 Clinic Management System (CMS)

A comprehensive **Clinic Management System** designed to streamline clinic operations — including role-based authentication, appointment scheduling, billing and payments, electronic medical records, and automated notifications.

---

##  Table of Contents

* [About the Project](#about-the-project)
* [Features](#features)
* [System Roles](#system-roles)
* [Modules Overview](#modules-overview)
* [Database Design](#database-design)
* [Tech Stack](#tech-stack)
* [Installation](#installation)
* [Usage](#usage)
* [Future Enhancements](#future-enhancements)
* [Contributing](#contributing)

---

##  About the Project

The **Clinic Management System (CMS)** is a digital healthcare platform built to automate and manage clinical workflows efficiently.
It provides different access levels for administrators, doctors, staff, and patients, ensuring secure data handling, fast appointment booking, and seamless billing processes.

---

## ⚙️ Features

* **Role-Based Authentication** (Admin, Doctor, Staff, Patient)
* **OTP-Based Login Validation** for secure access
* **Appointment Scheduling** with real-time availability
* **Dynamic Patient Queue** — Red (Emergency), Orange (Follow-up), Green (Regular)
* **Electronic Medical Records (EMR)** — prescriptions, lab reports, test results
* **Billing & Invoicing** with integrated payment gateway
* **Automated Reminders & Notifications**
* **Audit Logging & Session Tracking** for data integrity and compliance

---

##  System Roles

| Role               | Permissions & Access                                              |
| ------------------ | ----------------------------------------------------------------- |
| **Admin**          | Manage users, roles, appointments, billing templates, and reports |
| **Doctor**         | View patient history, issue prescriptions, update medical records |
| **Staff**          | Schedule appointments, validate bookings, manage queues           |
| **User (Patient)** | Book appointments, access reports, make payments                  |

---

##  Modules Overview

### 1. Authentication & Authorization

* Role-based access control using `User` and `Role` entities
* OTP validation and encrypted password management
* Active session tracking in `User_Sessions`

### 2. Appointments & Queue Management

* Appointment booking and staff validation
* Automatic queue allocation based on priority zones
* Tables: `Appointment`, `Patient_Queue`, `Time_Slots`

### 3. Billing & Payments

* Dynamic billing templates and invoice generation
* Payment gateway integration
* Tables: `Bill_Templates`, `Patient_Bills`, `Invoice`

### 4. Electronic Medical Records (EMR)

* Patient history, prescriptions, and diagnostic reports
* Linked tables: `Patient_Encounter`, `MedicalReports`, `Prescriptions`, `Observations`

### 5. Doctor Visits & Follow-ups

* History access, prescription updates, and lab referrals
* Automated reminders using `Notification_Templates` and `Patient_Notifications`

---

##  Database Design

The CMS uses a **normalized relational database** (see `CMS_DB.pdf`) with UUID-based keys for all entities.
Key tables include:

* `User`, `Doctor`, `Role`
* `Appointment`, `Patient`, `Patient_Encounter`
* `MedicalReports`, `Prescriptions`, `Observations`
* `Bill_Templates`, `Patient_Bills`, `Invoice`
* `Audit_Log`, `User_Sessions`, `Notification_Templates`

---

## 💻 Tech Stack

| Layer               | Technology              |
| ------------------- | ----------------------- |
| **Frontend**        |                         |
|                     |                         |
| **Backend**         |                         |
|                     |                         |
| **Database**        |                         |
|                     |                         |
| **Authentication**  | JWT + OTP validation    |
| **Payment Gateway** |                         |
|                     |                         |
| **Notifications**   | Email / SMS integration |

---

##  Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/yourusername/clinic-management-system.git
   cd clinic-management-system
   ```

2. **Install Dependencies**

   ```bash
   npm install
   # or
   pip install -r requirements.txt
   ```

3. **Set Up Environment Variables**

   ```
   DATABASE_URL=<your_database_url>
   JWT_SECRET=<your_secret_key>
   PAYMENT_API_KEY=<payment_gateway_key>
   etc... pending
   ```

4. **Run the Application**

   ```bash
   npm start
   # or
   python manage.py runserver
   ```

---

##  Usage

* **Admin:** Manage system settings, billing templates, and user accounts.
* **Doctor:** Access patient history, add prescriptions, refer for tests.
* **Staff:** Schedule and confirm appointments, manage patient queues.
* **Patient:** Book appointments, view records, download invoices.

---

##  Future Enhancements

* Teleconsultation integration (video appointments)
* AI-based diagnosis support
* Insurance claim management
* Multi-clinic network integration
* Analytics dashboard for patient and revenue insights

---

##  Contributing

Contributions are welcome!

1. Fork the repo
2. Create a new branch (`feature/your-feature-name`)
3. Commit your changes
4. Open a pull request

---


---

**Developed with ❤️ for better healthcare management.**
