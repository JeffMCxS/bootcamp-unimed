"use strict";
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
var employee1;
/* Caso não defina os valores inicialmente, no mínimo é necessário efetuar
a tipagem */
var employee2;
employee2 = {
    code: 10,
    name: 'John'
};
let functionario3 = {
    code: 10,
    name: 'John'
};
/* Outra alternativa utiliazndo a interface */
const funcionarioObj = {};
funcionarioObj.code = 10;
funcionarioObj.name = 'João';
