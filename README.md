# Game Results API

## Overview
The Game Results API is a RESTful service that allows users to upload XLS files containing game results, which are then processed and stored in an in-memory database. The API provides endpoints to upload game results and retrieve stored results.

## Project Structure
```
GameResultsApi
├── Controllers
│   └── GameResultsController.cs
├── Models
│   └── GameResult.cs
├── Services
│   └── GameResultService.cs
├── Data
│   └── InMemoryDbContext.cs
├── Utils
│   └── ExcelParser.cs
├── Program.cs
├── GameResultsApi.csproj
└── README.md
```

## Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd GameResultsApi
   ```

2. **Install Dependencies**
   Ensure you have the .NET SDK installed. Run the following command to restore the project dependencies:
   ```bash
   dotnet restore
   ```

3. **Run the Application**
   Start the application using:
   ```bash
   dotnet run
   ```

4. **API Endpoints**
   - **Upload Game Results**
     - **Endpoint:** `POST /api/gameresults/upload`
     - **Description:** Uploads an XLS file containing game results.
     - **Request Body:** Multipart form-data containing the XLS file.

   - **Get Game Results**
     - **Endpoint:** `GET /api/gameresults`
     - **Description:** Retrieves all stored game results.
     - **Response:** A list of game results in JSON format.

## Technologies Used
- C#
- ASP.NET Core
- In-memory database simulation

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License.