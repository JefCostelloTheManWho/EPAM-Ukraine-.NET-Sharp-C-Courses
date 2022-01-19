const getSum = (str1, str2) => {
  let num1 = Number(str1);
  let num2 = Number(str2);
  if(typeof str1 != "string" || typeof str2 != "string" || isNaN(num1) || isNaN(num2)) {
    return false;
  }
  let result = num1 + num2;
  return result.toString();
};

const getQuantityPostsByAuthor = (listOfPosts, authorName) => {
  if (Array.isArray(listOfPosts)) {
    let postsCount = 0;
    let commentsCount = 0;
    for(let i = 0; i < listOfPosts.length; i++) {
      if(listOfPosts[i].author == authorName) {
        postsCount++;
      }
      let comments = listOfPosts[i].comments;
      if(comments != undefined) {
      comments.forEach(com => {
        if(com.author == authorName){
          commentsCount++;
        }
        });
      }
    }
    return `Post:${postsCount},comments:${commentsCount}`;
  }
};

const tickets=(people) => {
  let cash = 25;
    for(let money = 1; money < people.length; money++) {
      if(people[0] > 25) {
        return "NO";
      } else if ( people[money] > cash && Math.abs(people[money] - 25) > cash) {
        return "NO";
      }else if(people[money] == 25) {
        cash += 25;
      } else {
      cash += people[money] - 25;
      }
    }
  return "YES";
};


module.exports = {getSum, getQuantityPostsByAuthor, tickets};
