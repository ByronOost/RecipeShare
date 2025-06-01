# RecipeShare Project Documentation

This document explains the architecture and implementation of the RecipeShare project, covering database structure, web frontend (Razor Pages), backend API, and automated unit testing. It includes design decisions, trade-offs, and rationale at each layer.

---

## 1. Database Design

### Schema Overview
- **Recipe**: The central model storing user-submitted recipes.
- **ID**: GUID primary key for global uniqueness and easy frontend routing.
- **Title, Description, Instructions**: Core recipe content.
- **Tags**: Stored as a collection to support dietary filters (e.g., vegan, gluten-free).

### Design Decisions
- **GUID over int**: Chosen for simplicity in interfacing between frontend and backend, and to prevent ID collisions in distributed or multi-user environments. While larger in size than integers, GUIDs make client-side routing and integration easier.
- **Entity Model & DTO separation**: Clear layering by using DTOs prevents over-posting attacks and decouples API contracts from internal data models.

### Trade-Offs
- **No relational tag table**: Tags are stored in a simpler format without full normalization. This reduces complexity but sacrifices some querying efficiency. Given the project scope, this was an acceptable trade-off for faster development and easier maintenance.

---

## 2. Web Frontend (Razor Pages)

### Structure
- **Recipe List Page**: Displays all recipes with search by keyword and filter by dietary tags.
- **AJAX Filtering**: Uses partial views (`_RecipeList.cshtml`) and jQuery to update the recipe list dynamically without full page reloads.

### Thought Process
- Razor Pages offer a straightforward MVVM pattern suitable for rapid development.
- Partial views with AJAX provide a responsive UX without a heavy SPA framework.
- JavaScript is kept minimal, focused solely on filtering and updating the recipe list dynamically.

### Key Components
- `RecipeList.cshtml`: Hosts search input, tag checkboxes, and renders the partial view.
- `_RecipeList.cshtml`: Re-renders filtered recipe data.
- `RecipeList.js`: Manages user input and AJAX requests for filtering.

### Trade-Offs
- **jQuery vs Fetch API**: jQuery simplifies DOM manipulation and partial updates, though it adds dependency weight. For larger projects or modern standards, native Fetch or frameworks like React/Vue would scale better, but jQuery fits this project's size and timeline.

---

## 3. REST API

### Architecture
- Built with ASP.NET Core API Controllers.
- Provides CRUD endpoints for the Recipe entity.
- Returns standardized `ApiResponse` objects to maintain consistency.

### Key Design Decisions
- **Standardized Response Wrapper (`ApiResponse`)**: Ensures all endpoints return data in a consistent format, simplifying frontend error handling and success checks.
- **DTO vs Model separation**: Enhances security by preventing EF navigation properties from leaking and eases future API evolution.
- **`OperationResult` usage**: Centralizes success/failure information from repository operations without relying on exceptions for flow control.

### Example Endpoints
- `GET /api/recipes`: Lists all recipes.
- `GET /api/recipes/{id}`: Fetches recipe by ID.
- `POST /api/recipes`: Creates a new recipe.
- `PUT /api/recipes`: Updates an existing recipe.
- `DELETE /api/recipes/{id}`: Deletes a recipe.

### Trade-Offs
- **Manual DTO-to-Model mapping**: Adds some boilerplate but provides fine-grained control over exposed fields.
- **ApiResponse casting on frontend**: Slightly increases frontend code complexity but the benefits of uniform response structure outweigh this downside.

---

## 4. Unit Testing

### Frameworks Used
- **xUnit**: Test framework.
- **Moq**: Mocks repository interfaces.
- **FluentAssertions**: Provides readable and expressive assertions.

### Coverage
- Tests cover positive and negative cases for each API method:
  - `GetAll`: returns OK with recipes.
  - `GetById`: success and not found.
  - `Create`: returns Created with valid DTO.
  - `Update`: handles invalid ID, not found, and successful update.
  - `Delete`: successful deletion returns expected response.

### Key Testing Decisions
- **TestAsyncEnumerable**: Used to simulate EF async LINQ queries without needing a real database.
- **Repository mocking only**: Tests focus on controller logic and avoid EF or database dependency, ensuring fast and isolated tests.

### Trade-Offs
- Tests only cover the controller layer; additional service layer or integration tests could be added as the app grows.
- No end-to-end integration tests yet, but these could be implemented later for full-stack verification.

---

## Summary

RecipeShare was architected to balance development speed, maintainability, and user experience. The Razor Pages frontend with partial views delivers a responsive UI with minimal JS. The backend REST API cleanly separates concerns using DTOs, standardized responses, and repository abstraction. Automated tests verify expected behaviors and edge cases, enabling confident refactoring and future growth.

This design supports rapid iteration while maintaining a clean, scalable codebase.

---
