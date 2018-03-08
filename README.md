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
	- Can be used to implement [callback functions](http://www.c-sharpcorner.com/UploadFile/1c8574/delegate-used-for-callback-operation/)
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
myDelegate cal = myPlusFunc;
int result = cal(200,200);
Console.WriteLine($"Result is {result}");
cal = myMinusFunc;
result = cal(200,200);
Console.WriteLine($"Result is {result}");
```
The code above will output the following
```
Result is 400
Result is 0
```
The delegate variable simple holds a method, and it can be set to hold any method that share the same construct as the created delegate.
In this case the method must return an `int` and take two `int` as parameters. 

### Delegates is Composable 
One can add multiple method on to an delegate 	