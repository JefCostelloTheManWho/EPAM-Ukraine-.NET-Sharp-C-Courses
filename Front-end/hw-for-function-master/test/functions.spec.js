const functions = require('../src/functions');

const isBigger = functions.isBigger;
const isSmaller = functions.isSmaller;
const getMin = functions.getMin;
const makeNumber = functions.makeNumber;
const countNumbers = functions.countNumbers;
const pipe = functions.pipe;
const isLeapYear = functions.isLeapYear;

const addOne = (x) => {
  return x + 1;
};

describe('isBigger', () => {
  it(`Should accept two arguments and returns true
    if first one has greater value than second one or false otherwise.`, () => {
    expect(isBigger(5, -1)).to.eql(true);
  });
});

describe('isSmaller', () => {
  it(`Should accept two arguments and returns true if first one has 
  lesser value than second one or false otherwise`, () => {
    expect(isSmaller(5, -1)).to.eql(false);
  });
});

describe('getMin', () => {
  it(`Should accept arbitrary number of integer arguments 
  and returns the one with the smallest value.`, () => {
    expect(getMin(3, 0, -3)).to.eql(-3);
  });
});

describe('makeNumber', () => {
  it(`Should accept a string with different symbols and 
  return string of numbers from passed argument`, () => {
    expect(makeNumber('erer384jjjfd123')).to.eql('384123');
    expect(makeNumber('123098h76gfdd')).to.eql('12309876');
    expect(makeNumber('ijifjgdj')).to.eql('');
  });
});

describe('countNumbers', () => {
  it(`Should accept string with different symbols and 
  return object which contains counts of each numbers.`, () => {
    expect(countNumbers('erer384jj4444666888jfd123'))
        .to.eql({'1': 1, '2': 1, '3': 2, '4': 5, '6': 3, '8': 4});
    expect(countNumbers('jdjjka000466588kkkfs662555'))
        .to.eql({'0': 3, '2': 1, '4': 1, '5': 4, '6': 4, '8': 2});
    expect(countNumbers('')).to.eql({});
  });
});

describe('pipe', () => {
  it(`Should accept a number as a first argument and arbitrary 
  amount of functions after. The number should be passed to each
  function in sequence. The number passed to the next function 
  is the returned result of previous function.`, () => {
    expect(pipe(1, addOne)).to.eql(2);
    expect(pipe(1, addOne, addOne)).to.eql(3);
  });
});

describe('isLeapYear', () => {
  it(`Should accept a number of millisecond or string of date as 
  an argument. This function checks if passed argument is a Leap Year.
  If it is a Leap Year, function should return a string – ‘ “year” 
  is a leap year’.(‘year’ means number of year passed as an argument).`,
  () => {
    expect(isLeapYear('2020-01-01 00:00:00'))
        .to.eql('2020 is a leap year');
  });
  it(`Should accept a number of millisecond or string of date as 
  an argument. This function checks if passed argument is a Leap Year.
  If it isn’t, should return string - ‘ “year” 
  is not a leap year’.(‘year’ means number of year passed as an argument).`,
  () => {
    expect(isLeapYear('2021-01-15 13:00:00'))
        .to.eql('2021 is not a leap year');
    expect(isLeapYear('2200-01-15 13:00:00'))
        .to.eql('2200 is not a leap year');
    expect(isLeapYear(1213131313))
        .to.eql('1970 is not a leap year');
  });
  it(`Should accept a number of millisecond or string of date as 
  an argument. If argument gas inappropriate format 
  should return ‘Invalid Date’`,
  () => {
    expect(isLeapYear('2020-01-01 00:00:00777'))
        .to.eql('Invalid Date');
    expect(isLeapYear(1213131313135465656654564646542132132131))
        .to.eql('Invalid Date');
  });
});
