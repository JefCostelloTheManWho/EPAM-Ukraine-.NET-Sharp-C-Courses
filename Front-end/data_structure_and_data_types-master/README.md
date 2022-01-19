# Data structure and types

## TASK № 1

### Write a title validation function called “validateTitle”, that takes an argument and validates it by the rules:
1. Title length must be more than 2 characters but less than 20.
2. Title must start with an uppercase letter.
3. Function should return ‘VALID’ if the string meets the requirements or ‘INVALID’ if it does not. And return 'Incorrect input data' if the given argument not a string. Do not use regular expressions.

### For example:
```js
validateTitle(false) // 'Incorrect input data'
validateTitle([]) // 'Incorrect input data'
validateTitle('s') // 'INVALID
validateTitle('12title') // 'INVALID'
validateTitle('Title!') // 'VALID'
validateTitle('Title?') // 'VALID'
```
<hr>

## TASK № 2
### Create a function called “sum”, that takes two arguments: a number, represented as string, and a number. If an argument of type number is divisible by 3, 5 and 15 without remainder, multiply it by -1. Function should return numeric sum of two arguments.

### For example:
```js
sum('25', 15) // 10
sum(41, '3') // 44
sum('3', 45) // -42
sum('15', 15) // 0
```
<hr>
<hr>

## * Don`t change the given functions naming