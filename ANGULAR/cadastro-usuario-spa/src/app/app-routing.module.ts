import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrosComponent } from './cadastros/cadastros.component';

const routes: Routes = [
  {
    path: '', component: CadastrosComponent

  },
  /*
  {
    path: 'cadastros', component: CadastrosComponent
  },
  {
    path: 'courses/info/:id', component: CourseInfoComponent
    //Essa rota recebe um caminho (url) e um parâmetro (id)
  },*/

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
