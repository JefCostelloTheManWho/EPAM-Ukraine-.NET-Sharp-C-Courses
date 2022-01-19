const evenNumbersInArray = (array) => {
    let newArr = [];
    if(!Array.isArray(array) || array.length == 0) {
        return 'Passed argument is not an array or empty';
    }
    for(let num = 0; num < array.length; num++) {
        if(array[num] % 2 == 0) {
            newArr.push(array[num]);
        }
    }
    if(newArr.length == 0) {
        return "Passed array does not contain even numbers";
    }
    else {
        return newArr;
    }
};
module.exports = evenNumbersInArray;

