const {cache, forwardBackwardSteps, applyAll, sum, mul} = require('../src/advanced-functions');
require('mocha-sinon');
const sinon = require('sinon');



describe('cache function', () => {
    it('should call complex function', () => {
        let complexFunction = sinon.stub().callsFake((arg1, arg2) => {
            return arg1 + arg2;
        });
        let cachedFunction = cache(complexFunction);
        cachedFunction(1, 2);
        sinon.assert.calledWith(complexFunction, 1, 2);
        sinon.assert.calledOnce(complexFunction);
    });

    it('should not call complex function again', () => {
        let complexFunction = sinon.stub().callsFake((arg1, arg2) => {
            return arg1 + arg2;
        });
        let cachedFunction = cache(complexFunction);
        cachedFunction(1, 2);
        let ret = cachedFunction(1, 2);
        expect(ret).to.be.equal(3);
        sinon.assert.calledWith(complexFunction, 1, 2);
        sinon.assert.calledOnce(complexFunction);
    });

    it('should call complex function if arguments are different', () => {
        let complexFunction = sinon.stub().callsFake((arg1, arg2) => {
            return arg1 + arg2;
        });
        let cachedFunction = cache(complexFunction);
        let ret1 = cachedFunction(1, 2);
        expect(ret1).to.be.equal(3);
        let ret2 = cachedFunction(1, 5);
        expect(ret2).to.be.equal(6);
        sinon.assert.calledWith(complexFunction, 1, 2);
        sinon.assert.calledWith(complexFunction, 1, 5);
        sinon.assert.calledTwice(complexFunction);
    });
})

describe('forwardBackwardStep object', () => {
    beforeEach(function () {
        this.sinon.stub(console, 'log');
    });

    it('It should not return "undefined"', () => {
        const obj = {...forwardBackwardSteps};
        expect(obj.forward()).to.not.be.equal(undefined);
    });

    it('It should not return "undefined"', () => {
        const obj = {...forwardBackwardSteps};
        expect(obj.backward()).to.not.be.equal(undefined);
    });

    it('Should console log 1', () => {
        const obj = {...forwardBackwardSteps};
        obj.forward()
            .forward()
            .backward()
            .forward()
            .backward()
            .revealStep()
        expect(console.log.calledOnce).to.be.true;
        expect(console.log.calledWith(1)).to.be.true;
    });

    it('Should console log 3', () => {
        const obj = {...forwardBackwardSteps};
        obj.forward()
            .forward()
            .backward()
            .forward()
            .forward()
            .revealStep()
        expect(console.log.calledOnce).to.be.true;
        expect(console.log.calledWith(3)).to.be.true;
    });
})

describe('applyAll function testing', () => {
    it('Should return correct sum according to given arguments in function', () => {
        expect(applyAll(sum, 1, 2, 3))
            .to.eql(6);
    });
    it('Should return correct sum according to given arguments in function', () => {
        expect(applyAll(sum, 22, 232))
            .to.eql(254);
    });
    it('Should return correct sum according to given arguments in function', () => {
        expect(applyAll(sum, 5, 3, 5, 12, 10, 22, 1, 51, 33))
            .to.eql(142);
    });
    it('Should return correct sum according to given arguments in function', () => {
        expect(applyAll(sum, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1))
            .to.eql(17);
    });
    it('Should return correct mul according to given arguments in function', () => {
        expect(applyAll(mul, 21, 2, 5))
            .to.eql(210);
    });
    it('Should return correct mul according to given arguments in function', () => {
        expect(applyAll(mul, 6, 6))
            .to.eql(36);
    });
    it('Should return correct mul according to given arguments in function', () => {
        expect(applyAll(mul, 5, 2, 12, 1, 6, 32, 31, 88, 121, 4, 2))
            .to.eql(60841820160);
    });
    it('Should return correct mul according to given arguments in function', () => {
        expect(applyAll(mul, 3, 2, 1, 0))
            .to.eql(0);
    });

});

