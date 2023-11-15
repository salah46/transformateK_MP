# transformateK_MP

## Description

This project implements a system with the following key features:

- **Database Models:**
  - Utilizes models related to tables in an embedded SQLite database, including `Admin`, `Affectation`, `Agent`, `Result`, `Point`, and `Consigner`. Look at the database      scheme.

- **Agent Endpoints:**
  - Provides endpoints dedicated to agents for consulting their assignments and recording measurement results.

- **Administrators Endpoints:**
  - Includes  endpoints specifically for administrators to define agent assignments and review the results of field measurements.

- **OpenAPI Interface:**
  - Integrates an OpenAPI interface, such as Swagger or a similar tool, for easy API documentation and exploration.

## Technologies Used


- C#.
- Dotnet Core
- Entity Framework (EF) Framework
- LINQ Expressions
- Data Transfer Object (DTO) Encapsulation
  

## Getting Started

Follow these steps to set up and run the project locally.

1. **Clone the Repository:**
   ```bash
   git clone <repository-url>
   ```

2. **Build and Run:**
   - Build and run the project using the specified build tools or IDE.

3. **Access API Documentation:**
   - Navigate to the provided OpenAPI interface (https://localhost:7043/swagger/index.html) to explore and understand the available endpoints.

4. **SQLite Database:**
   - The project uses an embedded SQLite database. No additional configuration is required for the database setup.

5. **Sample Data:**
   -In the database, there are two agents and two administrators assigned with integer IDs 1 and 2.
      ```

## Additional Notes

- Ensure that the necessary dependencies are installed before running the project.

- For any questions or issues, please refer to the documentation or contact the project maintainers.

---
