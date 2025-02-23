# Hospital Management System (HMS) - Console Application with Entity Framework

The **Hospital Management System (HMS)** is a console application designed to manage basic hospital operations such as: 
- Patient registration and management. 
- Doctor management. 
- Appointment scheduling. 
- Prescription and medication management. 
- Automatic billing when a prescription is issued. 

This version uses **Entity Framework Core** with **Microsoft SQL Server** and follows the **Code-First Approach**.

##  Key Features 
The application will include the following core functionalities: 
### Core Functionalities 
1- **Patient Management**
  - Register new patients.
  - View and update patient details.
  - Delete patient records.

2- **Doctor Management**
  - Add new doctors.
  - View and update doctor details.
  - Delete doctor records.

3- **Appointment Management**
  - Schedule appointments between patients and doctors.
  - View all appointments by doctor ID or patient ID.
  - Cancel appointments.

4- **Prescription Management**
  - Issue prescriptions to patients.
  - View and update prescriptions.
  - Automatically generate a bill when a prescription is created.

5- **Medication Management**
  - Add new medications.
  - View and update medication details.
  - Track medication inventory.

6- **Billing Management**
  - View and update billing details.
  - Bills are automatically generated when prescriptions are issued.


## **Description of Relationships Between Entities in the ER Diagram**  

1. **Patient - Appointment (One-to-Many)**  
   - A **patient** can have multiple **appointments**.  
   - Each **appointment** is associated with only one **patient**.  

2. **Doctor - Appointment (One-to-Many)**  
   - A **doctor** can have multiple **appointments**.  
   - Each **appointment** is issued by only one **doctor**.  

3. **Patient - Prescription (One-to-Many)**  
   - A **patient** can have multiple **prescriptions**.  
   - Each **prescription** is assigned to only one **patient**.  

4. **Doctor - Prescription (One-to-Many)**  
   - A **doctor** can issue multiple **prescriptions**.  
   - Each **prescription** is issued by only one **doctor**.  

5. **Prescription - Medication (Many-to-Many)**  
   - A **prescription** can contain multiple **medications**.  
   - A **medication** can be part of multiple **prescriptions**.  
   - This requires a **junction table** to establish the relationship.  

6. **Prescription - Bill (One-to-One)**  
   - Each **prescription** is associated with exactly **one bill**.  
   - Each **bill** is generated for a **single prescription**.  

This structure ensures a well-organized hospital management system, accurately reflecting real-world relationships between patients, doctors, appointments, prescriptions, medications, and billing. 🚀

![Image](https://github.com/user-attachments/assets/a8198145-1454-432b-afa4-a8440e93dda7)
