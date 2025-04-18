# Hotel Booking App 🏨

This is a simple hotel booking management web application built with **ASP.NET Core MVC**.  
It supports two types of data persistence:

- 🗂 File System (default)
- 🛢 SQLite Database

The data source is selected dynamically at runtime using a `config.json` file.

---

## ✨ Features

- Manage **Clients**, **Hotels**, and **Bookings**
- Create, list, and edit each entity
- Store data in JSON files or a SQLite database
- Load initial sample data when using the database

---

## 🛠 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- (Optional) [DB Browser for SQLite](https://sqlitebrowser.org/) to inspect the DB file

---

## 🚀 How to Run

### 1. Clone or unzip the project

```bash
cd HotelApp
```

### 2. Restore packages and build

```bash
dotnet restore
dotnet build
```

### 3. Run the app

```bash
dotnet run
```

The app will be available at:

```
http://localhost:5044
```

---

## ⚙️ Configuration

Edit the file `config.json` to choose the data source.

### 🔁 File System (default)

```json
{
  "DATA_TYPE": "FS",
  "FS_FOLDER": "Data"
}
```

This will save files in the `Data/` folder:

- Each entity in its own subfolder
- Metadata file for tracking IDs

### 🔁 SQLite Database

```json
{
  "DATA_TYPE": "DB",
  "DB_CONNECTION": "Data Source=hotelapp.db"
}
```

- A file `hotelapp.db` will be created automatically.
- The app will seed initial data if the tables are empty.

---

## 🧪 Sample Data (DB mode only)

If using database mode, the app will seed the following on first launch:

### Clients

- Marcos Valens
- Maria Payeras

### Hotels

- Hotel Melia Resort
- Hotel Palas Atenea

---

## 🧼 Clean Architecture Principles

- `IRepositoryService<T>` abstracts persistence
- Two interchangeable implementations:
  - `FsRepositoryService<T>`
  - `DbRepositoryService<T>`
- Controllers are fully decoupled from data source

---

## 🧩 Project Structure

```
├── Controllers/
├── Models/
├── Services/
├── Views/
├── config.json
├── Program.cs
└── README.md
```

---
