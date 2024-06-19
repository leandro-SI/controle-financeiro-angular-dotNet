import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { FuncoesService } from 'src/app/services/funcoes/funcoes.service';

@Component({
  selector: 'app-listar-funcoes',
  templateUrl: './listar-funcoes.component.html',
  styleUrls: ['./listar-funcoes.component.scss']
})
export class ListarFuncoesComponent implements OnInit {

  funcoes = new MatTableDataSource<any>();
  displayColumns: string[]

  @ViewChild(MatPaginator, {static: true})
  paginator: MatPaginator;

  @ViewChild(MatSort, {static: true})
  sort: MatSort;

  constructor(private funcoesService: FuncoesService) { }

  ngOnInit() {
    this.funcoesService.getAll().subscribe(result => {
      this.funcoes.data = result;
      this.funcoes.paginator = this.paginator;
      this.funcoes.sort = this.sort;
    });

    this.displayColumns = this.ExibirColunas();
  }

  ExibirColunas() : string[] {
    return ['name', 'descricao', 'acoes']
  }

}
