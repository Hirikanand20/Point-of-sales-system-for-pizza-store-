# Point of Sales System

## Overview
This project is a Point of Sales (POS) system designed for a pizza shop. It is a Windows Form application developed using the .NET framework and C#. The system allows two types of users to login - Admin and Employees.

## Features
- Login Page
  
![Screenshot 2024-05-19 201921](https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-/assets/76699698/3e8c98b8-71fa-4545-a0fe-3aed0ed76862)

- Administrator Controls
  
  ![image](https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-/assets/76699698/f32596b9-8d93-44e8-bc8c-8b3c7250f3f6)


- Creating new Employees credentials

![image](https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-/assets/76699698/2ea50e06-77ef-4363-a771-1899ccd0be5c)

- Price adjustments

![image](https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-/assets/76699698/6f7b634d-8bfe-4d76-82b1-7a9c867a00fc)

- Point of Sales Tab

  ![image](https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-/assets/76699698/bee30c5c-d299-4f5b-864b-65d164413c75)

- Order Recipt Tab

  ![image](https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-/assets/76699698/11fea470-d00e-4b86-a009-96c4694c542a)



![image](https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-/assets/76699698/4b69adb6-e134-4821-898f-acefdfab92f1)


  




### Admin
- Create employee IDs.
- Change or set new prices for various types of pizza.
- Register a sale.

### Employees
- Register a sale on the POS machine.
- Take customer name and phone number and add it to the system for discounts.
- Generate a receipt for the customer.

## Discounts
- New customers will avail a 10% discount.
- Existing customers will avail a 20% discount on their total bill.

## Testing
A sub-project associated with this one is Testing. We use C# and NUnit framework to perform integration and unit testing on the application.


![image](https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-/assets/76699698/5bb6117f-ed12-44e3-9a88-4bb4c2c08fcf)

## Getting Started

These instructions will guide you on how to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- Visual Studio 2022
- .NET Framework v4.7.2
- C# v7.3
- NUnit v3.12.0

### Installation

1. Clone the repository: `git clone https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-.git`
2. Navigate to the project directory: `cd Point-of-sales-system-for-pizza-store-`

### Configuration

1. **Attach the three database files** present in the Database project manually to your local database server. To do this, follow the steps below:

    1. Open **SQL Server Management Studio (SSMS)**.
    2. Connect to your local server.
    3. Click on **File > Open > File...** and navigate to your `.sql` file in the database folder in the project directory.
    4. With the file open in the SSMS interface, click **Execute**. Repeat this process for all three SQL files.


  ![image](https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-/assets/76699698/489ee78e-697f-42b0-92bb-864a4c3b3f34)

  2. **Connect to the local server with the required databases**. To do this, follow the steps below:


     1. In Visual studio , open the **SQL Server Object Explorer** tab from the **View** menu at the 
        top.
     2. Click on the **Add SQL Server** option.
     3. Connect to the local server which has the required databases added in step one.


![image](https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-/assets/76699698/6a0f9aa7-efbf-49cb-89fc-0a551739b878)



3. **Retrieve the databases from the attached SQL Server in Visual Studio**. To do this, follow the steps below:

    1. Open **Server Explorer** from the **View** menu at the top.
    2. Right-click on **Data Connections** and then click on **Add Connection** option.
    3. Change the **Data Source** to **Microsoft SQL Server**.
    4. Write the name of the local server in the field. It will automatically scan all the databases in the server.
    5. Select the database which you added in step 1. 


![image](https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-/assets/76699698/ba76db52-914f-4e22-8b58-52563350d760)



4. **Connect the database with various program files**. To do this, follow the steps below:

    1. Click on the **database name** in the **Server Explorer**.
    2. In the **Properties** window, find the **Connection String** property and **copy** the connection string.
  
     ![image](https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-/assets/76699698/2182c8dd-063e-4e57-ad3c-81d38a54a9f2)

  
    3. Open the program file where the database connection is established. Look for the **SQL connection object** in the code.
    4. **Replace** the existing connection string in the SQL connection object with the connection string you copied.

![image](https://github.com/Hirikanand20/Point-of-sales-system-for-pizza-store-/assets/76699698/003b606a-adb4-4406-b53e-6b5be242f31c)
   5. Repeat these steps for all the databases used in the project.



### Running the Project

To run the project, open it in Visual Studio 2022 and press the start button on top.

### Running the Tests
s
To run the tests, right-click on the Unit test project and click on the "Run Test" option.

### Dependencies for Unit Testing

The dependencies for the unit testing projects are Nunit3TestAdapter, NUnit, and NUnitForms.Framework. These can be installed from the NuGet package manager in Visual Studio.

### Note

No environment variables are required for this project. The project is a Windows application targeting .NET Framework 4.7.2. The NUnit Framework is used for writing tests in this project.
