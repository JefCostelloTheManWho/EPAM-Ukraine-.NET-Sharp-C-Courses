const snakeArray = require('../src/snake-array');

const snakeMatrix1 = [
    [1, 2, 3, 4, 5, 6, 7],
    [22, 23, 24, 25, 26, 27, 8],
    [21, 36, 37, 38, 39, 28, 9],
    [20, 35, 42, 41, 40, 29, 10],
    [19, 34, 33, 32, 31, 30, 11],
    [18, 17, 16, 15, 14, 13, 12]
];

describe('snakeArray function', () => {
    it('Should return two-dimensional array with a spiral snake pattern', () => {
        expect(snakeArray(1)).to.deep.equal(snakeMatrix1)
    });
    it('Result should be typeof Array.', () => {
        expect(snakeArray(1)).to.be.an('array')
    });
    it('Array should have 6 rows.', () => {
        expect(snakeArray(1).length).to.equal(6)
    });
    it('Each row should have 7 columns.', () => {
        const result = snakeArray(1);
        for (let i = 0; i < result.length; i++) {
            expect(result[i].length).to.equal(7)
        }    
    });
})
