# Agri-Energy Connect Application

## Project Description

The Agri-Energy Connect Platform is a prototype web application developed using C#, ASP.NET Core MVC, and Visual Studio. It was created as part of a proposal to support sustainable agriculture by connecting farmers and employees through an easy-to-use digital platform. The application implements a clean separation of concerns using the MVC architecture and follows best practices by using repository patterns and asynchronous programming for improved scalability and responsiveness. The system makes use of an SQLite database to store farmer, employee and product data in tables.

The platform simulates real-world agricultural operations by integrating a relational database to manage farmer and product data. It allows farmers to add and manage their product listings, while employees can add new farmers and access all product information with filtering options.

## The Application's Features

### General Features:
- Responsive and intuitive UI design.
- Integrated authentication system with role-based access for Farmers and Employees.
- Data validation and error handling to ensure input integrity and system stability.

### For Farmers:
- Add Product Listings: Farmers can add products including the product's name, category, production date, price, quantity, and upload an image.
- View Own Products: Farmers can view and filter their product listings in a clean and organized interface.
- View Profile: Farmers can view their account details via the profile page.

### For Employees:
- Add New Farmer Profiles: Employees can create profiles for new farmers and include the farmer's essential details.
- View & Filter Products: Employees can view all products in the system and apply filters based on date ranges and product types for analysis and reporting.

## Technical Highlights:
- MVC Architecture: Clean separation of concerns between Controllers, Models and Views.
- Repository Pattern: Acts as a bridge between Models and Database, making the system easier to test and maintain.
- Asynchronous Methods: Enhance performance and scalability of the application.
- Image Storage: Product images are stored in the database as byte arrays.

## Before You Can Compile and Run The Application

1. **Ensure that you have Visual Studio downloaded or you won't be able to run the project.**
2. If you do not have Visual Studio then you can download it using this link https://visualstudio.microsoft.com/vs/community/
3. Make sure you download Visual Studio Community, because it's free.
4. Once downloaded, install Visual Studio Community.

## How to Compile and Run The Application

1. Once Visual Studio is installed and working fine, go to the GitHub Repository page for this project by using the following link https://github.com/MCCLUCKY415/ST10256859_PROG7311_POE.git
2. After clicking the link you should be on the Github Repository page for the project, just go ahead and click the green "Code" button on the right and then click "Download ZIP".
3. Once the ZIP file is downloaded, extract it to your location of choice on your computer.
4. Open Visual Studio and click on "Open a project or solution".
5. Navigate your way to where you extracted the ZIP file, double click on the folder "ST10256859_PROG7311_POE-master", and then select the file ending with ".sln", then click "Open".
6. Once the project opens make sure the necessary NuGet packages are restored (Visual Studio will usually do this automatically).
7. Configure your appsettings.json for the database connection string (if needed).
8. Apply any pending migrations using Package Manager Console: type "Add-Migration InitialCreate", then hit enter, then type "Update-Database", then hit enter again.
9. After that click on the "Start" button at the top with a green play sign on it. The project should then start up and you'll see the application appear with the Home page for the Agri-Energy Connect Application.
10. From there you can create your account as an employee and add farmer accounts or view farmer products. Or you can log in as a farmer, create product listings and view them on your farmer profile.
11. Please Note! I'm pretty sure you do not need to migrate the database database it should just run and work when you run the program. But if you do or you see no data from the database then follow steps 6 - 9. Also you can find all the dummy data for the application under ST10256859_PROG7311_POE-master\ST10256859_PROG7311_POE-master\ST10256859_PROG7311_POE\DataBase\AppDbContext.cs
12. Enjoy!

## References

- GitHub Copilot for assisting with the structure of the code.
- ChatGPT for assisting me with finding and fixing errors in the code.
