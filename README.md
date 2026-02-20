# Sales Transaction Manager (WPF)

**Tech Stack:** C#, WPF, MVVM, SQL Server

## Overview
A WPF desktop application built using the MVVM pattern to manage sales transactions. The project focuses on clean separation of concerns, command-based UI interactions, and persistent data handling.

## Features
- MVVM architecture (Views + ViewModels)
- Command pattern (RelayCommand)
- Add / Edit / List transactions
- Data binding & UI validation
- SQL Server persistence (where applicable)

## Project Structure
- `PMSManager/` – WPF UI (Views) and ViewModels
- `PMSLibrary/` – Shared models / business logic (if applicable)

## How to Run
1. Open the `.sln` in Visual Studio
2. Restore NuGet packages (if prompted)
3. Run the `PMSManager` projects