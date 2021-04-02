const compute = require('../compute');
const {expect} = require('chai');

//AAA Assemble Action Assert

//suite

describe("testing compute module", () => {
    it("testing add fn", () => {
        var expected = 25;
        var actual = compute.add(10,15);
        expect(actual).to.be.equal(expected); 
    });

    it("testing sub fn", () => {
        var expected = 5;
        var actual = compute.sub(10,5);
        expect(actual).to.be.equal(expected); 
    });
});