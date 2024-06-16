import { Component, OnInit } from '@angular/core';
import { CategoriasService } from './../../../services/categorias/categorias.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-listar-categorias',
  templateUrl: './listar-categorias.component.html',
  styleUrls: ['./listar-categorias.component.scss']
})
export class ListarCategoriasComponent implements OnInit {

  categorias = new MatTableDataSource<any>();
  //dataSource = new MatTableDataSource();
  displayColumns: string[]

  constructor(private categoriasService: CategoriasService) { }

  ngOnInit() {
    this.categoriasService.getAll().subscribe(result => {
      this.categorias.data = result;
    });

    this.displayColumns = this.ExibirColunas();
  }

  ExibirColunas() : string[] {
    return ['nome', 'icone', 'tipo', 'acoes']
  }

}
