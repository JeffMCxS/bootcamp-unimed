"use strict";
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
/* Criar um conjunto de constantes para as profissões, uma vez que serão
valores fixos */
var Profissao;
(function (Profissao) {
    Profissao[Profissao["Desenvolvedor"] = 0] = "Desenvolvedor";
    Profissao[Profissao["Analista"] = 1] = "Analista";
    Profissao[Profissao["Desempregado"] = 2] = "Desempregado";
})(Profissao || (Profissao = {}));
let pessoa11 = {
    nome: "maria",
    idade: 29,
    profissao: Profissao.Analista
};
let pessoa22 = {
    nome: "roberto",
    idade: 19,
    profissao: Profissao.Desempregado
};
let pessoa33 = {
    nome: "laura",
    idade: 32,
    profissao: Profissao.Desenvolvedor
};
