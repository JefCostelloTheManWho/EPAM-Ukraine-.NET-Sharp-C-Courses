const fibonacciNumbers = (num) => {

    if(!Number.isInteger(num)) {
        return "Passed argument is not a number";
    }
    else{
        // search through recursion
            return num <= 1 ? num : fibonacciNumbers(num - 1) + fibonacciNumbers(num - 2);
        }
        // search throght cycle
        // let arr = [];
        // arr.length = 40;
        // //initialize first numbers of fibonacci
        // arr[0] = 0;
        // arr[1] = 1;

        // for (let n = 2; n <= num; n++)
        // {
        //     arr[n] = arr[n - 1] + arr[n - 2];
        // }
        // alert(arr[num]);
};
module.exports = fibonacciNumbers;
