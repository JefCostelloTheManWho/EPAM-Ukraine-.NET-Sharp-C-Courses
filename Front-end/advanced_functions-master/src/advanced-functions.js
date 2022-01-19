//=============================================
// ------------------------------------ TASK №1
//=============================================
const cache = (func) => {
    
    const cachedResults = {};
    return (...args) => {
        const key = JSON.stringify(args);

        if (!(key in cachedResults)) {
            const result = func.apply(null, args);
            cachedResults[key] = result;
        }

        return cachedResults[key];
    };
    
}

//=============================================
// ------------------------------------ TASK №2
//=============================================
const forwardBackwardSteps = {
    
    step: 0,
    forward(){
        this.step++;
        return this;
    },
    backward(){
        this.step--;
        return this;
    },
    revealStep(){
        console.log(this.step);
        return this;
    }
};

//=============================================
// ------------------------------------ TASK №3
//=============================================
const applyAll = (func, ...values) => {

    return func(...values);
    

}
const sum = (...args) => {
    return args.reduce((acc, val) => acc + val);
}

const mul = (...args) => {
    return args.reduce((acc, val) => acc * val);
}

//=============================================

module.exports = {cache, forwardBackwardSteps, applyAll, sum, mul}
