# Lambda execise
Refactor the bankBalance program to use lambda.

# Lambda Info
Lambda is a way of writing anonymous functions.
- It´s based on delegates
- It´s used when a function is short and can be in one or two lines of code
- It´s makes the code easier to read
- Lambda is defined using `=>` operator
- There are two types of Lambda expresions
	- Expression Lambda 
	- Statement Lambda

## Expression Lambda
Here is a example of expression Lambda
```
Public delegate int myDelegate(int i);

myDelegate f = x => x * x;
```
Like a method must have the same structure as the delegate in order for the delegate to hold it,
the same rule apply to the lambda expression.

In this case the delegate can take one `int` value parameter and it must return and `int` value.

The delegate f is set to lambda expression, that says given `x` which is the parameter, then return the value of `x * x`.
So the left side of the `=>` referce to the delegate parameters and the rigth is the function that needs to be run. 

So when we run the f delegate
```
f(10);
```
The result is 100

## Statement Lambda
This is and example of a statement Lambda
```
(x,y) => {
	Func1(x);
	Func2(y);
	}
```
You can tell it is a statement lambda, since the rigth side is encapsulated in `{}`. 
Inside them are two statements run with the parameter given on the left side.
