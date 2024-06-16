import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

//services
import { TiposService } from './services/tipos/tipos.service';
import { CategoriasService } from './services/categorias/categorias.service';
import { ListarCategoriasComponent } from './components/Categoria/listar-categorias/listar-categorias.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//componentes

@NgModule({
  declarations: [
    AppComponent,
    ListarCategoriasComponent,
  ],
  imports: [
  BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule
  ],
  providers: [
    TiposService,
    CategoriasService,
    HttpClientModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
