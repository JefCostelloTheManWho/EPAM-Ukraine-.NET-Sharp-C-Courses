const evenNumbersInArray = require('../src/even-numbers');

describe('evenNumbersInArray function', () => {
  it('should return "Passed argument is not an array or empty" when type of passed argumnent is not an "array"', () => {
    expect(evenNumbersInArray(true)).to.equal('Passed argument is not an array or empty');
  });
  it('should return "Passed argument is not an array or empty" when type of passed argumnent is not an "array"', () => {
    expect(evenNumbersInArray(1)).to.equal('Passed argument is not an array or empty');
  });
  it('should return "Passed argument is not an array or empty" when type of passed argumnent is not an "array"', () => {
    expect(evenNumbersInArray([])).to.equal('Passed argument is not an array or empty');
  });
  it('should return "Passed array not have even numbers in array" when given array not have even numbers', () => {
    expect(evenNumbersInArray([1, 3, 5])).to.equal('Passed array does not contain even numbers');
  });
  it('should return "Passed array does not contain even numbers" when given array not have even numbers', () => {
    expect(evenNumbersInArray([27, 33, 47, 67])).to.equal('Passed array does not contain even numbers');
  });
  it('should return "Passed array not have even numbers in array" when given array not have even numbers', () => {
    expect(evenNumbersInArray([5])).to.equal('Passed array does not contain even numbers');
  });
  it('should return even numbers [2,4,6] from array', () => {
    expect(evenNumbersInArray([1,2,3,4,5,6])).to.eql([2,4,6]);
  });
  it('should return even numbers [2,12,10] from array', () => {
    expect(evenNumbersInArray([2,3,7,12,10])).to.eql([2,12,10]);
  });
  it('should return even numbers [6] from array', () => {
    expect(evenNumbersInArray([6])).to.eql([6]);
  });
  it('should return even numbers [56] from array', () => {
    expect(evenNumbersInArray([55,27,33,11,31,56])).to.eql([56]);
  });
});

