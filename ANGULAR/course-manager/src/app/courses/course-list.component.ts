import { Component, OnInit } from "@angular/core"; // Define como Component, Add Import
import { Course } from './course'; //Add Import
import { CourseService } from "./course.service";

@Component({
    //selector: 'app-course-list', //Utilizando link de rotas agora ao invés de selector
    //Removido pois o selector exibe o component via Tags. O novo via Trigg de rotas

    //template: '<h2> Course List </h2>'
    templateUrl: './course-list.component.html' //Template em arquivo externo
})
export class CourseListComponent implements OnInit { //Add OnInit

    filteredCourses: Course[] = [];

    _courses: Course[] = [];

    _filterBy: string;

    constructor(private courseService: CourseService) { }

    ngOnInit(): void { //Método OnInit
        this.retrieveAll();
    }

    retrieveAll(): void {
        this.courseService.retrieveAll().subscribe({
        //subscribe está sobrescrevendo o contrato e chamando a requisição do contrato
            next: courses => { //courses é o retorno envelopado do httpClient.get
                this._courses = courses;
                this.filteredCourses = this._courses;
            },
            error: err => console.log('Error', err)
            //Tratação em caso de erro
        })

    }

set filter(value: string) {
    this._filterBy = value;

    this.filteredCourses = this._courses.filter((course: Course) => course.name.toLocaleLowerCase().indexOf(this._filterBy.toLocaleLowerCase()) > -1);

}

get filter() {
  return this._filterBy;
}






}
