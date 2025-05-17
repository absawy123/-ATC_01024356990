This is full web application for Event management system , here are what i used in this project :-

🔧 Backend (.NET 8 Web API)
✅ CRUD Operations
Supports: Create, Read, Update, Delete
Handles image upload/update via multipart/form-data

🏗️ Generic Repository & Unit of Work
- IUnitOfWork wraps all repositories
- Centralized SaveAsync() for transactional operations

🧅 Onion Architecture
Layers:

- Domain (Entities, Interfaces)
- Application (DTOs, Services)
- Infrastructure (EF Core, JWT, File handling)
- API (Controllers, DI, Middleware)
- Promotes separation of concerns and scalability

🔐 JWT Authentication
- Uses [Authorize] to protect API endpoints

📝  Validation
Integrated FluentApi Validation for model validation

 ---------------------------------------------------------------------
 
🌐 Frontend (Angular 17)  ---> 

🌍 HTTP Interceptor
- Automatically attaches JWT token to HTTP requests
- Handles 401 Unauthorized by redirecting to /login

📝 Template‑Driven Forms
- Forms used for login, event creation, and update
V- alidation messages displayed with Angular 17's @if () {} syntax

🔐 Guards
- AuthGuard prevents unauthorized route access
- Redirects unauthenticated users

💻 Responsive UI
- Built with Bootstrap 5
- Mobile-first, fully responsive layout




