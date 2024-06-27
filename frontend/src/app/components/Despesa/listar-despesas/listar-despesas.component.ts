import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { CartoesService } from 'src/app/services/cartoes/cartoes.service';
import { DespesasService } from 'src/app/services/despesas/despesas.service';
import { DialogDeleteDespesaComponent } from '../dialog-delete-despesa/dialog-delete-despesa.component';

@Component({
  selector: 'app-listar-despesas',
  templateUrl: './listar-despesas.component.html',
  styleUrls: ['./listar-despesas.component.scss']
})
export class ListarDespesasComponent implements OnInit {

  despesas = new MatTableDataSource<any>();
  displayColumns: string[]
  autoCompleteInput = new FormControl();
  opcoesDespesas: string[] = [];
  usuarioId: string = localStorage.getItem('UsuarioId');
  descricaoDespesas: Observable<string[]>;

  @ViewChild(MatPaginator, {static: true})
  paginator: MatPaginator;

  @ViewChild(MatSort, {static: true})
  sort: MatSort;

  constructor(private despesaService: DespesasService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {

    this.despesaService.getByUserId(this.usuarioId).subscribe(result => {
      result.forEach((c) => {
        this.opcoesDespesas.push(c.descricao);
      });

      this.despesas.data = result;
      this.despesas.paginator = this.paginator;
      this.despesas.sort = this.sort;
    });

    this.displayColumns = this.ExibirColunas();

    this.descricaoDespesas = this.autoCompleteInput.valueChanges.pipe(startWith(''), map(descricao => this.FiltrarDescricoes(descricao)))
  }

  ExibirColunas() : string[] {
    return ['numero', 'descricao', 'categoria', 'valor', 'data', 'acoes']
  }

  AbrirDialog(despesaId, valor): void {
    this.dialog.open(DialogDeleteDespesaComponent, {
      data: {
        id: despesaId,
        valor: valor
      }
    }).afterClosed().subscribe(result => {
      if (result === true) {
        this.despesaService.getByUserId(this.usuarioId).subscribe(dados => {
          this.despesas.data = dados;
        })
      }
      this.displayColumns = this.ExibirColunas();
    })
  }

  FiltrarDescricoes(descricao: string) : string[] {
    if (descricao.trim().length >= 4) {
      this.despesaService.filtrar(descricao).subscribe(result => {
        this.despesas.data = result;
      })
    } else {
      if (descricao === '') {
        this.despesaService.getByUserId(this.usuarioId).subscribe(result => {
          this.despesas.data = result
        })
      }
    }

    return this.opcoesDespesas.filter(despesa =>
      despesa.toLowerCase().includes(descricao.toLowerCase())
    )
  }

}
