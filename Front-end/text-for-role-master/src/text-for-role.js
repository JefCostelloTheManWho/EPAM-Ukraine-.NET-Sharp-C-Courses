const textForRole = (roles, textLines) => {

    let result = '';
    for(let role = 0; role < roles.length; role++) {
        let replic = ``;
        let roleStr = `${roles[role]}:`;
    textLines.split('\n').forEach(text => {
        let index =  textLines.split('\n').indexOf(text);
        if(roleStr == text.substring(0, text.indexOf(':') + 1)) {
            replic += '\n' + `${index+1})` + text.substring(text.length, text.indexOf(':')+1);
        }
    });
    roleStr += replic;
    if(role != roles.length-1) {
        result += roleStr + '\n' + '\n';
    }else{
        result += roleStr;
    }
    replic = '';
}
   return result;
}

module.exports = textForRole;

