import { Component, OnInit } from '@angular/core';
import { Usuario } from './usuario';
import { cadastroService } from './usuario.service';

@Component({
  selector: 'cdussap-cadastros',
  templateUrl: './cadastros.component.html',
  styleUrls: ['./cadastros.component.css']
})
export class CadastrosComponent implements OnInit {

  usuarios: Usuario[] = [];
  filteredUsuarios: Usuario[] = [];
  filterBy: string;

  //_usuarios: Usuario[] = [];

  constructor(private cadastroService: cadastroService) {}

  ngOnInit(): void {
    this.usuarios = this.cadastroService.retrieveAll();

    this.filteredUsuarios = this.usuarios;
  }

  set filtro(valor: string) {
    this.filterBy = valor;

    this.filteredUsuarios = this.usuarios.filter((usuario: Usuario) => usuario.nome.toLocaleLowerCase().indexOf(this.filterBy.toLocaleLowerCase()) > -1);
  }

  get filtro() {
    return this.filterBy;
  }



}
