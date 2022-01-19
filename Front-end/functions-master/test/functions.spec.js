const sinon = require('mocha-sinon');
const {getSum, getQuantityPostsByAuthor, tickets} =require('../src/func');
const {listOfPosts, listOfPosts2}=require('../src/posts');

describe('TASK2. Get Sum of strings', ()=>{
  it('the sum of 2 strings should be correct', ()=>{
    expect(getSum('123', '123')).to.equal('246');
    expect(getSum('123', '100')).to.equal('223');
    expect(getSum('444444', '444444')).to.equal('888888');
    expect(getSum('', '444444')).to.equal('444444');
  });
  it('the result of the sum should be converted into a string', ()=>{
    expect(typeof getSum('123', '123')).to.equal('string');
  });
  it('the parameters should not be an array or an object', ()=>{
    expect(getSum([], [])).to.equal(false);
    expect(getSum({}, {})).to.equal(false);
    expect(getSum([], {})).to.equal(false);
  });
  it('the parameters should be a string of numbers', ()=>{
    expect(getSum('lena', 'masha')).to.equal(false);
  });
});


describe('TASK3. Get Quantity of Posts By Author', ()=>{
  it('should return a string with correct quantity of posts and comments of Rimus', ()=>{
    expect(getQuantityPostsByAuthor(listOfPosts, 'Rimus')).to.equal('Post:1,comments:3');
    expect(getQuantityPostsByAuthor(listOfPosts2, 'Rimus')).to.equal('Post:2,comments:1');
  });
  it('should return a string with correct quantity of posts and comments of Ivanov', ()=>{
    expect(getQuantityPostsByAuthor(listOfPosts, 'Ivanov')).to.equal('Post:2,comments:0');
    expect(getQuantityPostsByAuthor(listOfPosts2, 'Ivanov')).to.equal('Post:1,comments:2');
  });
  it('should return a string with correct quantity of posts and comments of Uncle', ()=>{
    expect(getQuantityPostsByAuthor(listOfPosts, 'Uncle')).to.equal('Post:1,comments:2');
    expect(getQuantityPostsByAuthor(listOfPosts2, 'Uncle')).to.equal('Post:1,comments:2');
  });
  it('should return a string with correct quantity of posts and comments of a non-existing author', ()=>{
    expect(getQuantityPostsByAuthor(listOfPosts, [])).to.equal('Post:0,comments:0');
    expect(getQuantityPostsByAuthor(listOfPosts, 'Lena')).to.equal('Post:0,comments:0');
  });
});


describe('TASK1. Tickets ', ()=>{
  it('The clerk does not have money to give a change', ()=>{
    expect(tickets([25, 50, 100])).to.equal('NO');
  });
  it('The clerk  has to have money to give a change', ()=>{
    expect(tickets([25, 50, 25, 25, 100])).to.equal('YES');
  });
  it('The clerk has to have money to give a change', ()=>{
    expect(tickets([25, 50, 25, 50, 25, 50, 25, 100])).to.equal('YES');
  });
  it('The clerk does not have money to give a change', ()=>{
    expect(tickets([35, 25, 50, 100])).to.equal('NO');
  });
  it('The clerk has to have money to give a change', ()=>{
    expect(tickets([25, 25, 50, 50, 25, 100])).to.equal('YES');
  });
  it('The clerk does not have money to give a change', ()=>{
    expect(tickets([100,25,50])).to.equal('NO');
  });
});
