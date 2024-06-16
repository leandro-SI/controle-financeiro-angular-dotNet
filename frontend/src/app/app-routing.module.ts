import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListarCategoriasComponent } from './components/Categoria/listar-categorias/listar-categorias.component';
import { NovaCategoriaComponent } from './components/Categoria/nova-categoria/nova-categoria.component';


const routes: Routes = [
  {
    path: 'categorias/listar', component: ListarCategoriasComponent
  },
  {
    path: 'categorias/nova', component: NovaCategoriaComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
