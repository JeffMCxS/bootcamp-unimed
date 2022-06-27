import { NgModule } from "@angular/core";
import { NavBarComponent } from "./component/nav-bar/nav-bar.component";
import { RouterModule } from "@angular/router";
import { Error404Component } from "./component/error-404/error-404.component";


@NgModule({
    declarations: [
        NavBarComponent, //Removido do app.module.ts e adicionado aqui
        Error404Component //Removido do app.module.ts e adicionado aqui
    ],
    imports: [
        RouterModule.forChild([ //Importado pois o nav-bar utiliza routerLink
            {
                path: '**', component: Error404Component
                //** Rota para caminhos não existentes (erro 404)
                //Rota realocada de app.module.ts para aqui
            }
        ])
    ],
    exports: [
    /* Local para espeficar oque será exportado deste módulo
    para ser utilizado no módulo em que ele está sendo importado */
        NavBarComponent
    ]

})

export class CoreModule {

}
