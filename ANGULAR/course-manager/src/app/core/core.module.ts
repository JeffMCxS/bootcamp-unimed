import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { NavBarComponent } from "./component/nav-bar/nav-bar.component";

@NgModule({
    declarations: [
        NavBarComponent //Removido do app.module.ts e adicionado aqui
    ],
    imports: [
        RouterModule //Importado pois o nav-bar utiliza routerLink
    ],
    exports: [
    /* Local para espeficar oque será exportado deste módulo
    para ser utilizado no módulo em que ele está sendo importado */
        NavBarComponent
    ]

})

export class CoreModule {

}
