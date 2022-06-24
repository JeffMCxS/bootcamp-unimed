import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
    templateUrl: './course-info.component.html'
})

export class CourseInfoComponent implements OnInit{

    courseId: number;

    /* Ao Triggar uma URL, existirá uma rota ativa naquele momento,
    através dessa rota ativa é possível pegar uma série de informações */
    constructor (private activatedRoute: ActivatedRoute) { }

    ngOnInit(): void{
        //Tirando uma "foto" da rota ativa nesse momento
        this.courseId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
        //O 'id' se refere ao 'id' informado na pathrota do app.module

        //this.courseId = +this.activatedRoute.snapshot.paramMap.get('id');
        /* Por padrão a rota retornada é uma String. O + converte para number.
        Porem nesse caso específico gera erro pois o Angular supoe a
        possibilidade de haver um retorno nulo (null), impossibilitando a
        conversão. Nesse caso é utilizado o Number() */

    }

}
