import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; //Add

import { AppComponent } from './app.component';
import { CourseListComponent } from './courses/course-list.component'; //Import do componente
import { StarComponent } from './star/star.component'; //Add Import
import { ReplacePipe } from './pipe/replace.pipe'; //Add Import

@NgModule({
  declarations: [
    AppComponent,
    CourseListComponent, //Informar (no modulo correspondente) para que possa ler o novo componente
    StarComponent, //Add novo componente
    ReplacePipe //Add
  ],
  imports: [
    BrowserModule,
    FormsModule //Add
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
