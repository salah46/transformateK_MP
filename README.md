# transformateK_MP

## Description

This project is a CRUD API implements a system with the following key features:

- **Database Models:**
  - Utilizes models related to tables in an embedded SQLite database, including `Admin`, `Affectation`, `Agent`, `Result`, `Point`, and `Consigner`. Look at the database      scheme.

- **Agent Endpoints:**
  - Provides endpoints dedicated to agents for consulting their assignments and recording measurement results.

- **Administrators Endpoints:**
  - Includes endpoints specifically for administrators to define agent assignments and review the results of field measurements.

- **OpenAPI Interface:**
  - Integrates an OpenAPI interface (Swagger) for easy API documentation and exploration.

## Technologies,Patterns Used

- **C#:**
  - The primary programming language for the project.

- **.NET Core:**
  - The cross-platform, open-source framework used for building the application.

- **Entity Framework (EF):**
  - Utilized for database access and ORM (Object-Relational Mapping).

- **LINQ Expressions:**
  - Employed for querying and manipulating data in a declarative manner.

- **Data Transfer Object (DTO) Pattern:**
  - Implemented for efficient and organized data transfer between components.

## Getting Started

Follow these steps to set up and run the project locally.

1. **Clone the Repository:**
   ```bash
   git clone (https://gitfront.io/r/user-1995900/kvf2NuUxNmKA/transformateK-MP.git)
   ```

2. **Build and Run:**
   - Build and run the project using the specified build tools or IDE like VsCode.

3. **Access API Documentation:**
   - Navigate to the provided OpenAPI interface (https://localhost:7043/swagger/index.html) to explore and understand the available endpoints.

4. **SQLite Database:**
   - The project uses an embedded SQLite database. No additional configuration is required for the database setup.

5. **Sample Data:**
   -In the database, there are two agents and two administrators assigned with integer IDs 1 and 2.
      

## Additional Notes

- Ensure that the necessary dependencies are installed before running the project.

- For any questions or issues, please refer to the documentation or contact the project maintainers.

---
