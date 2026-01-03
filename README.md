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
    Update your connection string in `appsettings.json`.

3.  **Run Migrations**
    ```bash
    dotnet ef database update --project FinanceControl.Infrastructure --startup-project "API de Controle Financeiro Pessoal"
    ```

4.  **Start the API**
    ```bash
    dotnet run --project "API de Controle Financeiro Pessoal"
    ```

## ✅ Key Features

* **Transactions:** Add incomes and expenses with validation.
* **Categories:** Organize transactions by category.
* **Dashboard:** (Coming soon) View financial summaries.

---
Created by Henrique Matos
