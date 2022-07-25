//Anotações TypeScript


//Criando tipos
type input = number | string;

function somarValores(input1: input, input2: input) {
    if (typeof input1 === 'string' || typeof input2 === 'string') {
        return input1.toString() + input2.toString();
    } else {
        return input1 + input2;
    }
}
//--------------------------------------------------------

/* O tipo any permite que uma variável receba qualquer tipo */
let valorAny: any;
valorAny = 3;
valorAny = 'ola';
valorAny = true;

/* Inclusive permite ser passada como valor para uma
variável de apenas um tipo específico */
let valorString: string = 'teste';
valorString = valorAny
//--------------------------------------------------------

//Conjunto de constantes
enum Profissao {
    Professora,
    Atriz,
    Desenvolvedora,
    JogadoraDeFutebol
}

interface Pessoa {
    nome: string,
    idade: number,
    profissao?: Profissao // ? Parâmetro na obrigatório
}

const vanessa: Pessoa = {
    nome: 'Vanessa',
    idade: 23,
    profissao: Profissao.Desenvolvedora
}
//--------------------------------------------------------

// Defina tipo de retorno da função após o ():
function somarValoresNumericos(numero1: number, numero2: number): number {
    return numero1 + numero2;
}

console.log(somarValoresNumericos(1, 3));

/* Console.log é um tipo de função que não tem retorno pro
código */
function printarValoresNumericos(numero1: number, numero2: number): void {
    console.log(numero1 + numero2);
}
//--------------------------------------------------------

//Usar callback para entregar resultados dinâmicos
function somarValoresNumericosETratar(numero1: number, numero2: number, callback: (numero: number) => number): number {
    let resultado = numero1 + numero2;
    return callback(resultado);
}

function aoQuadrado(numero: number): number {
    return numero * numero;
}

function dividirPorEleMesmo(numero: number): number {
    return numero / numero;
}

console.log(somarValoresNumericosETratar(1, 3, aoQuadrado)) // 16
console.log(somarValoresNumericosETratar(1, 3, dividirPorEleMesmo)) //1
//--------------------------------------------------------

// Unknown

let valorUnknown: unknown;
valorUnknown = 3;
valorUnknown = 'ola';

let valorString2: string = 'teste';

// Isso não funciona igual ao Any
//valorString2 = valorUnknown 

if(typeof valorUnknown === 'string') {
    // Primeiro é necessário fazer uma verificação de tipo
    valorString2 = valorUnknown;
}
//--------------------------------------------------------

// Never
/* É utilizado em um código que nunca termina ou que nunca
será finalizado, ex: um loop infinito ou nesse caso com
throw que causou um interrupção */

function jogaErro(erro: string, codigo: number): never {
    throw {error: erro, code: codigo}
}

jogaErro('deu erro', 500)
//--------------------------------------------------------

let buttonTeste = document.getElementById('button');

/* Button não funcionaria pois ainda não foi verificado,
porem existe uma alternativa utilizando o ?
Ele verifica se existe, e se sim, ele continua */

//buttonTeste.addEventListener('click', () => {
buttonTeste?.addEventListener('click', () => {
    console.log('funcionou')
})

//--------------------------------------------------------
//--------------------------------------------------------