import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; //Add
import { RouterModule } from '@angular/router'; //Add modulod e rotas

import { HttpClientModule } from '@angular/common/http'; //

import { AppComponent } from './app.component';
import { CourseListComponent } from './courses/course-list.component'; //Import do componente
import { StarComponent } from './star/star.component'; //Add Import
import { ReplacePipe } from './pipe/replace.pipe'; //Add Import
import { NavBarComponent } from './nav-bar/nav-bar.component'; //Add Import
import { Error404Component } from './error-404/error-404.component'; //Add Import
import { CourseInfoComponent } from './courses/course-info.component'; //Add Import

@NgModule({
  declarations: [
    AppComponent,
    CourseListComponent, //Informar (no modulo correspondente) para que possa ler o novo componente
    StarComponent, //Add novo componente
    ReplacePipe, //Add
    NavBarComponent, //Add
    Error404Component, //Add
    CourseInfoComponent //Add
  ],
  imports: [
    BrowserModule,
    FormsModule, //Add
    HttpClientModule, //
    RouterModule.forRoot([ //carrega as rotas assim que inicializar
        {
            path: 'courses', component: CourseListComponent
        },
        {
            path: 'courses/info/:id', component: CourseInfoComponent
            //Essa rota recebe um caminho (url) e um parâmetro (id)
        },


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
