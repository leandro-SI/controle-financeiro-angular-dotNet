import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { FuncoesService } from 'src/app/services/funcoes/funcoes.service';

@Component({
  selector: 'app-listar-funcoes',
  templateUrl: './listar-funcoes.component.html',
  styleUrls: ['./listar-funcoes.component.scss']
})
export class ListarFuncoesComponent implements OnInit {

  funcoes = new MatTableDataSource<any>();
  displayColumns: string[];
  autoCompleteInput = new FormControl();
  opcoesFuncoes: string[] = [];
  nomesFuncoes: Observable<string[]>;

  @ViewChild(MatPaginator, {static: true})
  paginator: MatPaginator;

  @ViewChild(MatSort, {static: true})
  sort: MatSort;

  constructor(private funcoesService: FuncoesService) { }

  ngOnInit() {
    this.funcoesService.getAll().subscribe(result => {
      result.forEach((c) => {
        this.opcoesFuncoes.push(c.name);
      });

      this.funcoes.data = result;
      this.funcoes.paginator = this.paginator;
      this.funcoes.sort = this.sort;
    });

    this.displayColumns = this.ExibirColunas();

    this.nomesFuncoes = this.autoCompleteInput.valueChanges.pipe(startWith(''), map(nome => this.FiltrarNomes(nome)))
  }

  ExibirColunas() : string[] {
    return ['name', 'descricao', 'acoes']
  }

  FiltrarNomes(nome: string) : string[] {
    if (nome.trim().length >= 4) {
      this.funcoesService.filtrar(nome).subscribe(result => {
        this.funcoes.data = result;
      })
    } else {
      if (nome === '') {
        this.funcoesService.getAll().subscribe(result => {
          this.funcoes.data = result
        })
      }
    }

    return this.opcoesFuncoes.filter(funcao =>
      funcao.toLowerCase().includes(nome.toLowerCase())
    )
  }

}
