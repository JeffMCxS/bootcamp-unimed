import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core"; //Definir essa classe como elegivel a modulo
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { ReplacePipe } from "../pipe/replace.pipe";
import { StarComponent } from "../star/star.component";
import { CourseInfoComponent } from "./course-info.component";
import { CourseListComponent } from "./course-list.component";

@NgModule({ //Definir essa classe como elegivel a modulo
    declarations: [
        //Aqui é informado pipes, components...
        CourseListComponent,
        CourseInfoComponent,
        ReplacePipe,
        StarComponent
    ], imports: [
        //Aqui é informado os imports de modulos...
        CommonModule, /* Conjunto de recursos básicos do Angular,
        No app.module já vem por padrão, em modulos novos precisa ser importado */
        FormsModule,
        RouterModule.forChild([
            //Rotas retiradas do app.module.ts e adicionadas aqui
            {
                path: 'courses', component: CourseListComponent
            },
            {
                path: 'courses/info/:id', component: CourseInfoComponent
                //Essa rota recebe um caminho (url) e um parâmetro (id)
            },
        ])
    ]
})
export class CourseModule {

}
