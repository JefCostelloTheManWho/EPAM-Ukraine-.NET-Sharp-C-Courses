const findVowels = require('../src/findvowels');

describe('findVowels function', () => {
  it('should return "Passed argument is not a string" when type of passed argumnent is not an "string"', () => {
    expect(findVowels(true)).to.equal('Passed argument is not a string');
  });
  it('should return "Passed argument is not a string" when type of passed argumnent is not an "string"', () => {
    expect(findVowels(2)).to.equal('Passed argument is not a string');
  });
  it('should return "Passed argument is not a string" when type of passed argumnent is not an "string"', () => {
    expect(findVowels([])).to.equal('Passed argument is not a string');
  });
  it('should return "String is empty" when string is empty', () => {
    expect(findVowels("")).to.equal('String is empty');
  });
  it('should return "String does not contain vowels" when string does not contain vowels', () => {
    expect(findVowels('drtnmnn')).to.equal('String does not contain vowels');
  });
  it('should return "String does not contain vowels" when string does not contain vowels', () => {
    expect(findVowels('TRDDDFTRKKLLLPNM')).to.equal('String does not contain vowels');
  });
  it('should return number of vowels', () => {
    expect(findVowels('drtaaein')).to.equal(4);
  });
  it('should return number of vowels', () => {
    expect(findVowels('rweqqwrAAAA')).to.equal(5);
  });
  it('should return number of vowels', () => {
    expect(findVowels('bad')).to.equal(1);
  });
});

