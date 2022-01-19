# Advanced_functions-with_tests

## TASK № 1
### Write a function called "cache". It will be a function wrapper, which takes a function and caches its results depending on the arguments that were applied to the function.
```js
let complexFunction = function(arg1, arg2) {
	return arg1 + arg2;  // just for example (any logic can be here)
 };

let cachedFunction = cache(complexFunction);
```
### Example:
```js
cachedFunction('foo', 'bar'); // complex function should be executed
cachedFunction('foo', 'bar'); // complex function should not be invoked again,
                      // instead the cached result should be returned
cachedFunction('foo', 'baz'); // should be executed,
            // because the method wasn't invoked before with these arguments
```
<hr>

## TASK № 2
### Create an object called "forwardBackwardSteps”. It should include 3 methods: “forward", “backward", “revealStep” and one  property: “step”. Initial value of “step” is equal to 0. The object should support chaining calls on its methods. "forward" – increasing "step", "backward" – decreasing “step”, "revealStep" – console.log current value of "step".

### Example:
```js
forwardBackwardSteps.forward().forward().backward().forward().revealStep(); // 1+1-1+1 = 2
```
<hr>

## TASK № 3
### Write a function called “applyAll”. It takes a function (sum or mul) and an arbitrary number of arguments. It should call a received function ( output the “sum” and “mul” functions) with all arguments and return result. Using of call method is mandatory.

### Example:
```js
applyAll(sum, 1, 2, 3); // -> sum(1, 2, 3) = 6
applyAll(mul, 2, 3, 4); // -> mul(2, 3, 4) = 24
```
<hr>
<hr>

## * Don`t change the given functions naming and don't delete this part of code:
```
module.exports = { cache, ladder, applyAll, sum, mul }
```




