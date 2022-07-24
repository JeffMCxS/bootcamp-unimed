// Como podemos melhorar o esse código usando TS? 
/*
let pessoa1 = {};
pessoa1.nome = "maria";
pessoa1.idade = 29;
pessoa1.profissao = "atriz"

let pessoa2 = {}
pessoa2.nome = "roberto";
pessoa2.idade = 19;
pessoa2.profissao = "Padeiro";

let pessoa3 = {
    nome: "laura",
    idade: "32",
    profissao: "Atriz"
};

let pessoa4 = {
    nome = "carlos",
    idade = 19,
    profissao = "padeiro"
}
*/
/***********************************************************************/

// Respostas

//Agrupar os atributos utilizando uma interface genéricos
interface Pessoa { //ou type Pessoa {
    nome: string,
    idade: Number,
    profissao: Profissao
}

/* Criar um conjunto de constantes para as profissões, uma vez que serão
valores fixos */
enum Profissao {
    Desenvolvedor,
    Analista,
    Desempregado
}

let pessoa11: Pessoa = {
    nome: "maria",
    idade:  29,
    profissao: Profissao.Analista
};

let pessoa22: Pessoa = {
    nome: "roberto",
    idade: 19,
    profissao: Profissao.Desempregado
};

let pessoa33: Pessoa = {
    nome: "laura",
    idade: 32,
    profissao: Profissao.Desenvolvedor
};