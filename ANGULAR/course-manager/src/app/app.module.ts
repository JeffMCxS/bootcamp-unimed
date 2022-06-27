import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router'; //Add modulod e rotas

import { HttpClientModule } from '@angular/common/http'; //

import { AppComponent } from './app.component';
//import { NavBarComponent } from './core/component/nav-bar/nav-bar.component';
//import { Error404Component } from './core/component/error-404/error-404.component'; //Add Import
import { CourseModule } from './courses/course.module';
import { CoreModule } from './core/core.module';

@NgModule({
  declarations: [
    AppComponent,
    //NavBarComponent, //Realocado para core após utilizar segregaçao em modulos
    //Error404Component, //Realocado para core após utilizar segregaçao em modulos
  ],
  imports: [
    BrowserModule,
    HttpClientModule, //
    CourseModule, //Add
    CoreModule, //Importado após utilizar segregacao em core
    RouterModule.forRoot([ //carrega as rotas assim que inicializar

        //Rotas Padroes
        {
            path: '', redirectTo: 'courses', pathMatch: 'full'
            //Path em branco se refere ao path raiz
        },

        /*{
            path: '**', component: Error404Component
            //** Rota para caminhos não existentes (erro 404)
            //Rota realocada apos utilizar segregacao em core
        },*/
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
