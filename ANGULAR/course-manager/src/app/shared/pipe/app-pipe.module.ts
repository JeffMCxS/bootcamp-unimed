import { NgModule } from "@angular/core";
import { ReplacePipe } from "./replace.pipe";

@NgModule({
    declarations: [
        ReplacePipe //Removido do course.module.ts e adicionado aqui
    ],

    exports: [
    /* Local para espeficar oque será exportado deste módulo
    para ser utilizado no módulo em que ele está sendo importado */
        ReplacePipe
    ]
})

export class AppPipeModule {

}
