const sinon = require('mocha-sinon');

const convert = require('../src/data-types').convert;
const executeforEach = require('../src/data-types').executeforEach;
const mapArray = require('../src/data-types').mapArray;
const filterArray = require('../src/data-types').filterArray;
const flipOver = require('../src/data-types').flipOver;
const makeListFromRange = require('../src/data-types').makeListFromRange;
const getArrayOfKeys = require('../src/data-types').getArrayOfKeys;
const substitute = require('../src/data-types').substitute;
const getPastDay = require('../src/data-types').getPastDay;
const formatDate = require('../src/data-types').formatDate;

describe('convert function testing', () => {
  it('Should return correct array according to function', () => {
    expect(convert(1, '2', 3, '4'))
        .to.eql(['1', 2, '3', 4]);
  });
  it('Should return correct array according to function', () => {
    expect(convert(2, 3, 44, '55', 22))
        .to.eql(['2', '3', '44', 55, '22']);
  });
});

describe('executeforEach function testing', () => {
  beforeEach(function() {
    this.sinon.stub(console, 'log');
  });
  it('Should return correct logs according to function', () => {
    executeforEach([1,2,3],(el) => {console.log(el * 2)})
    expect( console.log.calledWith(2)).to.be.true;
    expect( console.log.calledWith(4)).to.be.true;
    expect( console.log.calledWith(6)).to.be.true;
    });
  it('Should return correct logs according to function', () => {
    executeforEach([2,12,5,7,6],(el) => {console.log(el * 2)})
    expect( console.log.calledWith(4)).to.be.true;
    expect( console.log.calledWith(24)).to.be.true;
    expect( console.log.calledWith(10)).to.be.true;
    expect( console.log.calledWith(14)).to.be.true;
    expect( console.log.calledWith(12)).to.be.true;
    });
});

describe('mapArray function testing', () => {
  it('Should return correct array according to function', () => {
    expect(mapArray([2, '5', 8], function(el) {
      return el + 3;
    })).to.eql([5, 8, 11]);
  });
  it('Should return correct array according to function', () => {
    expect(mapArray([5, 2, 7, 2], function(el) {
      return el + 3;
    })).to.eql([8, 5, 10, 5]);
  });
});

describe('filterArray function testing', () => {
  it('Should return correct array according to function', () => {
    expect(filterArray([2, 5, 8], function(el) {
      return el % 2 === 0;
    })).to.eql([2, 8]);
  });
  it('Should return correct array according to function', () => {
    expect(filterArray([11, 22, 33], function(el) {
      return el % 2 === 0;
    })).to.eql([22]);
  });
});

describe('flipOver function testing', () => {
  it('Should return correct string according to function', () => {
    expect(flipOver('hey world'))
        .to.eql('dlrow yeh');
  });
  it('Should return correct array according to function', () => {
    expect(flipOver('p2'))
        .to.eql('2p');
  });
});

describe('flipOver function testing', () => {
  it('Should return correct string according to function', () => {
    expect(flipOver('hey world'))
        .to.eql('dlrow yeh');
  });
  it('Should return correct array according to function', () => {
    expect(flipOver('p2'))
        .to.eql('2p');
  });
});

describe('makeListFromRange function testing', () => {
  it('Should return correct array according to function', () => {
    expect(makeListFromRange([2, 7]))
        .to.eql([2, 3, 4, 5, 6, 7]);
  });
  it('Should return correct array according to function', () => {
    expect(makeListFromRange([1, 2]))
        .to.eql([1, 2]);
  });
});

const actors = [
  {name: 'tommy', age: 36},
  {name: 'lee', age: 28},
];

describe('getArrayOfKeys function testing', () => {
  it('Should return correct array according to function', () => {
    expect(getArrayOfKeys(actors, 'age'))
        .to.eql([36, 28]);
  });
  it('Should return correct array according to function', () => {
    expect(getArrayOfKeys(actors, 'name'))
        .to.eql(['tommy', 'lee']);
  });
});

describe('substitute function testing', () => {
  it('Should return correct array according to function', () => {
    expect(substitute([58, 14, 48, 2, 31, 29]))
        .to.eql([58, '*', 48, '*', 31, '*']);
  });
  it('Should return correct array according to function', () => {
    expect(substitute([11, 12, 13, 29]))
        .to.eql(['*', '*', '*', '*']);
  });
});

describe('getPastDay function testing', () => {
  it('Should return correct string with date according to function', () => {
    expect(getPastDay(new Date(2019, 0, 2), 1)).to.eql(1);
  });
  it('Should return correct string with date according to function', () => {
    expect(getPastDay(new Date(2019, 0, 2), 2)).to.eql(31);
  });
  it('Should return correct string with date according to function', () => {
    expect(getPastDay(new Date(2019, 0, 2), 365)).to.eql(2);
  });
});

describe('formatDate function testing', () => {
  it('Should return correct string with date according to function', () => {
    expect(formatDate(new Date('6/15/2018 09:15:00')))
        .to.eql('2018/06/15 09:15');
  });
  it('Should return correct string with date according to function', () => {
    expect(formatDate(new Date('2/22/2015 19:12:42')))
        .to.eql('2015/02/22 19:12');
  });
});
