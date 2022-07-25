import { Injectable } from "@angular/core";
import { Usuario } from "./usuario";

@Injectable({
  providedIn: 'root'
})
export class cadastroService {

  retrieveAll(): Usuario[] {
    return USUARIOS;
  }

}

var USUARIOS: Usuario[] = [
  {
      id: 1,
      nome: 'Luana Cordeiro',
      email: 'luana.tech@email.com',
      contatoSecundario: '(21) 4002-8922',
      //dataCadastro: 'November 2, 2019',
      dataCadastro: 'November 2, 2017 03:24:00',
      imagemUrl: '/assets/images/f1.jpg',
  },
  {
      id: 2,
      nome: 'Giovany Ramalho',
      email: 'gio.vany@email.com',
      contatoSecundario: '',
      dataCadastro: 'December 6, 2019 13:14:00',
      imagemUrl: '0',
  },
  {
      id: 3,
      nome: 'Heitor Macena',
      email: 'heitor.macena@techcorp.com',
      contatoSecundario: 'heitor.mcn@email.com',
      dataCadastro: 'January 12, 2020 07:03:00',
      imagemUrl: '0',
  },
  {
      id: 4,
      nome: 'Liliana Godinho',
      email: 'godinho.liliana@email',
      contatoSecundario: '',
      dataCadastro: 'February 22, 2020 18:34:00',
      imagemUrl: '0',
  },
  {
      id: 5,
      nome: 'Cristina Damasceno',
      email: 'crisdama@email.com',
      contatoSecundario: '',
      dataCadastro: 'March 30, 2022 22:11:00',
      imagemUrl: '0',
  }
];

