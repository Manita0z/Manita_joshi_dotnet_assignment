# Manita_joshi_dotnet_assignment
This is an order tracking app made in ,net programming language 
# Order Tracking System

## Project Overview
The **Order Tracking System** is a web application developed using **.NET** to facilitate seamless order management. Users can create, track, and manage their orders while administrators can oversee operations efficiently.

## Features

### 1. Home Page
- Overview of the system functionalities.
- Quick access to user dashboard and login/signup options.

### 2. User Authentication
- Secure login and signup functionality.
- Role-based access for users and administrators.

### 3. Order Management
- Create new orders with product details.
- Track order status (Pending, Processing, Shipped, Delivered).
- Update or cancel orders.

### 4. Dashboard
- Displays real-time order summaries.
- Provides insights into pending, completed, and cancelled orders.

### 5. Admin Panel
- Manage users, orders, and system settings.
- Assign delivery personnel and update order statuses.

### 6. Reports & Analytics
- Generate order reports based on date range.
- Analyze customer purchase trends.

### 7. Delivery Date Tracking
- Estimated delivery date displayed at order placement.
- Updates on actual delivery date for accurate tracking.

## Database Schema
- **Users**: Stores user credentials and roles.
- **Orders**: Stores order details, statuses, and timestamps.
- **Products**: Contains product listings available for order.
- **Delivery**: Tracks estimated and actual delivery dates.

## Technologies Used
- **Backend**: .NET (ASP.NET Core)
- **Frontend**: Razor Pages / MVC
- **Database**: Microsoft SQL Server
- **Tools**: Visual Studio, SSMS

## Installation & Setup
1. Clone the repository.
2. Configure the database in `appsettings.json`.
3. Run migrations: `dotnet ef database update`.
4. Start the application using `dotnet run`.

## Conclusion
This project streamlines order management and improves tracking accuracy, making it an essential tool for businesses managing multiple orders.

