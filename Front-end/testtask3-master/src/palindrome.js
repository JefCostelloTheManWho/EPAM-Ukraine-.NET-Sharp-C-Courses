const clean = (str) => str.toLowerCase().replace(/[\W_]/g,'');
    const isPalidsrom = (str) => {
        const cleanStr = clean(str);
        for(let i =0; i< str.length / 2;i++){
            if(cleanStr[i] != cleanStr[cleanStr.length - 1 - i]){
                return false;
            }
        }
        return true;
    }
const detectPalindrome = (str) => {
    if(typeof str !== "string") {
        return "Passed argument is not a string";
    }
    if(str === '') {
        return 'String is empty';
    }
    if (isPalidsrom(str)) {
        return 'This string is palindrome!';
    }
    else {
        return 'This string is not a palindrome!';
    }
};

module.exports = detectPalindrome;
