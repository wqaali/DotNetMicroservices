﻿-- Create the database
CREATE DATABASE IF NOT EXISTS eCommerceUserDB;
USE eCommerceUserDB;

-- Create the Users table
CREATE TABLE Users (
    UserID CHAR(36) NOT NULL,
    PersonName VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    Gender VARCHAR(15),
    PRIMARY KEY (UserID)
);

-- Insert sample data
INSERT INTO Users (UserID, Email, PersonName, Gender, Password)
VALUES 
('c32f8b42-60e6-4c02-90a7-9143ab37189f', 'test1@example.com', 'John Doe', 'Male', 'password1'),
('8ff22c7d-18c7-4ef0-a0ac-988ecb2ac7f5', 'test2@example.com', 'Jane Smith', 'Female', 'password2');

-- Create the database
CREATE DATABASE IF NOT EXISTS ecommerceproductsdatabase;
USE ecommerceproductsdatabase;

-- Create the products table
CREATE TABLE IF NOT EXISTS Products (
  ProductID char(36) NOT NULL,
  ProductName varchar(50) NOT NULL,
  Category varchar(50) DEFAULT NULL,
  UnitPrice decimal(10,2) DEFAULT NULL,
  QuantityInStock int DEFAULT NULL,
  PRIMARY KEY (ProductID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Insert 12 sample rows into the products table with specified categories
INSERT INTO Products (ProductID, ProductName, Category, UnitPrice, QuantityInStock) VALUES
  ('1a9df78b-3f46-4c3d-9f2a-1b9f69292a77', 'Apple iPhone 15 Pro Max', 'Electronics', 1299.99, 50),
  ('2c8e8e7c-97a3-4b11-9a1b-4dbe681cfe17', 'Samsung Foldable Smart Phone 2', 'Electronics', 1499.99, 100),
  ('3f3e8b3a-4a50-4cd0-8d8e-1e178ae2cfc1', 'Ergonomic Office Chair', 'Furniture', 249.99, 25),
  ('4c9b6f71-6c5d-485f-8db2-58011a236b63', 'Coffee Table with Storage', 'Furniture', 179.99, 30),
  ('5d7e36bf-65c3-4a71-bf97-740d561d8b65', 'Samsung QLED 75 inch', 'Electronics', 1999.99, 20),
  ('6a14f510-72c1-42c8-9a5a-8ef8f3f45a0d', 'Running Shoes', 'Furniture', 49.99, 75),
  ('7b39ef14-932b-4c84-9187-55b748d2b28f', 'Anti-Theft Laptop Backpack', 'Accessories', 59.99, 60),
  ('8c5f6e73-68fc-49d9-99b4-aecc3706a4f4', 'LG OLED 65 inch', 'Electronics', 1499.99, 15),
  ('9e7e7085-6f4e-4921-8f15-c59f084080f9', 'Modern Dining Table', 'Furniture', 699.99, 10),
  ('10d7b110-ecdb-4921-85a4-58a5d1b32bf4', 'PlayStation 5', 'Electronics', 499.99, 40),
  ('11f2e86a-9d5d-42f9-b3c2-3e4d652e3df8', 'Executive Office Desk', 'Furniture', 299.99, 18),
  ('12b369b7-9101-41b1-a653-6c6c9a4fe1e4', 'Breville Smart Blender', 'HomeAppliances', 129.99, 50);

