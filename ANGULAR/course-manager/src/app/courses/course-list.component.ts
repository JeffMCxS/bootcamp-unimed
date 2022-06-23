import { Component, OnInit } from "@angular/core"; // Define como Component, Add Import
import { Course } from './course'; //Add Import
import { CourseService } from "./course.service";

@Component({
    selector: 'app-course-list',
    //template: '<h2> Course List </h2>'
    templateUrl: './course-list.component.html' //Template em arquivo externo
})
export class CourseListComponent implements OnInit { //Add OnInit

    courses: Course[] = [];

    constructor(private courseService: CourseService) {}

    ngOnInit(): void { //Chama o método OnInit
        this.courses = this.courseService.retrieveAll();

    }

set filter(value: string) {

}






}
