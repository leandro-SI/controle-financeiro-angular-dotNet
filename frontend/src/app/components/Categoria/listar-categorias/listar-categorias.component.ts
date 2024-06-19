import { Component, OnInit, ViewChild } from '@angular/core';
import { CategoriasService } from './../../../services/categorias/categorias.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { DialogExclusaoCategoriaComponent } from '../dialog-exclusao-categoria/dialog-exclusao-categoria.component';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-listar-categorias',
  templateUrl: './listar-categorias.component.html',
  styleUrls: ['./listar-categorias.component.scss']
})
export class ListarCategoriasComponent implements OnInit {

  categorias = new MatTableDataSource<any>();
  displayColumns: string[]
  autoCompleteInput = new FormControl();
  opcoesCategorias: string[] = [];
  nomesCategorias: Observable<string[]>;

  @ViewChild(MatPaginator, {static: true})
  paginator: MatPaginator;

  @ViewChild(MatSort, {static: true})
  sort: MatSort;

  constructor(private categoriasService: CategoriasService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.categoriasService.getAll().subscribe(result => {
      result.forEach((c) => {
        this.opcoesCategorias.push(c.nome);
      });

      this.categorias.data = result;
      this.categorias.paginator = this.paginator;
      this.categorias.sort = this.sort;
    });

    this.displayColumns = this.ExibirColunas();

    this.nomesCategorias = this.autoCompleteInput.valueChanges.pipe(startWith(''), map(nome => this.FiltrarNomes(nome)))
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

  FiltrarNomes(nome: string) : string[] {
    if (nome.trim().length >= 4) {
      this.categoriasService.filtrar(nome).subscribe(result => {
        this.categorias.data = result;
      })
    } else {
      if (nome === '') {
        this.categoriasService.getAll().subscribe(result => {
          this.categorias.data = result
        })
      }
    }

    return this.opcoesCategorias.filter(categoria =>
      categoria.toLowerCase().includes(nome.toLowerCase())
    )
  }

}
