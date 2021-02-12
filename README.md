# Product_Revision_Manager

Tier 3 app in WPF with internal SQL server that aims to solve the communication between clients and suppliers in an organized manner.

### Table of contents

2. Project Goal
2. Installation Manual
6. Sprint Retrospective

### Project Goal

The goal is the project is to create an App in WPF to manage the communication of product revisions between clients and suppliers

#### Installation manual

**Pre-requisites**

Download the repository 

You can open the solution with Visual Studio and make sure you have the following downloaded using Nugget package manager:

- Nunit
- Entity Framework Core
- Entity Framework Tools
- Entity Framework SQL Server

**Step 1** Set up project

Open Visual Studio into the solution "ProductRevisionManager.sln"

**Step 2** Migrate tables

Open PowerShell on Visual Studio and apply migrations 

* Add-Migration MigrationNameHere

* Update-Database

These commands will create a database called Monokayu and tables derived from the models

**Step 3** Generate test data

Run the business layer main method i.e. Change the dropdown box to "BussinessManager" and run console application

* This will generate Test data
  * Users
    * Lorenzo Bulosan
    * Cathy French
    * Martin Beard
  * Projects
    * Calculator
    * Radio
    * Revision Manager

**Step 4** WPF app

Run the WPF app by changing the dropdown box to select "ProductRevisionAppWPF" and run console application

You can now login with one of the 3 users described on Step 3

Test data login credentials:

* name = Lorenzo
* surname = Bulosan
* password = 12345

### Sprint Retrospectives

**Sprint 1** (05/02/2021-09/02/2021)

*<u>Goal</u>*

The goal for this sprint was to design a database and test the relationship between the tables, as well as displaying the test data on WPF frontend. 

The goals for the sprint were achieved and the database was design to 3NF (Normal Form) and they were implemented on a model first basis using Entity Framework in C#.

The test data (Task for a revision) are displayed using a template. A way to change between revision rounds was also achieve using a combo box that allows users to select a revision round and retrieve the specific tasks for that round.

*<u>Retrospective</u>*

- What worked well?
  - Visual representation of ERD before making the models
  - Testing each table relation before proceeding to create all models at once
  - Often pushing work to GitHub (allowed me to restore the migrations when bad migrations happened) 
- What did not work well?
  - The content of user stories needed previous work so It is needed to either break down the card or create the card for which this one is dependent to. 
  - Unit test were not done immediately
  - Documentation was not written immediately
- What actions can I take to improve the process going forward?
  - Write Unit tests every few methods that are written.
  - Write documentation more often
  - Clean code from test methods


