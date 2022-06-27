import { NgModule } from "@angular/core";
import { StarComponent } from "./star.component";

@NgModule({
    declarations: [
        StarComponent //Removido do course.module.ts e adicionado aqui
    ],
    exports: [ /* Local para espeficar oque será exportado deste módulo
    para ser utilizado no módulo em que ele está sendo importado */
        StarComponent
    ]

})
export class StarModule {

}
