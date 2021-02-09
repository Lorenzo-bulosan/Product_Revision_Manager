# Product_Revision_Manager

Tier 3 app in WPF with internal SQL server that aims to solve the communication between clients and suppliers in an organized manner.

### Table of contents

2. Project Goal
2. Installation Manual
4. Feature Description
5. Examples
6. Sprint Retrospective

### Project Goal

The goal is the project is to create an App in WPF to manage the communication of product revisions between clients and suppliers

#### Installation manual

Download the solution "[ProductRevisionManager.sln](https://github.com/Lorenzo-bulosan/Product_Revision_Manager/blob/master/ProductRevisionManager/ProductRevisionManager.sln)" 

You can open the solution with Visual Studio and make sure you have the following downloaded using Nugget package manager:

- Nunit
- Entity Framework Core
- Entity Framework Tools
- Entity Framework SQL Server

#### Demo of features

Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum dapibus, enim eget sollicitudin lobortis, sapien nunc facilisis mi, in accumsan lacus turpis non velit. Duis venenatis nisi vitae erat imperdiet, nec aliquam nulla viverra. Vivamus ut consectetur massa. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec faucibus commodo quam, ac placerat risus euismod a. In non scelerisque dolor, id efficitur est. Cras porttitor cursus purus porta venenatis. Ut facilisis blandit nisi, ut luctus turpis accumsan a. Morbi ac orci suscipit, tristique ex vitae, placerat purus.

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



 