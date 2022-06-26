import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
//import { FormsModule } from '@angular/forms'; //Removido
import { RouterModule } from '@angular/router'; //Add modulod e rotas

import { HttpClientModule } from '@angular/common/http'; //

import { AppComponent } from './app.component';
//import { CourseListComponent } from './courses/course-list.component';
//import { StarComponent } from './star/star.component';
//import { ReplacePipe } from './pipe/replace.pipe'; //Add Import
import { NavBarComponent } from './nav-bar/nav-bar.component'; //Add Import
import { Error404Component } from './error-404/error-404.component'; //Add Import
//import { CourseInfoComponent } from './courses/course-info.component';
import { CourseModule } from './courses/course.module';

@NgModule({
  declarations: [
    AppComponent,
    //CourseListComponent, //Informar (no modulo correspondente) para que possa ler o novo componente
        //Realocado após utilizar segregaçao em modulos
    //StarComponent, //Realocado após utilizar segregaçao em modulos
    //ReplacePipe, //Realocado após utilizar segregaçao em modulos
    NavBarComponent, //Add
    Error404Component, //Add
    //CourseInfoComponent //Realocado após utilizar segregaçao em modulos
  ],
  imports: [
    BrowserModule,
    //FormsModule, //Removido após utilizar segregaçao em modulos
    HttpClientModule, //
    CourseModule, //Add
    RouterModule.forRoot([ //carrega as rotas assim que inicializar

        //Rotas Padroes
        {
            path: '', redirectTo: 'courses', pathMatch: 'full'
            //Path em branco se refere ao path raiz
        },
        {
            path: '**', component: Error404Component
            //** Rota para caminhos não existentes (erro 404)
        },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
