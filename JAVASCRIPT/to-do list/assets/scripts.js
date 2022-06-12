const btn_submit = document.querySelector("#send");
const lista = document.getElementById('lista');
var inputTarefa = document.getElementById('input-tarefa');

btn_submit.addEventListener("click", function(e) {
    
    e.preventDefault();

    var getTarefa = document.querySelector("#input-tarefa");

    ///var armazena = document.getElementById("resultado");

    adiciona(getTarefa.value);

    inputTarefa.value ='';

    


})

function adiciona(conteudo) {

    const div_tarefa = document.createElement('div');
	const cb_tarefa = document.createElement('input');
	const content_tarefa = document.createElement('label');
	const conteudo_tarefa = document.createTextNode(conteudo);

	cb_tarefa.setAttribute('type', 'checkbox');
	cb_tarefa.setAttribute('name', conteudo);
	cb_tarefa.setAttribute('id', conteudo);

	content_tarefa.setAttribute('for', conteudo);
	content_tarefa.appendChild(conteudo_tarefa);

	div_tarefa.classList.add('itens');
	div_tarefa.appendChild(cb_tarefa);
	div_tarefa.appendChild(content_tarefa);

	lista.appendChild(div_tarefa);
}



