# 📦 Smart Elevator System (C#)

A modular, object-oriented simulation of a multi-elevator control system built with C#. The system uses design patterns such as **Command** and **Observer** to manage elevator requests and movement, simulating real-time dispatch and coordination across multiple elevators.

---

## ✅ Features

- 🚪 Multi-elevator support with independent movement  
- 🔼 Floor request prioritization (Up/Down)  
- 🎛️ Internal and external request buttons  
- 🎯 Elevator queuing and direction optimization  
- 🧱 Command Pattern for encapsulated elevator actions  
- 📡 Observer Pattern for reactive request handling  
- 🖥️ Console-based simulation and extensible architecture  
- 🧪 Unit and integration tests for system components  

---

## 🛠️ Tech Stack

- **C# (.NET 6 or higher)**  
- **Multithreading** (planned)  
- **Console application**  
- **NUnit / xUnit** (optional for testing)  

---

## 🚀 Roadmap

- [x] Core domain model and logic  
- [x] Request command and observer integration  
- [x] Test harness for simulation  
- [ ] Multithreading for real-time elevator movement  
- [ ] Elevator controller and dispatcher for coordination  
- [ ] UI simulation or API interface  

---

## 📁 Structure (Coming Soon)

```text
SmartElevatorSystem/
├── Models/
├── Interfaces/
├── Commands/
├── Observers/
├── Tests/
└── Program.cs
