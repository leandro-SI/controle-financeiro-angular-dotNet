import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { GanhosService } from 'src/app/services/ganhos/ganhos.service';

@Component({
  selector: 'app-listar-ganhos',
  templateUrl: './listar-ganhos.component.html',
  styleUrls: ['./listar-ganhos.component.css']
})
export class ListarGanhosComponent implements OnInit {

  ganhos = new MatTableDataSource<any>();
  displayColumns: string[]
  autoCompleteInput = new FormControl();
  opcoesGanhos: string[] = [];
  usuarioId: string = localStorage.getItem('UsuarioId');
  nomesCategorias: Observable<string[]>;

  @ViewChild(MatPaginator, {static: true})
  paginator: MatPaginator;

  @ViewChild(MatSort, {static: true})
  sort: MatSort;

  constructor(private ganhoService: GanhosService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {

    this.ganhoService.getByUserId(this.usuarioId).subscribe(result => {
      result.forEach((c) => {
        this.opcoesGanhos.push(c.categoria.nome);
      });

      this.ganhos.data = result;
      this.ganhos.paginator = this.paginator;
      this.ganhos.sort = this.sort;
    });

    this.displayColumns = this.ExibirColunas();

    this.nomesCategorias = this.autoCompleteInput.valueChanges.pipe(startWith(''), map(descricao => this.FiltrarDespesasCategoria(descricao)))
  }

  ExibirColunas() : string[] {
    return ['descricao', 'categoria', 'valor', 'data', 'acoes']
  }

  AbrirDialog(ganhoId, valor): void {

  }

  FiltrarDespesasCategoria(nomeCategoria: string) : string[] {
    if (nomeCategoria.trim().length >= 4) {
      this.ganhoService.filtrar(nomeCategoria).subscribe(result => {
        this.ganhos.data = result;
      })
    } else {
      if (nomeCategoria === '') {
        this.ganhoService.getByUserId(this.usuarioId).subscribe(result => {
          this.ganhos.data = result
        })
      }
    }

    return this.opcoesGanhos.filter(despesa =>
      despesa.toLowerCase().includes(nomeCategoria.toLowerCase())
    )
  }

}
