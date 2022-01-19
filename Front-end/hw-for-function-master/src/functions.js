function isBigger(firstNum, secondNum){
  let result = firstNum > secondNum;
  return result;
}

function isSmaller(a, b) {
  let result = !isBigger(a,b);
  return result;
}

function getMin(...numbers) {
  let min = arguments[0];
  for(let i = 1; i < arguments.length; i++){
    if(arguments[i] < min){
      min = arguments[i];
    }
  }
  return min;
}

function makeNumber(string) {
  let str = '';
  let arrStr = string.split('');
  for(let i =0; i  < arrStr.length; i++){
    let num = Number(arrStr[i]);
      if(!isNaN(num)){
        str += arrStr[i]; 
      }
    }
    return str;
}

function countNumbers(string) {
  let madeString = makeNumber(string);
  let arrayStr = madeString.split('');
  let result = new Object();
  for(let i=0; i < arrayStr.length; i++){
    let count = 0;
      for(let j =0; j < arrayStr.length; j++){
        if(arrayStr[i] == arrayStr[j]){
          count++;
        }
        result[arrayStr[i]] = count;
      }
    }
  return result;
}

function pipe(number, ...functions) {
  for(let f = 0; f< functions.length; f++){
    let newFunc = functions[f];
    number = newFunc(number);
  }
  return number;
}

function isLeapYear(date) {
  if(typeof date == "string") {
  let isValid = /^([0-2][0-9]{3})\-(0[1-9]|1[0-2])\-([0-2][0-9]|3[0-1]) ([0-1][0-9]|2[0-3]):([0-5][0-9])\:([0-5][0-9])( ([\-\+]([0-1][0-9])\:00))?$/.test(date);
  if(isValid) {
    let year = date[0] + date[1] + date[2] + date[3];
    year = makeNumber(year);

    if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)){
      return `${year} is a leap year`;
    } else {
      return `${year} is not a leap year`;
    }
  } else if (!isValid) {
      return `Invalid Date`;
   } 
  } else if (typeof date == "number") {
  const dateObject = new Date(date);
  if (dateObject == "Invalid Date"){
    return "Invalid Date";
  }

  const formatter = new Intl.DateTimeFormat('en-GB', {
    year: 'numeric',
    month: '2-digit',
    day: '2-digit',
    hour: '2-digit',
    minute: 'numeric',
    second: 'numeric'
  });

  let formatedDate = formatter.format(dateObject);

  let year = formatedDate[6] + formatedDate[7] + formatedDate[8] + formatedDate[9];
  let mm = formatedDate[0] + formatedDate[1];
  let dd = formatedDate[3] + formatedDate[4];
  let hh = formatedDate[12] + formatedDate[13];
  let m = formatedDate[15] + formatedDate[16];
  let ss = formatedDate[18] + formatedDate[19];
  
  let str = year+"-"+mm+"-"+dd+" "+hh+":"+m+":"+ss;
  
  let isValid = /^([0-2][0-9]{3})\-(0[1-9]|1[0-2])\-([0-2][0-9]|3[0-1]) ([0-1][0-9]|2[0-3]):([0-5][0-9])\:([0-5][0-9])( ([\-\+]([0-1][0-9])\:00))?$/.test(str);
  if (isValid) {
    year = makeNumber(year);
    if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) {
    return `${year} is a leap year`;
  } else {
    return `${year} is not a leap year`;
 }
}
}
}

module.exports = {
  isBigger,
  isSmaller,
  makeNumber,
  countNumbers,
  getMin,
  pipe,
  isLeapYear,
};
