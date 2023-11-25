# RIA CODING TEST

### **Stacks**:

Here are some notes for your consideration.

About the Code and Framework:
-The project is an API .net 7.
-I used Visual Studio 2022 to develop it.
-RiaCodingTest.API is the principal project. 
-RiaCodingTest.APIStress is the stress test project

About the solution provided:

### **1. Challenging - Denomination routine:**

This project shows the result of how many different combinations I can withdraw the money I want to withdraw from the ATM.
The controller *ATMController* is responsable to get this information.
In the class *ATMService*, the method GetDenominations checks all possible combinations that the ATM can pay.

**Example:** 
Amount: 150
Result: 
  "15 X 10 EUR",
  "3 X 50 EUR",
  1 X 100 EUR + 5 X 10 EUR",
  "1 X 100 EUR + 1 X 50 EUR",
  "1 X 50 EUR + 10 X 10 EUR",
  "2 X 50 EUR + 5 X 10 EUR".

### **1. REST server:**

There are two endpoints in *CustomerController*: insert and get-all 
