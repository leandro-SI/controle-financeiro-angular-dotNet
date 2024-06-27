import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListarCategoriasComponent } from './components/Categoria/listar-categorias/listar-categorias.component';
import { NovaCategoriaComponent } from './components/Categoria/nova-categoria/nova-categoria.component';
import { EditarCategoriaComponent } from './components/Categoria/editar-categoria/editar-categoria.component';
import { ListarFuncoesComponent } from './components/Funcao/listar-funcoes/listar-funcoes.component';
import { NovaFuncaoComponent } from './components/Funcao/nova-funcao/nova-funcao.component';
import { EditarFuncaoComponent } from './components/Funcao/editar-funcao/editar-funcao.component';
import { RegisterUsuarioComponent } from './components/Usuario/register-usuario/register-usuario.component';
import { LoginUsuarioComponent } from './components/Usuario/login-usuario/login-usuario.component';
import { DashboardComponent } from './components/Dashboard/dashboard/dashboard.component';
import { AuthGuardService } from './services/auth/auth-guard.service';
import { NovoCartaoComponent } from './components/Cartao/novo-cartao/novo-cartao.component';
import { ListarCartoesComponent } from './components/Cartao/listar-cartoes/listar-cartoes.component';
import { EditarCartaoComponent } from './components/Cartao/editar-cartao/editar-cartao.component';
import { NovaDespesaComponent } from './components/Despesa/nova-despesa/nova-despesa.component';
import { ListarDespesasComponent } from './components/Despesa/listar-despesas/listar-despesas.component';


const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    canActivate: [AuthGuardService],
    children: [
      {
        path: 'categorias/listar', component: ListarCategoriasComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'categorias/nova', component: NovaCategoriaComponent
      },
      {
        path: 'categorias/editar/:id', component: EditarCategoriaComponent
      },
      {
        path: 'funcoes/listar', component: ListarFuncoesComponent
      },
      {
        path: 'funcoes/nova', component: NovaFuncaoComponent
      },
      {
        path: 'funcoes/editar/:id', component: EditarFuncaoComponent
      },
      {
        path: 'cartoes/novo', component: NovoCartaoComponent
      },
      {
        path: 'cartoes/listar', component: ListarCartoesComponent
      },
      {
        path: 'cartoes/editar/:id', component: EditarCartaoComponent
      },
      {
        path: 'despesas/nova', component: NovaDespesaComponent
      },
      {
        path: 'despesas/listar', component: ListarDespesasComponent
      },
    ]
  },
  {
    path: 'usuarios/registrar', component: RegisterUsuarioComponent
  },
  {
    path: 'usuarios/login', component: LoginUsuarioComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
