# Bank Balance EX
Demonstrates the use of Events in C#

## Assignment
Track the balance of a bank: 

-	Keep track of a balance
-	Let us know when we´ve reached a goal( reached 500)
	
Challenge: 
Given a deposit value (positive or negative), return current balance and tell if the balance has reached 500.
	
	
## Event info
Event is a way to execute specific code in response to a given change or trigger, without having the code keep track of when the change occurs. The event will message the code, that it has been trigger and should be run.     

- Based on delegates
- Enable Async communication
- Can be switch on and off as needed
- Can create custom events
### Basic Event Ex
```

```
The code above will output the following
```

```


### Delegates is Composable 
One can add multiple method on to an delegate.
if we modify the code above to the following 
```
...
myDelegate cal = myPlusFunc;

cal += myMinusFunc;

result = cal(200,200);

Console.WriteLine($"Result is {result}");
```
The result will be the following
```
Result is 0
```
The reason for this, is that when it comes to return methods, only the last method´s `return` value will be returned.
Also if one of the methods have an exception all other methods will be skipped.

But if we change the code to make the delegate hold `void` methods instead and change the two myFunc to void method, we can see that it will run both methods.
```
Public delegate void myDelegate(int x, int y);

void myPlusFunc(int x,int y){
	Console.WriteLine($"Result is {x + y}"); 
}
void myMinusFunc(int x,int y){
	Console.WriteLine($"Result is {x - y}"); 
}

Main{
	myDelegate cal = myPlusFunc;

	cal += myMinusFunc;

	cal(200,200);
}
```
The output will show
```
Result is 400
Result is 0
```
One can also remove methods from the delegate by
```
cal -= myPlusFunc;
```
Then only myMinusFunc will be run by cal delegate.
All the methods in the delegate will be run in the order in which they where added.

### Use of Ref parameters 
In order to take better advantage of composed delegates, one can use [ref](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref) to pass result from one method to another.
```
Public delegate void myDelegate(int x, int y, ref int res);

void myPlusFunc(int x,int y, ref int res){
	res += (x + y);
}
void myMinusFunc(int x,int y, ref int res){
	res += (x - y);
}

Main{
	int result = 0;

	myDelegate cal = myPlusFunc;
	cal += myMinusFunc;
	cal(100,50,result);
	Console.WriteLine($"Result is {result}");
}
```
The code above will output the following
```
Result is 200
```
First is the `myPlusFunc` run and adds 100 + 50 to the result which is is the `ref` variable which currently 0, then `myMinusFunc` will be run, which adds 100 - 50 to result which had been set to 150 by the previous method. So when we write the result to the screen it will show 200.

### Anonymous Delegates
Instead of making a method to but into a delegate, one can add a delegate method directly. 
```
cal += delegate(int x, int y, ref int result){
	result += (x*y)
	};
```

