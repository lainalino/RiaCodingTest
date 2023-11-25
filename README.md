# RIA CODING TEST

### **Stacks**:

Here are some notes for your consideration.

About the Code and Framework:
-The project is an API .net 7.
-I used Visual Studio 2022 to develop it.
-RiaCodingTest.API is the principal project. 
-RiaCodingTest.APIStress is the stress test project

About the solution prov"id"ed:

### **1. Challenge - Denomination routine:**

This project shows the result of how many different combinations I can withdraw the money I want to withdraw from the ATM.
The controller *ATMController* is responsable to get this information.
In the class *ATMService*, the method GetDenominations checks all possible combinations that the ATM can pay.

**Example:**
```
Amount: 150
Result: 
  "15 X 10 EUR",
  "3 X 50 EUR",
  1 X 100 EUR + 5 X 10 EUR",
  "1 X 100 EUR + 1 X 50 EUR",
  "1 X 50 EUR + 10 X 10 EUR",
  "2 X 50 EUR + 5 X 10 EUR".
```

### **1. REST server:**

There are two endpoints in *CustomerController*: insert and get-all 

The endpoint **insert**:
```bash
curl -X 'POST' \
  'https://localhost:7073/customer/insert' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '[
  {
    ""id"": 0,
    ""firstName"": "string",
    ""lastName"": "string",
    ""age"": 0
  }
]'
```

The endpoint **get-all**:
```bash
curl -X 'GET' \
  'https://localhost:7073/customer/get-all' \
  -H 'accept: text/plain'
```

In the *CustomerRepository* class, the InsertCustomer method checks if there is another registration with the same id. Otherwise, the customer will be added based on the return from the GetIndex method.
th GetCustomers method get all the customers.

The class *Stor"age"Service* is responsable to save and get the information from txt file

**Example:**
```
[
{ "lastName": "Aaaa", "firstName": "Aaaa", "age": 20, "id": 3 },
{ "lastName": "Aaaa", "firstName": "Bbbb", "age": 56, "id": 2 },
{ "lastName": "Cccc", "firstName": "Aaaa", "age": 32, "id": 5 },
{ "lastName": "Cccc", "firstName": "Bbbb", "age": 50, "id": 1 },
{ "lastName": "Dddd", "firstName": "Aaaa", "age": 70, "id": 4 },
]

Request POST customers:
[{ "lastName": "Bbbb", "firstName": "Bbbb", "age": 26, "id": 6 }]

Array after insert:
[
{ "lastName": "Aaaa", "firstName": "Aaaa", "age": 20, "id": 3 },
{ "lastName": "Aaaa", "firstName": "Bbbb", "age": 56, "id": 2 },
{ "lastName": "Bbbb", "firstName": "Bbbb", "age": 26, "id": 6 },
{ "lastName": "Cccc", "firstName": "Aaaa", "age": 32, "id": 5 },
{ "lastName": "Cccc", "firstName": "Bbbb", "age": 50, "id": 1 },
{ "lastName": "Dddd", "firstName": "Aaaa", "age": 70, "id": 4 },
]
```