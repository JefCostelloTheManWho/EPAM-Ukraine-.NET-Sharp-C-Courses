const fibonacciNumbers = require('../src/fibonacci');

describe('twinArrayNumbers function', () => {
  it('should return "Passed argument is not a number" when type of passed argumnent is not an "number"', () => {
    expect(fibonacciNumbers(true)).to.equal('Passed argument is not a number');
  });
  it('should return "Passed argument is not a number" when type of passed argumnent is not an "number"', () => {
    expect(fibonacciNumbers('q')).to.equal('Passed argument is not a number');
  });
  it('should return "Passed argument is not a number" when type of passed argumnent is not an "number"', () => {
    expect(fibonacciNumbers([])).to.equal('Passed argument is not a number');
  });
  it('should return fibonacci number', () => {
    expect(fibonacciNumbers(1)).to.equal(1);
  });
  it('should return fibonacci number', () => {
    expect(fibonacciNumbers(6)).to.equal(8);
  });
  it('should return fibonacci number', () => {
    expect(fibonacciNumbers(11)).to.equal(89);
  });
  it('should return fibonacci number', () => {
    expect(fibonacciNumbers(25)).to.equal(75025);
  });
});

