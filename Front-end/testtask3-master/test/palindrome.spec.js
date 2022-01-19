const detectPalindrome = require('../src/palindrome');

describe('detectPalindrome function testing', () => {
  it('should return "Passed argument is not a string" when type of passed argumnent is not an "string"', () => {
    expect(detectPalindrome(true)).to.equal("Passed argument is not a string");
  });
  it('should return "Passed argument is not a string" when type of passed argumnent is not an "string"', () => {
    expect(detectPalindrome([])).to.equal("Passed argument is not a string");
  });
  it('should return "Passed argument is not a string" when type of passed argumnent is not an "string"', () => {
    expect(detectPalindrome(2)).to.equal("Passed argument is not a string");
  });
  it('should return "String is empty" when type of passed argumnent is not an "array"', () => {
    expect(detectPalindrome('')).to.equal("String is empty");
  });
  it('should return "This string is palindrome! when string is palindrome', () => {
    expect(detectPalindrome("ara")).to.equal('This string is palindrome!');
  });
  it('should return "This string is palindrome! when string is palindrome', () => {
    expect(detectPalindrome("Огоміннімого")).to.equal('This string is palindrome!');
  });
  it('should return "This string is palindrome! when string is palindrome', () => {
    expect(detectPalindrome("TARARAT")).to.equal('This string is palindrome!');
  });
  it('should return "This string is palindrome! when string is palindrome', () => {
    expect(detectPalindrome("kotik kitoK")).to.equal("This string is palindrome!");
  });
  it('should return "This string is palindrome! when string is palindrome', () => {
    expect(detectPalindrome("I can fly ylf nac i")).to.equal("This string is palindrome!");
  });
  it('should return "This string is not a palindrome!" when string is not a palindrome', () => {
    expect(detectPalindrome("testtest")).to.equal('This string is not a palindrome!');
  });
  it('should return "This string is not a palindrome!" when string is not a palindrome', () => {
    expect(detectPalindrome("hello hi")).to.equal('This string is not a palindrome!');
  });
  it('should return "This string is not a palindrome!" when string is not a palindrome', () => {
    expect(detectPalindrome("I am okey yeko ya i")).to.equal('This string is not a palindrome!');
  });
  it('should return "This string is not a palindrome!" when string is not a palindrome', () => {
    expect(detectPalindrome("TARAKRAT")).to.equal('This string is not a palindrome!');
  });
  it('should return "This string is not a palindrome!" when string is not a palindrome', () => {
    expect(detectPalindrome("w23w")).to.equal('This string is not a palindrome!');
  });
});

