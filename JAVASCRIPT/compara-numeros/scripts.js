function comparaNumeros(num1, num2) {
    
    saoIguais = (num1 === num2) ? "são" : "não são";
    return `Os números ${num1} e ${num2} ${saoIguais} iguais.`

    //return (num1 === num2) ? true : false;
}

function comparaSoma(num1, num2) {
    var soma = num1 + num2;
    maior10 = (soma > 10) ? "maior" : "menor";
    maior20 = (soma > 20) ? "maior" : "menor";

    return  `Sua soma é ${soma}, que é ${maior10} que 10 e ${maior20} que 20.`;
}
function resultado(num1, num2) {

    console.log(comparaNumeros(num1, num2) + " " + comparaSoma(num1, num2));  
}

resultado(10, 2);