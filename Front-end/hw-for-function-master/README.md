# HW-for-Function 

## TASK № 1

### Create a function called “isBigger”. It should accept two arguments and return “true” if the first one has greater value than the second one. Otherwise it should return false. 
### *Tip*: no need for if/else statement or ternary operator.

### For example: 
```
isBigger(5, -1); // => true
```
<hr>

## TASK № 2

### Create a function called “isSmaller”. It should accept two arguments and return “true” if the first one has lesser value than the second one. Otherwise it should return false. 
### *Tip*: consider reusing isBigger function.

### For example: 
```
isSmaller(5 -1); //=> false
```
<hr>

## TASK № 3

### Create a function called “getMin”. It should accept arbitrary number of integer arguments and return the one with the smallest value.
### *Tip*: since arguments is similar to array, you can use simple iteration over it and use arguments[ i ] to get the argument of a given index.

### For example: 
```
getMin(3, 0, -3); //=> -3
```
<hr>

## TASK № 4

### Create a function called “makeNumber”. It should accept a string with different characters and return a string of numbers from the passed argument.

### For example:
```
makeNumber('erer384jjjfd123'); //=>'384123'

makeNumber('123098h76gfdd'); //=>'12309876'

makeNumber('ijifjgdj'); //=> should return empty string ->''
```
<hr>

## TASK № 5

### Create a function called “countNumbers”. It should accept a string with different characters and return an object which contains a count of each number.
### *Tip*: consider reusing makeNumber function.

### For example: 
```
countNumbers('erer384jj4444666888jfd123');
// => {'1': 1, '2': 1, '3': 2, '4': 5, '6': 3, '8': 4}

countNumbers('jdjjka000466588kkkfs662555');
// => {'0': 3, '2': 1, '4': 1, '5': 4, '6': 4, '8': 2}

countNumbers(''); // => {}
```
<hr>

## TASK № 6

### Create a function called “pipe”. It should accept a number as a first argument and arbitrary amount of functions. The number should be passed to each function in sequence. The number passed to the next function is the returned result of the previous function. You don't have to write the function 'addOne', just pass it like in the example.
### *Tip*: you need to use “arguments” to access all passed functions.

### For example: 
```
function addOne(x) {
  return x + 1;
}

pipe(1, addOne); //=> 2
pipe(1, addOne, addOne); //=> 3
```
<hr>

## TASK № 7

### Create a function called “isLeapYear”. It should accept a number of millisecond or a string of date as an argument. This function checks if a passed argument is a Leap Year. If it is a Leap Year, function should return a following string: ‘ “year” is a leap year’. If it isn’t, function should return a following string: ‘ “year” is not a leap year’.(‘year’ means a year that was passed as an argument). Passed argument should be in an appropriate format (valid Date object). In case passed argument is invalid, function should return a following string: 'Invalid Date'.
### *Tip*: need to use Date object here.

### For example: 
```
isLeapYear('2020-01-01 00:00:00'); // =>  ‘2020 is a leap year’
isLeapYear('2020-01-01 00:00:00777'); // =>  ‘Invalid Date’
isLeapYear('2021-01-15 13:00:00');  // =>  ‘2021 is not a leap year’
isLeapYear('2200-01-15 13:00:00'); // =>  ‘2200 is not a leap year’
isLeapYear(1213131313135465656654564646542132132131); // =>  ‘Invalid Date’
isLeapYear(1213131313); ); // => ‘1970 is not a leap year’
```
