const validateTitle = require('../src/data_structure-types.js').validateTitle;
const sum = require('../src/data_structure-types.js').sum;

describe('validateTitle function testing', () => {
  it("Should return string: 'Incorrect input data' according to 'false' -  given argument", () => {
    expect(validateTitle(false))
        .to.eql('Incorrect input data');
  });
  it("Should return string: 'Incorrect input data' according to [] - given  argument", () => {
    expect(validateTitle([]))
        .to.eql('Incorrect input data');
  });
  it("Should return string: 'Incorrect input data' according to 15 -  given  argument", () => {
    expect(validateTitle(15))
        .to.eql('Incorrect input data');
  });
  it("Should return string: 'INVALID' according to 's' - given argument", () => {
    expect(validateTitle('s'))
        .to.eql('INVALID');
  });
  it("Should return string: 'INVALID' according to '12title' - given argument", () => {
    expect(validateTitle('12title'))
        .to.eql('INVALID');
  });
  it("Should return string: 'VALID' according to 'Title!' - given argument", () => {
    expect(validateTitle('Title!'))
        .to.eql('VALID');
  });
  it("Should return string: 'VALID' according to 'Title? - given argument'", () => {
    expect(validateTitle('Title?'))
        .to.eql('VALID');
  });
});


describe('sum function testing', () => {
  it("Should return sum - 10,  according to given arguments - ('25',10) ", () => {
    expect(sum('25', 15))
        .to.eql(10);
  });
  it("Should return sum - 44,  according to given arguments - (41,'3') ", () => {
    expect(sum(41, '3'))
        .to.eql(44);
  });
  it("Should return sum - -42,  according to given arguments - ('3',45) ", () => {
    expect(sum('3', 45))
        .to.eql(-42);
  });
  it("Should return sum - 0,  according to given arguments - ('15',15) ", () => {
    expect(sum('15', 15))
        .to.eql(0);
  });
});

