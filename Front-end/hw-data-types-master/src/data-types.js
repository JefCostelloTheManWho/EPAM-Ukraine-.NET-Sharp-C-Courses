function convert(...array){
	for(let i=0; i<array.length; i++){
		if(typeof array[i] === 'string'){
			array[i] = parseInt(array[i]);
		}else{
			array[i] = '' + array[i];
		}
	}
	return array;
}

function executeforEach(array, callback) {
	for(let i=0; i< array.length; i++){
		callback(array[i], i);
	}
}

function mapArray(array, callback) {
	executeforEach(array, (item, index) => {
		array[index] = callback(item - 0);
	});
	return array;
}

function filterArray(array, callback){
	let filteredArr = [];
	executeforEach(array, (item) => {
		if(callback(item)){
			filteredArr.push(item);
		}
	});
	return filteredArr;
}

function flipOver(string){
  let reverseStr = '';
	executeforEach(string, (item,index) => {
		reverseStr += string[string.length - index -1];
	});
	return reverseStr;
}

function makeListFromRange(range) {
  if(range[0] > range[1]) {
  const temp = range[0];
  range[0] = range[1];	
  range[1] = temp;
} 
  arrLength = range[1] - range[0] + 1;
  if(range[1] === undefined){
  let mas = [];
  mas.push(range[0])
  return mas;
  }
  else{
  let mas = [];
  for(let i= 0; i < arrLength; i++) {
    mas[i] = range[0] + i;
  }
return mas;
  }
}	

function getArrayOfKeys(obj, key){
	let arrOfKeys = [];
	executeforEach(obj, (item) => {
		arrOfKeys.push(item[key]);
	});
	return arrOfKeys;
}

function substitute(arr) {
  let newArr = arr.slice();
  const range = 30;
  for(let i = 0; i < newArr.length; i++) {
    if(newArr[i] - 0 < range) {
      newArr[i] = '*';
     }
  }
	return newArr;
}

function getPastDay(date, daysAgo){
	const newDate = new Date(date.getFullYear(), date.getMonth(), date.getDate()-daysAgo);
	return newDate.getDate();
}

function formatDate(date){

	let dd = date.getDate();
	const TEN = 10;
	if (dd < TEN) {
		dd = '0' + dd;
	}
	let mm = date.getMonth() + 1;
	if (mm < TEN) {
		mm = '0' + mm;
	}
	let yy = date.getFullYear();
	if (yy < TEN) {
		yy = '0' + yy;
	}
	let hh = date.getHours();
	if (hh < TEN) {
		hh = '0' + hh;
	} 
	let min = date.getMinutes();
	if (min < TEN) {
		min = '0' + min;
	} 
  return yy + '/' + mm + '/' + dd + ' ' + hh + ':' + min;
  
}

module.exports = {
  convert,
  executeforEach,
  mapArray,
  filterArray,
  flipOver,
  makeListFromRange,
  getArrayOfKeys,
  substitute,
  getPastDay,
  formatDate,
};
