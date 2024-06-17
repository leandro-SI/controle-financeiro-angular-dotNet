import { Component, OnInit } from '@angular/core';
import { CategoriasService } from './../../../services/categorias/categorias.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { DialogExclusaoCategoriaComponent } from '../dialog-exclusao-categoria/dialog-exclusao-categoria.component';

@Component({
  selector: 'app-listar-categorias',
  templateUrl: './listar-categorias.component.html',
  styleUrls: ['./listar-categorias.component.scss']
})
export class ListarCategoriasComponent implements OnInit {

  categorias = new MatTableDataSource<any>();
  //dataSource = new MatTableDataSource();
  displayColumns: string[]

  constructor(private categoriasService: CategoriasService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.categoriasService.getAll().subscribe(result => {
      this.categorias.data = result;
    });

    this.displayColumns = this.ExibirColunas();
  }

  ExibirColunas() : string[] {
    return ['nome', 'icone', 'tipo', 'acoes']
  }

  AbrirDialog(categoriaId, nome): void {
    this.dialog.open(DialogExclusaoCategoriaComponent, {
      data: {
        id: categoriaId,
        nome: nome
      }
    }).afterClosed().subscribe(result => {
      if (result == true) {
        this.categoriasService.getAll().subscribe(dados => {
          this.categorias.data = dados;
        })
      }
      this.displayColumns = this.ExibirColunas();
    })
  }

}
