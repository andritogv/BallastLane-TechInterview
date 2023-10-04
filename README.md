# BallastLane-TechInterview

**User Story:** "I as a user want to be able to create, read, update, and delete prescriptions with Name and Description."

# Technology Used

- **Language and Framework:** C#, ASP.NET Core Web API
- **Database:** Microsoft SQL Server (No entity framework used)
- **Frontend:** Blazor WebAssembly

# Architecture

The application was implemented using clean architecture principles, starting from the Domain Layer, then Business Layer, and API, Database, and frontend left at last.

All dependencies point inward into the Business and Domain Layers.

![image](https://github.com/andritogv/BallastLane-TechInterview/assets/13070989/cdecdbde-d5b2-4984-9720-14ebbc4e25b2)

# TDD
TDD was used to develop unit tests for Domain, Business, and Api layers.
Data Layer was tested with integration tests.

# Blazor WebAssembly

![image](https://github.com/andritogv/BallastLane-TechInterview/assets/13070989/a9807524-678b-41e5-ae09-be1c33bbebd8)

![image](https://github.com/andritogv/BallastLane-TechInterview/assets/13070989/27f2edd9-2396-45ff-8d42-ec1d216005c0)

# Caveats
- All Operations were implemented for Prescriptions, however, didn't have the chance to implement authentication and all users operations, shouldn't take much more time following the same pattern used with Prescriptions.
