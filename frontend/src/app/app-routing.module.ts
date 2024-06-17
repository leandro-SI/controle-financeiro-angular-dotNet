import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListarCategoriasComponent } from './components/Categoria/listar-categorias/listar-categorias.component';
import { NovaCategoriaComponent } from './components/Categoria/nova-categoria/nova-categoria.component';
import { EditarCategoriaComponent } from './components/Categoria/editar-categoria/editar-categoria.component';


const routes: Routes = [
  {
    path: 'categorias/listar', component: ListarCategoriasComponent
  },
  {
    path: 'categorias/nova', component: NovaCategoriaComponent
  },
  {
    path: 'categorias/editar/:id', component: EditarCategoriaComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
