## 🛑 1. Func Delegate
A `Func` delegate is used when you need a method that **returns a value**.



### Code Example
`Func<T1, T2, ..., TResult> name = (params) => { return value; };`

* **Input Parameters:** Can have 0 to 16 input parameters (`T1`, `T2`, etc.).
* **Return Value:** The **last** type parameter is always the return type (`TResult`).

``` 
// Takes a float, a float, and an int; Returns a float
Func<float, float, int, float> calculateFunc = (x, y, z) => x + y * z;

float result = calculateFunc(2.3f, 4.56f, 7);
```

---
## ⚡ 2. Action Delegate
An `Action` delegate is used for methods that perform an operation but **do not return a value** (`void`).



### Syntax
`Action<T1, T2, ...> name = (params) => { /* logic */ };`

* **Input Parameters:** Can have 0 to 16 input parameters.
* **Return Value:** None (Always `void`).


### Code Example
```
// Takes 6 parameters and performs a console print (returns nothing)
Action<int, string, string, decimal, char, bool> displayEmployeeDetails = 
    (id, firstName, lastName, salary, gender, isManager) => {
        Console.WriteLine($"Id: {id}, Name: {firstName} {lastName}");
    };

// Execution
displayEmployeeDetails(1, "John", "Doe", 60000m, 'M', true);
```

---
## 🔍 3. Predicate Delegate
A `Predicate` delegate is a specialized version of a delegate used for **criteria checking**. It is essentially a `Func<T, bool>`.

### Syntax  
`Predicate<T> name = (param) => { return boolean_condition; };`

* **Input Parameters:** Always exactly **one** parameter.

* **Return Value:** Always returns a bool.

### Code Example
```
// Takes an integer and returns true if it is even
Predicate<int> isEvenPredicate = number => number % 2 == 0;

// Execution
bool check = isEvenPredicate(10); // Returns true
```
