// Como podemos rodar isso em um arquivo .ts sem causar erros? 
/*
let employee = {};
employee.code = 10;
employee.name = "John";
*/
/***********************************************************************/

// Respostas

/* Diferente do JavaScript, o TypeScript exige que as propriedades sejam 
criadas com valores, nesse caso declaração de tipos é opcional. */
var employee1: {
    code: 10,
    name: 'John'
}


/* Caso não defina os valores inicialmente, no mínimo é necessário efetuar
a tipagem */
var employee2: {
    code: Number,
    name: string
}

employee2 = {
    code: 10,
    name: 'John'
}


/* Alternativa utiliazndo interface */
interface Funcionario {
    code: number,
    name: string
}

let functionario3: Funcionario = {
    code: 10,
    name: 'John'
}


/* Outra alternativa utiliazndo a interface */
const funcionarioObj = {} as Funcionario;
funcionarioObj.code = 10;
funcionarioObj.name = 'João';


