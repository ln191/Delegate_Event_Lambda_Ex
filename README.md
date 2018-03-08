# Delegate_shipping_ex
Demonstrates the use of delegates in C#

## Assignment
Create shipping fee calculator: 

-	Ship the items to different destinations.
-	Shipping fees are x% of the given item price.
-	Some places have an additional risk fee.
	
Task: 
Given a destination and item price, calculate the shipping fee.
	
## Zone Details

	Zone 1		25%
	Zone 2		12% is high risk
	Zone 3 		 8%
	Zone 4		 4% is high risk
	
	High risk fee 25$ on top of percentage fee. 
	
## Delegate info
Delegate can best be described as a placeholder for functions.

- Works like C++ pointers
- Can be dynamically switched at runtime
- Can be used to implement [callback functions](http://www.c-sharpcorner.com/UploadFile/1c8574/delegate-used-for-callback-operation/).
- They are Type safe
### Delegate Ex
```
Public delegate int myDelegate(int x, int y);

int myPlusFunc(int x,int y){
	return x + y;
}
int myMinusFunc(int x,int y){
	return x - y;
}
Main{
	myDelegate cal = myPlusFunc;

	int result = cal(200,200);

	Console.WriteLine($"Result is {result}");

	cal = myMinusFunc;

	result = cal(200,200);

	Console.WriteLine($"Result is {result}");
}
```
The code above will output the following
```
Result is 400
Result is 0
```
The delegate variable simply holds a method, and it can be set to hold any method that share the same construct as the created delegate.
In this case the method must return an `int` and take two `int` as parameters. 

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

