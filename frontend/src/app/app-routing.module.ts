import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListarCategoriasComponent } from './components/Categoria/listar-categorias/listar-categorias.component';
import { NovaCategoriaComponent } from './components/Categoria/nova-categoria/nova-categoria.component';
import { EditarCategoriaComponent } from './components/Categoria/editar-categoria/editar-categoria.component';
import { ListarFuncoesComponent } from './components/Funcao/listar-funcoes/listar-funcoes.component';


const routes: Routes = [
  {
    path: 'categorias/listar', component: ListarCategoriasComponent
  },
  {
    path: 'categorias/nova', component: NovaCategoriaComponent
  },
  {
    path: 'categorias/editar/:id', component: EditarCategoriaComponent
  },
  {
    path: 'funcoes/listar', component: ListarFuncoesComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
