import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

//Pipes
import { MoedaPipe } from './custom-pipe/Moeda/moeda.pipe';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDividerModule } from '@angular/material/divider';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDialogModule } from '@angular/material/dialog';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NgxMaskModule } from 'ngx-mask';
import { JwtModule } from '@auth0/angular-jwt';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';


//services
import { TiposService } from './services/tipos/tipos.service';
import { CategoriasService } from './services/categorias/categorias.service';
import { FuncoesService } from './services/funcoes/funcoes.service';
import { UsuariosService } from './services/usuarios/Usuarios.service';
import { AuthGuardService } from './services/auth/auth-guard.service';
import { CartoesService } from './services/cartoes/cartoes.service';
import { MesesService } from './services/meses/mes.service';
import { DespesasService } from './services/despesas/despesas.service';
import { GanhosService } from './services/ganhos/ganhos.service';
import { DashboardService } from './services/dashboard/dashboard.service';


//componentes
import { ListarCategoriasComponent } from './components/Categoria/listar-categorias/listar-categorias.component';
import { NovaCategoriaComponent } from './components/Categoria/nova-categoria/nova-categoria.component';
import { EditarCategoriaComponent } from './components/Categoria/editar-categoria/editar-categoria.component';
import { DialogExclusaoCategoriaComponent } from './components/Categoria/dialog-exclusao-categoria/dialog-exclusao-categoria.component';
import { ListarFuncoesComponent } from './components/Funcao/listar-funcoes/listar-funcoes.component';
import { NovaFuncaoComponent } from './components/Funcao/nova-funcao/nova-funcao.component';
import { EditarFuncaoComponent } from './components/Funcao/editar-funcao/editar-funcao.component';
import { DialogExcluirFuncaoComponent } from './components/Funcao/dialog-excluir-funcao/dialog-excluir-funcao.component';
import { RegisterUsuarioComponent } from './components/Usuario/register-usuario/register-usuario.component';
import { LoginUsuarioComponent } from './components/Usuario/login-usuario/login-usuario.component';
import { environment } from 'src/environments/environment';
import { DashboardComponent } from './components/Dashboard/dashboard/dashboard.component';
import { HeaderComponent } from './components/Dashboard/header/header.component';
import { NovoCartaoComponent } from './components/Cartao/novo-cartao/novo-cartao.component';
import { ListarCartoesComponent } from './components/Cartao/listar-cartoes/listar-cartoes.component';
import { EditarCartaoComponent } from './components/Cartao/editar-cartao/editar-cartao.component';
import { DialogDeleteCartaoComponent } from './components/Cartao/dialog-delete-cartao/dialog-delete-cartao.component';
import { NovaDespesaComponent } from './components/Despesa/nova-despesa/nova-despesa.component';
import { ListarDespesasComponent } from './components/Despesa/listar-despesas/listar-despesas.component';
import { EditarDespesaComponent } from './components/Despesa/editar-despesa/editar-despesa.component';
import { DialogDeleteDespesaComponent } from './components/Despesa/dialog-delete-despesa/dialog-delete-despesa.component';
import { NovoGanhoComponent } from './components/Ganho/novo-ganho/novo-ganho.component';
import { ListarGanhosComponent } from './components/Ganho/listar-ganhos/listar-ganhos.component';
import { EditarGanhoComponent } from './components/Ganho/editar-ganho/editar-ganho.component';
import { DialogDeleteGanhoComponent } from './components/Ganho/dialog-delete-ganho/dialog-delete-ganho.component';
import { EditarUsuarioComponent } from './components/Usuario/editar-usuario/editar-usuario.component';
import { IndexComponent } from './components/Dashboard/index/index.component';


export function GetTokenUser() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    MoedaPipe,
    ListarCategoriasComponent,
    NovaCategoriaComponent,
    EditarCategoriaComponent,
    DialogExclusaoCategoriaComponent,
    ListarFuncoesComponent,
    NovaFuncaoComponent,
    EditarFuncaoComponent,
    DialogExcluirFuncaoComponent,
    RegisterUsuarioComponent,
    LoginUsuarioComponent,
    DashboardComponent,
    HeaderComponent,
    NovoCartaoComponent,
    ListarCartoesComponent,
    EditarCartaoComponent,
    DialogDeleteCartaoComponent,
    NovaDespesaComponent,
    ListarDespesasComponent,
    EditarDespesaComponent,
    DialogDeleteDespesaComponent,
    NovoGanhoComponent,
    ListarGanhosComponent,
    EditarGanhoComponent,
    DialogDeleteGanhoComponent,
    EditarUsuarioComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatDividerModule,
    MatSelectModule,
    MatOptionModule,
    MatGridListModule,
    MatDialogModule,
    MatAutocompleteModule,
    MatPaginatorModule,
    MatSortModule,
    MatSnackBarModule,
    MatProgressBarModule,
    FlexLayoutModule,
    MatSidenavModule,
    MatListModule,
    MatToolbarModule,
    FormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: function  tokenGetter() {
          return localStorage.getItem('token');
        },
        allowedDomains: [`${environment.applicationUrl}`],
        disallowedRoutes: []
      }
    }),
    NgxMaskModule.forRoot(),

  ],
  providers: [
    HttpClientModule,
    TiposService,
    CategoriasService,
    FuncoesService,
    UsuariosService,
    CartoesService,
    AuthGuardService,
    MesesService,
    DespesasService,
    GanhosService,
    DashboardService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
