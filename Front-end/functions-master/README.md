# Functions

Inner folder structure of home task should be exactly as follows:
```
 
      <task folder>
---js
\--all js files must be here
---index.html
 
2.   Code has to be well-formatted, clean and readable.
3.   Using ESLint is mandatory.
```

## TASK № 1

### The new "How to Train Your Dragon” movie has just been released!  There are a lot of people at the cinema box office standing in a huge line. Each of them has a single 100, 50 or 25 dollars bill. A "Batman v Superman: Dawn of Justice" ticket costs 25 dollars. Vasya is currently working as a clerk. He wants to sell a ticket to every single person in this line. Can Vasya sell a ticket to each person and give the change if he initially has no money and sells the tickets strictly in the order people follow in the line? Return YES, if Vasya can sell a ticket to each person and give the change. Otherwise return NO. Can Vasya sell a ticket to each person and give the change?

Conditions:
* 1. @param persons queue Array
* 2. @return String
* 3. function tickets(person) {
//Your code here
}

### For example:
```
//Examples:
tickets([25, 25, 50]); // => 'YES'
tickets([25, 100]);    // => 'NO'
tickets([25, 25, 50, 100]); // 'YES'
tickets([25, 50, 100]); // 'NO'
tickets([‘25’, ‘25’, ‘50’, ‘100’]); // 'YES'
tickets([‘25’, ‘50’, ‘100’]); // 'NO'
```
<hr>

## TASK № 2

### Write a function that gets two infinite numbers as strings. You should return the result of these two numbers sum as string.
* 1. If your arguments are not strings of number your function should return false
* 2. If your arguments are objects,arrays,numbers or not a string that contains only numbers, your function should return false
* 3. If your argument is an empty string '' it should be converted into 0 

### For example:
```
getSum({}, [])  ->  false
getSum(‘123maxim’, ‘3coding24’)  ->  fasle
getSum(‘’, ‘4444’)  ->  '4444'
getSum(‘123’, ‘324’)  ->  ‘447’
getSum(‘111111111111111111111111111111111111111111111111111’,        ’23333333333333333333333333333333333333333333333333’)
-> ‘3444444.......4444444’
 
```
<hr>

## TASK № 3
###  Create function that gets two arguments: the first one is array of objects, the second one is string (name of author) 
### Your function should return quantity of posts with author from argument of function and the quantity of all comments with the same author. Example of array:

### For example:
```
function getQuntityPostsByAuthor (listOfPosts1, 'Rimus') {
// your code
}
 
Your result should be a string like this :  'Post:1,comments:3'  ,
If there aren’t post or comments your result will be a string like this 'Post:0,comments:0'
```
 
```
let listOfPosts2 = [
{
    id: 1,
    post: 'some post1',
    title: 'title 1',
    author: 'Ivanov',
    comments: [
        {
            id: 1.1,
            comment: 'some comment1',
            title: 'title 1',
            author: 'Rimus'
        },
        {
            id: 1.2,
            comment: 'some comment2',
            title: 'title 2',
            author: 'Uncle'
        }
    ]
},
{
    id: 2,
    post: 'some post2',
    title: 'title 2',
    author: 'Ivanov',
    comments: [
        {
            id: 1.1,
            comment: 'some comment1',
            title: 'title 1',
            author: 'Rimus'
        },
        {
            id: 1.2,
            comment: 'some comment2',
            title: 'title 2',
            author: 'Uncle'
        },
        {
            id: 1.3,
            comment: 'some comment3',
            title: 'title 3',
            author: 'Rimus'
        }
    ]
},
{
    id: 3,
    post: 'some post3',
    title: 'title 3',
    author: 'Rimus'
},
{
    id: 4,
    post: 'some post4',
    title: 'title 4',
    author: 'Uncle'
}
 
]
```

## * Don`t change the given functions naming and don't delete this part of code:
```
module.exports = {
  validateTitle,
  sum,
};
```

- Useful links:
-  
- :black_small_square:         https://learn.javascript.ru/function-basics
- :black_small_square:         https://learn.javascript.ru/function-declaration-expression
- :black_small_square:         https://learn.javascript.ru/recursion
- :black_small_square:         https://learn.javascript.ru/named-function-expression
- :black_small_square:         https://learn.javascript.ru/arguments-pseudoarray
- :black_small_square:         https://learn.javascript.ru/functions-closures
- :black_small_square:         https://learn.javascript.ru/object-methods
- :black_small_square:         https://learn.javascript.ru/call-apply
- :black_small_square:         https://learn.javascript.ru/bind
- :black_small_square:         http://ryanmorr.com/understanding-scope-and-context-in-javascript/
- :black_small_square:         http://frontender.info/demystifying-this-in-javascript/
- :black_small_square:         JavaScript Allongé (https://leanpub.com/javascriptallongesix/read)
``

