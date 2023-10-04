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
