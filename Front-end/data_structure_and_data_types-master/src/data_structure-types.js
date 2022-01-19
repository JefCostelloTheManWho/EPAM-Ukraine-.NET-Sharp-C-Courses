const validateTitle = (value) => {
  if(typeof value != "string"){
    return 'Incorrect input data';
  }
  if(value.length <= 2 || value.length >= 20 || value[0] != value[0].toUpperCase() ||  Number.isInteger(value.charAt(0) - 0)) {
    return 'INVALID';
  }
    return 'VALID';
}

const sum = (value1, value2) => {

  if(typeof value1 == "number" && (value1 % 3 == 0 || value1 % 5 == 0 || value1 % 15 == 0)){
    value1 *= -1;
  }
  if(typeof value2 == "number" && (value2 % 3 == 0 || value2 % 5 == 0 || value2 % 15 == 0)){
    value2 *= -1;
  }
  value1 -=0;
  value2 -=0;

  return value1 + value2;
};

module.exports = {
  validateTitle,
  sum,
};
