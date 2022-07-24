/*
// O código abaixo tem alguns erros e não funciona como deveria. Você pode identificar quais são e corrigi-los em um arquivo TS?

let botaoAtualizar = document.getElementById('atualizar-saldo');
let botaoLimpar = document.getElementById('limpar-saldo');
let soma = document.getElementById('soma');
let campoSaldo = document.getElementById('campo-saldo');

campoSaldo.innerHTML = 0

function somarAoSaldo(soma) {
    campoSaldo.innerHTML += soma;
}

function limparSaldo() {
    campoSaldo.innerHTML = '';
}

botaoAtualizar.addEventListener('click', function () {
    somarAoSaldo(soma.value);
});

botaoLimpar.addEventListener('click', function () {
    limparSaldo();
});
*/
/**
    <h4>Valor a ser adicionado: <input id="soma"> </h4>
    <button id="atualizar-saldo">Atualizar saldo</button>
    <button id="limpar-saldo">Limpar seu saldo</button>
    <h1>"Seu saldo é: " <span id="campo-saldo"></span></h1>
 */

/***********************************************************************/


// Respostas

/* Primeira parte, solucionando o problema de código em JS */
/*
let botaoAtualizar = document.getElementById('atualizar-saldo');
let botaoLimpar = document.getElementById('limpar-saldo');
let soma = document.getElementById('soma');
let campoSaldo = document.getElementById('campo-saldo');

campoSaldo.innerHTML = 0

function somarAoSaldo(soma) {
    campoSaldo.innerHTML = Number(campoSaldo.innerHTML) + Number(soma);
}

function limparSaldo() {
    campoSaldo.innerHTML = '';
}

botaoAtualizar.addEventListener('click', function () {
    somarAoSaldo(soma.value);
});

botaoLimpar.addEventListener('click', function () {
    limparSaldo();
});
*/
/***********************************************************************/

/* Segunda parte, adaptando o código para funcionar em TS */

/* Uma solução mais indicada do que adicionar varios ifs para efetuar
as verificações, seria utilizar ! nos document.getElementById(),
desde que se tenha certeza que o campo exista */

let botaoAtualizar = document.getElementById('atualizar-saldo');
let botaoLimpar = document.getElementById('limpar-saldo');
let soma = document.getElementById('soma') as HTMLInputElement;
let campoSaldo = document.getElementById('campo-saldo');

if (campoSaldo) {
    campoSaldo.innerHTML = "0"
}

function somarAoSaldo(soma: string) {
    if (campoSaldo) {
        campoSaldo.innerHTML = (Number(campoSaldo.innerHTML) + Number(soma)).toString();
    }
}

function limparSaldo() {
    if (campoSaldo) {
        campoSaldo.innerHTML = '';
    }
}

if(botaoAtualizar){
    botaoAtualizar.addEventListener('click', function () {
        if (soma){
            somarAoSaldo(soma.value.toString())
        }
    })
}

if(botaoLimpar){
    botaoLimpar.addEventListener('click', function () {
        limparSaldo();

    })
}

/***********************************************************************/

// Resposta do professor

/*
export {} // Para não reclamar de variáveis duplicadas
 
    //Em todos os casos abaixo de uso do getElementById(), o elemento é potencialmente nulo e ifs são necessários para garantir que seu código vai funcionar da melhor forma.
    //No entanto, vão existir situações em que o desenvolvedor vai ter certeza de que o campo está lá e ele pode escrever o código da seguinte maneira:
        //document.getElementById('limpar-saldo')!;
    //A exclamação no fim é um sinal de que aquele campo não é nulo e que essa função realmente vai trazer algo. Assim, os ifs não são necessários.
    //Como exemplo, vou seguir essa metodologia no campo 'botaoLimpar'.

let botaoAtualizar = document.getElementById('atualizar-saldo');
let botaoLimpar = document.getElementById('limpar-saldo')!;
let soma = document.getElementById('soma')! as HTMLInputElement;
let campoSaldo = document.getElementById('campo-saldo');

let saldoTotal = 0

limparSaldo()

function somarAoSaldo(soma: number) {
    if (campoSaldo) {
        saldoTotal += soma
        campoSaldo.innerHTML = saldoTotal.toString();
        limparCampoSoma();
    }
}

function limparCampoSoma() {
    soma.value = "";
}

function limparSaldo() {
    if (campoSaldo) {
        saldoTotal = 0;
        campoSaldo.innerHTML = saldoTotal.toString();
    }
}

if (botaoAtualizar) {
    botaoAtualizar.addEventListener('click', () => {
        somarAoSaldo(Number(soma.value)); 
    });
}
botaoLimpar.addEventListener('click', () => { // Percebam que aqui o typescript não acusou o botao de ser nulo e não precisei do if. Caso queiram fazer o teste, retirem a exclamação.
    limparSaldo();
});
*/