Cascading Dropdown Web Application
The Cascading Dropdown Web Application is a simple web project built using ASP.NET that demonstrates the use of cascading dropdowns to select a user's information.

Table of Contents
•	Introduction
•	Features
•	Installation
•	Usage
•	Database Structure
•	Contributing
•	License

Introduction
The Cascading Dropdown Web Application allows users to create an account by entering their personal information, including full name, email, gender, country, state, and password. The application showcases the usage of cascading dropdowns, where the selection of one dropdown influences the options available in another dropdown.

Features
•	User-friendly web interface.
•	Cascading dropdowns for selecting country and state.
•	Efficient backend database interaction.
•	Clean and responsive design.

Installation
1.	Clone the repository to your local machine:
git clone https://github.com/yourusername/your-repo.git
2.	Open the project in Visual Studio 2022.
3.	Build and run the project using IIS Express.
4.	Access the application through your web browser at http://localhost:{port}/Registration.aspx.

Usage
1.	Open the registration page at http://localhost:{port}/Registration.aspx.
2.	Fill in your full name, email, and select your gender.
3.	Choose your country from the dropdown, and the corresponding states will be loaded in the state dropdown.
4.	Select a state from the dropdown.
5.	Enter a password.
6.	Click the "Create Account" button to submit the form.

Database Structure
The application uses a SQL Server database with the following tables:

•	tUserRecord: Stores user account information.
•	tGender: Stores gender options.
•	tCountry: Stores country options.
•	tState: Stores state options associated with countries.
Please refer to the database script file for creating the database and tables.

Contributing
Contributions to the Cascading Dropdown Web Application are welcome! Here's how you can contribute:

1.	Fork the repository.
2.	Create a new branch.
3.	Make your changes and commit them.
4.	Push your changes to your forked repository.
5.	Create a pull request.
