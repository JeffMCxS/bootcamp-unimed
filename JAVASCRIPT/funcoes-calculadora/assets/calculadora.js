function calculadora() {
    console.log("checkpoint");
    const operacao = Number(prompt('Escolha uma operação:\n 1 - Soma (+)\n 2 - Subtração (-)\n 3 - Multiplicação (*)\n 4 - Divisão Real (/)\n 5 - Divisão Inteira (%)\n 6 - Potenciação (**)'));
    //Number utilizado para transformar o input em numero, caso contrário o valor será iterpretado como texto e será concatenado.
    //Prompt utilizado para pegar input do usuário

    if(!operacao || operacao >= 7) {
        alert('Erro - operação inválida!');
        calculadora();
    } else {

        let n1 = Number(window.prompt('Insira o primeiro valor:'));
        let n2 = Number(prompt('Insira o segundo valor:'));
        let resultado;

        if (!n1 || !n2) {
            alert('Erro - parâmetros inválidos!')
            calculadora();
        } else {

            function soma() {
                resultado = n1 + n2;
                alert(`(${n1} + ${n2}) = ${resultado}`);
                novaOperacao();
            }
    
            //Restante das operações...
            //...
    
            function novaOperacao() {
                let opcao = prompt('Deseja fazer outra operação?\n 1 - Sim\n 2 - Não');
    
                if(opcao == 1){
                    calculadora();
                } else if (opcao == 2) {
                    alert('Até masi!');
                } else {
                    alert('Digite uma opção válida!');
                    novaOperacao();
                }
            }

        }
        /* Método com if

        if (operacao == 1) {
            soma();
        } else if (operacao == 2) {
            subtracao();
        } else if (operacao == 3) {
            multiplicacao();
        } else if (operacao == 4) {
            divisaoReal();
        } else if (operacao == 5) {
            divisaoInteira();
        } else if (operacao == 6) {
            potenciacao();
        }
        */

        /* Método com Switch Case */
        switch (operacao) {

            /*case operacao = 1 (com apenas 1 igual também é permitido) */
            case 1:
                soma();
                break;
            case 2:
                subtracao();
                break;
            case 3:
                multiplicacao();
                break;
            case 4:
                divisaoReal();
                break;
            case 5:
                divisaoInteira();
                break;
            case 6:
                potenciacao();
                break;
        }

    }

    
}

calculadora();
        
