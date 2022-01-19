
const vowelsCount = (str) => {
    let count = 0;
    let vowels = new Array("a", "e", "i", "o", "u");
    str.toLowerCase().split('').forEach(char => {
        if(vowels.includes(char)){
            count+=1;
        }
    });
    return count;
}
const findVowels = (str) => {
    if(typeof str !== "string") {
        return "Passed argument is not a string";
    }
    if(str === '') {
        return 'String is empty';
    }
    if (vowelsCount(str) == 0) {
        return 'String does not contain vowels';
    }
    else {
        return vowelsCount(str);
    }
};

module.exports = findVowels;
