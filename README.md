# Simple Inventory Management System with MS SQL and MongoDB

## Project Description

The Simple Inventory Management System is a console-based application designed to help users manage a list of products, where each product has a name, price, and quantity in stock. This project focuses on implementing the system using both MS SQL and MongoDB databases for data storage.

### Features

Here are the main functionalities of the system:

1. **Add a Product**:
   - Prompt the user for the product name, price, and quantity.
   - Add the product to the inventory.
   - Commit the changes to both MS SQL and MongoDB databases.

2. **View All Products**:
   - Display a list of all products in the inventory, along with their prices and quantities.
   - Retrieve product data from both MS SQL and MongoDB.
   
3. **Edit a Product**:
   - Ask the user for a product name.
   - If the product is in the inventory, allow the user to update its name, price, or quantity.
   - Commit the changes to both MS SQL and MongoDB databases.

4. **Delete a Product**:
   - Ask the user for a product name.
   - If the product is in the inventory, remove it.
   - Commit the changes to both MS SQL and MongoDB databases.

5. **Search for a Product**:
   - Ask the user for a product name.
   - If the product is in the inventory, display its name, price, and quantity.
   - If not found, inform the user.
   - Retrieve product data from both MS SQL and MongoDB.

6. **Exit**:
   - Close the application.
   - Perform a final commit and push changes to both databases.

### Data Storage

This project utilizes two different databases for data storage:

- **MS SQL Database**:
  - Used to store product information in a structured, relational format.
  - Ideal for complex queries and structured data.
  
- **MongoDB**:
  - Used to store product information in a flexible, NoSQL format.
  - Suited for scenarios where data structure might evolve over time or require rapid development.

## Getting Started

To run this project, follow these steps:

1. Clone the GitHub repository to your local machine.

2. Install the necessary dependencies for both MS SQL and MongoDB, and set up the required database connections.

3. Run the application, and you'll be able to use the inventory management system with dual database support.

## Technologies Used

- C# for the application logic
- MS SQL for structured data storage
- MongoDB for NoSQL data storage

## Contributors

- Ibrahim Nobani

## License

This project is licensed under the MIT License.