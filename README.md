# FinanceControl API 💰

A RESTful API built with **.NET 8** to help users track incomes and expenses efficiently.

## 🚀 Technologies

* C# .NET 8
* Entity Framework Core (MySQL)
* Clean Architecture
* Swagger UI

## ⚙️ How to Run

1.  **Clone the repo**
    ```bash
    git clone [https://github.com/YOUR-USERNAME/FinanceControl.git](https://github.com/YOUR-USERNAME/FinanceControl.git)
    ```

2.  **Configure Database**
    Update your connection string in `appsettings.json` (inside the API project).

3.  **Run Migrations (Visual Studio)**
    Open **Package Manager Console** (*View > Other Windows > Package Manager Console*).
    
    * Set **Default project** drop-down to: `FinanceControl.Infrastructure`
    * Run the command:
    ```powershell
    Update-Database
    ```

4.  **Start the API**
    Press **F5** or click the **Start/Play** button in Visual Studio.

## ✅ Key Features

* **Transactions:** Add incomes and expenses with validation.
* **Categories:** Organize transactions by category.
* **Dashboard:** (Coming soon) View financial summaries.

---
Created by [Your Name]
